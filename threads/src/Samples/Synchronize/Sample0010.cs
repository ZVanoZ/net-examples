using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Samples;

namespace Samples.Synchronize
{
    /**
    * Демонстрация конфликта потоков при обращении к одной переменной.
    */
    public class Sample0010
    {
        public void Run()
        {

            Common.WriteSeparator();
            Common.WriteSeparateString(GetType().Name);


            int x = 0;

            List<Thread> threads = new List<Thread>();  
//            List<string> log = new List<string>();
//            
            // запускаем потоки
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Print);
                threads.Add(myThread);
                myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока
                myThread.Start();
            }

            void Print()
            {
                Console.WriteLine($"BEG: {Thread.CurrentThread.Name}: x = {x}");
                x = 1; // 1й конфликт. Каждый из потоков при старте устанавливает счетчик в 1
                Console.WriteLine($"BEG: {Thread.CurrentThread.Name}: x = {x} (после x = 1)");

                for (int i = 1; i < 6; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: x = {x}");
//                    log.Add($"{Thread.CurrentThread.Name}: x = {x}");
                    x++; // 2й конфликт
                    Console.WriteLine($"{Thread.CurrentThread.Name}: x = {x} (после инкримента)");
//                    log.Add($"{Thread.CurrentThread.Name}: x = {x} (после инкримента)");
                    Thread.Sleep(100);
                }
            }

            Common.waitThreads(threads, false);

//            log.ForEach(logItem =>{
//                Console.WriteLine(logItem);
//            });
            Console.WriteLine($"MainThread: x = {x}");

            Common.WriteSeparator();
        }
    }

}