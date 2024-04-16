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
     * Исправляем ошибку совместного доступа из примера 15.
     * Метод синхронизации: используем экземпляр Mutex.
     * См. https://metanit.com/sharp/tutorial/11.7.php
     * 
     * Всегда должны получить 100*100=10000
     * 
     * Никогда не должны видеть подобные строки:
     * CONFLICT: $WORK: threadId = 61; step=58 commonCounterBefore = 5532; commonCounterAfter=5534
     */
    public class Sample0015Mutex
    {
        public static int commonCounter = 0;
        const int COUNT_THREAD = 100;
        const int COUNT_ITERATION = 100;
        Mutex mutex = new Mutex();
        public void Run()
        {
            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(GetType().Name);

            Random random = new Random();
            List<Thread> threads = new List<Thread>();
            List<string> conflicts = new List<string>();

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

                                mutex.WaitOne();           // Останавливаем текущий поток, пока mutex не освободится
                                int commonCounterBefore = commonCounter;
                                int commonCounterAfter = ++commonCounter;
                                //commonCounter++;
                                //int commonCounterAfter = commonCounter;
                                mutex.ReleaseMutex();      // Снимаем блокировку

                                string line = $"WORK: threadId = {Thread.CurrentThread.ManagedThreadId}; step={j} commonCounterBefore = {commonCounterBefore}; commonCounterAfter={commonCounterAfter}";
                                if (commonCounterAfter - commonCounterBefore != 1) {
                                    conflicts.Add(line);
                                }
                                Console.WriteLine(line);
                                Thread.Sleep(random.Next(10, 100));
                            }
                            Console.WriteLine($"END : threadId = {Thread.CurrentThread.ManagedThreadId}");
                        }
                    )
                );
                threads.Add(thread);
                thread.Start();
            }

            common.Common.waitThreads(threads, false);

            Console.WriteLine($"RESULT: commonCounter={commonCounter}");

            conflicts.ForEach(logItem =>{
                Console.WriteLine($"CONFLICT: ${logItem}");
            });
            common.Common.WriteSeparator();
        }
    }

}