using System.Reflection.Metadata.Ecma335;

namespace common
{
    public class Common
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
            bool isWriteWaitProcess = true
        )
        {
            while (true)
            {
                bool isFinished = true;
                foreach (Thread thread in threads)
                {
                    // Проверка статуса через побитовые операции
                    // См. https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadstate?view=net-8.0
                    bool isThreadAlive = IsThreadAlive(thread);
                    if (isThreadAlive)
                    {
                        if (isWriteWaitProcess)
                        {
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
        /**
         * Возвращает true, если поток находится в состоянии выполнения
         */
        public static bool IsThreadAlive(Thread thread)
        {
            // Проверка статуса через побитовые операции
            // См. https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadstate?view=net-8.0
            bool isThreadAlive = 0 == (thread.ThreadState & (ThreadState.Stopped | ThreadState.Aborted));
            return isThreadAlive;
        }

        public static string GetThreadId(Thread thread)
        {
            string result = String.Format("{0:00}", thread.ManagedThreadId);
            return result;
        }
        public static string GetStrThread()
        {
            string result = GetStrThread(Thread.CurrentThread);
            return result;
        }

        public static string GetStrThread(
            Thread thread
        )
        {
            if (thread == null)
            {
                thread = Thread.CurrentThread;
            }
            string result = GetThreadId(thread);
            result = $"{result} (current thread-id)";
            return result;
        }

        public static string GetStrThreads(
            Thread contextThread
        )
        {
            string result = GetStrThreads(Thread.CurrentThread, contextThread);
            return result;
        }

        public static string GetStrThreads(
            Thread currentThraad,
            Thread contextThread 
            )
        {
            string result = $"{GetThreadId(currentThraad)}/{GetThreadId(contextThread)} (current/context thread-id)";
            return result;
        }
    }
}
