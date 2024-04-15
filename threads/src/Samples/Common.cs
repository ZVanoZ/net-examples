using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace Samples
{
    class Common
    {
        public static string separator = "-----------------------------------------------------------------";

        public static void WriteSeparator()
        {
            Console.WriteLine(separator);
        }
        public static void WriteSeparateString(string value)
        {
            Console.WriteLine("-- " + value);
        }

        public static void waitThreads(
            List<Thread> threads, 
            bool isWriteWaitProcess=true
        ) {
            while (true)
            {
                bool isFinished = true;
                foreach (Thread thread in threads)
                {
                    // Проверка статуса через побитовые операции
                    // См. https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadstate?view=net-8.0
                    bool isThreadAlive = 0 == (thread.ThreadState & (ThreadState.Stopped | ThreadState.Aborted));
                    if (isThreadAlive)
                    {
                        if (isWriteWaitProcess) {
                            Console.WriteLine($"MainThread: found alive thread {thread.Name}");
                        }
                        isFinished = false;
                        break;
                    }
                }
                if (isFinished)
                {
                    if (isWriteWaitProcess)
                    {
                        Console.WriteLine("MainThread: finish - all threads has invalid status");
                    }
                    break;
                }
                if (isWriteWaitProcess)
                {

                    Console.WriteLine("MainThread: sleep...");
                }
                Thread.Sleep(1000);
            }
        }

    }


}

