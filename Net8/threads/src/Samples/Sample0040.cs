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
     */
    public class Sample0040
    {
        public static void Run()
        {

            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(typeof(Sample0040).Name);
			
			Random random = new Random();

			int countThreads = random.Next(2,5);
			Thread[] threads = new Thread[countThreads];
			for (int i = 0; i < countThreads; i++)
			{
				ParameterizedThreadStart newDelegate = new ParameterizedThreadStart(ThreadBody);
				Thread newThread = new Thread(newDelegate);
				newThread.Name = "myThread-" + i;
                ParamsForThread newParams = new ParamsForThread(
                    newThread.Name,
					random.Next(3001, 15001),
					random.Next(1, 1001)
				);
				threads[i] = newThread;
				newThread.Start(newParams);
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

		static void ThreadBody(object? untypedParams)
		{
			if (! (untypedParams is ParamsForThread))
			{
				throw new Exception("Invalid params");
			}
			ParamsForThread typedParams = (ParamsForThread)untypedParams;
			Console.WriteLine($"ThreadBody-BEG: name = {typedParams.name}; workTime = {typedParams.workTime}; sleepTime = {typedParams.sleepTime}");

			DateTime timeEnd= DateTime.Now.AddMilliseconds(typedParams.workTime);
			int tick = 0;
			while (timeEnd > DateTime.Now) {
				Console.WriteLine($"ThreadBody: name = {typedParams.name}; tick = {++tick}");
				Thread.Sleep(typedParams.sleepTime);
			}
			Console.WriteLine($"ThreadBody-END: name = {typedParams.name}; workTime = {typedParams.workTime}; sleepTime = {typedParams.sleepTime}");
		}

		class ParamsForThread
		{
			public string name;
			public int workTime;
			public int sleepTime;
			public ParamsForThread(
				string name, 
				int workTime, 
				int sleepTime
			)
			{
				this.name = name;
				this.workTime = workTime;
				this.sleepTime = sleepTime;
			}
		}
	}

}