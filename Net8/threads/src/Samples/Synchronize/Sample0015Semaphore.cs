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
     * Метод синхронизации: используем экземпляр Semaphore.
     * См. https://metanit.com/sharp/tutorial/11.8.php
     * 
     * Использование семафора в данном примере не рационально т.к. он предназначен для 
     * реализации пула блокировок.
     * <code class="C#">
     *   // Станавливаем пул в размере 3х блокировок.
     *   static Semaphore semaphore = new Semaphore(3, 3);
     *   
     *   semaphore.WaitOne(); // осталось 2 свободных блокировки. 
     *   // Продолжение работы потока
     *   semaphore.WaitOne(); // осталось 1 свободная блокировка. 
     *   // Продолжение работы потока
     *   semaphore.WaitOne(); // 0 свободных блокировок. Текущий поток заблокирован.
     *   // Сюда не попадем пока соседний поток не освободит блокировку.
     * </code>
     * 
     * Всегда должны получить 100*100=10000
     * 
     * Никогда не должны видеть подобные строки:
     * CONFLICT: $WORK: threadId = 61; step=58 commonCounterBefore = 5532; commonCounterAfter=5534
     */
    public class Sample0015Semaphore
    {
        public static int commonCounter = 0;
        const int COUNT_THREAD = 100;
        const int COUNT_ITERATION = 100;
        
        static Semaphore semaphore = new Semaphore(1, 1);

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

                                semaphore.WaitOne(); // Останавливаем текущий поток, пока mutex не освободится
                                int commonCounterBefore = commonCounter;
                                int commonCounterAfter = ++commonCounter;
                                //commonCounter++;
                                //int commonCounterAfter = commonCounter;
                                semaphore.Release(); // Снимаем блокировку

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