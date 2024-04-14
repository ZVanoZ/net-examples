using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{

    /**
     * Параллельные потоки с задержками.
     */
    public class Sample0040
    {
        public static void Run()
        {

            Common.WriteSeparator();
            Common.WriteSeparateString(typeof(Sample0040).Name);
			
			Random random = new Random();

			int countThreads = random.Next(2,5);
			Thread[] threads = new Thread[countThreads];
			for (int i = 0; i < countThreads; i++)
			{
				ParameterizedThreadStart newDelegate = new ParameterizedThreadStart(ThreadBody);
				Thread newThread = new Thread(newDelegate);
				ParamsForThread newParams = new ParamsForThread(
					"myThread-" + i,
					random.Next(3001, 15001),
					random.Next(1, 1001)
				);
				threads[i] = newThread;
				newThread.Start(newParams);
			}

			foreach (Thread thread in threads) {
				thread.Join();
			}

			Common.WriteSeparator();
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