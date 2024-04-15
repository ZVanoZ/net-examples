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
     * Этот пример работает только на большом количестве итераций.
     * 
     * Запускаем 100 потоков по 100 итераций.
     * В каждой итерации инкрементируем общий счетчик.
     * При утсутствии конфликтов должны получить 100*100=10000
     * В реальности получаем разные значения.
     * RESULT: commonCounter=9993
     * RESULT: commonCounter=9995
     * RESULT: commonCounter=9998
     */
    public class Sample0015
    {
        public static int commonCounter = 0;
        const int COUNT_THREAD = 100;
        const int COUNT_ITERATION = 100;
        public void Run()
        {

            Common.WriteSeparator();
            Common.WriteSeparateString(GetType().Name);


            Random random = new Random();

            List<Thread> threads = new List<Thread>();

            //int commonCounter = 0;
            //int countThreads = 100;

            Console.WriteLine($"countThreads = {COUNT_THREAD}");

            for (int i = COUNT_THREAD; i > 0; i--)
            {
                Thread thread = new Thread(
                    new ThreadStart(
                        () =>
                        {
                            Console.WriteLine($"BEG : threadId = {Thread.CurrentThread.ManagedThreadId}");
                            for (int j = 0; j < COUNT_ITERATION; j++)
                            {
                                int readedCommonCounter = commonCounter;
                                commonCounter++;
                                Console.WriteLine($"WORK: threadId = {Thread.CurrentThread.ManagedThreadId}; step={j} readedCommonCounter = {readedCommonCounter}; commonCounter={commonCounter}");
                                Thread.Sleep(random.Next(10, 100));
                            }
                            Console.WriteLine($"END : threadId = {Thread.CurrentThread.ManagedThreadId}");
                        }
                    )
                );
                threads.Add(thread);
                thread.Start();
            }

            Common.waitThreads(threads, false);

            Console.WriteLine($"RESULT: commonCounter={commonCounter}");

            Common.WriteSeparator();
        }
    }

}