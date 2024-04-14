using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Samples {

    /**
     * Пример показывает как создать потоки с параметрами используя ParameterizedThreadStart
     * К сожалению, этот метод не позволяет типизировать передаваемый параметр.
     */
    public static class Sample0030
    {
        public static void Run()
        {
            Common.WriteSeparator();
            Common.WriteSeparateString(typeof(Sample0030).Name);

            // создаем новые потоки
            Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
            Thread myThread2 = new Thread(Print);
            Thread myThread3 = new Thread(message => Console.WriteLine("inline myThread3: message = " + message));
            Thread myThread4 = new Thread(new ParameterizedThreadStart(StaticPrint));

            void Print(object? message)
            {
                Console.WriteLine("defined-in-method: : message = " + message);
            }

            myThread1.Start("myThread1");
            myThread2.Start("myThread2");
            myThread3.Start("myThread3");
            myThread4.Start("myThread4");

            myThread1.Join();
            myThread2.Join();
            myThread3.Join();
            myThread4.Join();

            Common.WriteSeparator();
        }

        static void StaticPrint(Object? message)
        {
            Console.WriteLine($"StaticPrint: : message = {message}");
        }
    }
}