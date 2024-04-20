using common;
using System;

namespace Samples
{
    /**
     *@see: https://metanit.com/sharp/tutorial/13.3.php
     */
    public class Sample0010
    {
        public void Run()
        {

            Common.WriteSeparator();
            Common.WriteSeparateString(GetType().Name);

            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Run - перед вызовом");
            RunAsync().Wait(); // Запускаем асинхронный процесс и ждем
            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Run - после вызова");

            Common.WriteSeparator();
        }

        static async Task RunAsync() {
            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: RunAsync BEG");

            await PrintAsync("await");   // вызов асинхронного метода в синхронном режиме. Текущий поток ждет.
            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: RunAsync:: после await");

            PrintAsync("Wait()").Wait(); // вызов асинхронного метода в асинхронном режиме с запуском ожидания через ".Wait()".
            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: RunAsync:: после Wait()");

            Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Некоторые действия в методе Main");

            void Print()
            {
                Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Print - начало");
                Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Print:: sleep...");
                Thread.Sleep(3000);     // имитация продолжительной работы
                Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: Print - конец");
            }
            // определение асинхронного метода
            async Task PrintAsync(
                string step
                )
            {
                Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: PrintAsync - Начало {step}"); // выполняется синхронно
                await Task.Run(() => Print());                           // выполняется асинхронно
                Console.WriteLine($"thread-id {Thread.CurrentThread.ManagedThreadId}:: PrintAsync - Конец {step}");
            }
        }
        
    }

}