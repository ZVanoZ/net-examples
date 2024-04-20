using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samples
{

    /**
     * Параллельные потоки с задержками.
     * Главный поток проверяет состояние дочерних и ожидает их завершение.
     * Вариант с выносом тела потока в объект с контекстом потока.
     */
    public class Sample0045
    {
        public static void Run()
        {

            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(typeof(Sample0045).Name);
			
			Random random = new Random();

			int countThreads = random.Next(2,5);
			Thread[] threads = new Thread[countThreads];
			for (int i = 0; i < countThreads; i++)
			{
                ContextForThread context = new ContextForThread(
                    "thread-" + i,
                    random.Next(3001, 15001),
                    random.Next(1, 1001)
                );
                Thread newThread = new Thread(context.ThreadBody);
				newThread.Name = context.name;
               
				threads[i] = newThread;
				newThread.Start();
			}

            // -- Вместо этого
            // thread.Join();
            // -- Теперь проверка статусов в бесконечном цикле
            while (true) {
				bool isFinished = true;
                foreach (Thread thread in threads)
                {
                    // Проверка статуса через побитовые операции
                    // См. https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadstate?view=net-8.0
                    bool isThreadAlive = 0 == (thread.ThreadState & (ThreadState.Stopped | ThreadState.Aborted));
                    if (isThreadAlive) {
						Console.WriteLine($"MainThread: found alive thread {thread.Name}");
						isFinished = false;
						break;
                    }
                }
				if (isFinished)
                {
                    Console.WriteLine("MainThread: finish - all threads has invalid status");
                    break;
				}
                Console.WriteLine("MainThread: sleep...");
                Thread.Sleep(1000);
            }

            common.Common.WriteSeparator();
        }

		

		class ContextForThread
		{
			public string name;
			public int workTime;
			public int sleepTime;
			public ContextForThread(
				string name, 
				int workTime, 
				int sleepTime
			)
			{
				this.name = name;
				this.workTime = workTime;
				this.sleepTime = sleepTime;
			}
            public void ThreadBody()
            {
                Console.WriteLine($"ThreadBody-BEG: name = {this.name}; workTime = {this.workTime}; sleepTime = {this.sleepTime}");

                DateTime timeEnd = DateTime.Now.AddMilliseconds(this.workTime);
                int tick = 0;
                while (timeEnd > DateTime.Now)
                {
                    Console.WriteLine($"ThreadBody: name = {this.name}; tick = {++tick}");
                    Thread.Sleep(this.sleepTime);
                }
                Console.WriteLine($"ThreadBody-END: name = {this.name}; workTime = {this.workTime}; sleepTime = {this.sleepTime}");
            }
        }
	}

}