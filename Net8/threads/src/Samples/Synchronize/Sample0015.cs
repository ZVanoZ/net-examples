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
     * 
     * При утсутствии конфликтов должны получить 100*100=10000
     * В реальности получаем разные значения.
     * RESULT: commonCounter=9993
     * RESULT: commonCounter=9995
     * RESULT: commonCounter=9998
     * 
     * Кроме того, иногда можно получить трудноуловимые конфликты которые происходят между инкриментом и считыванием значения.
     * CONFLICT: $WORK: threadId = 60; step=21 commonCounterBefore = 1879; commonCounterAfter=1881
     * CONFLICT: $WORK: threadId = 61; step=58 commonCounterBefore = 5532; commonCounterAfter=5534
     */
    public class Sample0015
    {
        public static int commonCounter = 0;
        const int COUNT_THREAD = 100;
        const int COUNT_ITERATION = 100;
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
                                int commonCounterBefore = commonCounter;

                                // Даже в этом случае возникают конфликты.
                                // Казалось бы, операция в одну строчку и ничто не может вмешаться в процесс.
                                // Но нет, тут тоже может возникнуть конфликт.
                                int commonCounterAfter = ++commonCounter; 
                                
                                // В этом случае конфликты чаще
                                //commonCounter++;
                                //int commonCounterAfter = commonCounter;

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