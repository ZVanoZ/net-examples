using common;

namespace Samples.Context
{
    /**
    * Читаем контекст дочернего потока из главного потока.
    * Синхронизация доступа через Mutex.
    */
    public class Sample0010
    {
        const int COUNT_THREAD = 3;
        public void Run()
        {

            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(GetType().Name);
            Console.WriteLine($"{Common.GetStrThread()} : MainThread : BEG");
            Console.WriteLine($"{Common.GetStrThread()} : MainThread : countThreads = {COUNT_THREAD}");


            List<Context> contexts = new List<Context>();

            for (int i = COUNT_THREAD; i > 0; i--)
            {
                string fileName = $"file-{i}";
                Context context = new Context(
                    $"inpDir/{fileName}",
                    $"outDir/{fileName}"
                );

                contexts.Add(context);
                context.thread.Start();
            }

            // В текущем потоке организовываем цикл, который будет проверять статус выполнения задачь в дочерних потоках.
            int countAlive;
            do
            {
                Console.WriteLine($"{Common.GetStrThread()} : MainThread : check status...");
                countAlive = 0;
                foreach (Context context in contexts)
                {
                    bool isThreadAlive = common.Common.IsThreadAlive(context.thread);
                    if (isThreadAlive)
                    {
                        ++countAlive;
                    }
                    Console.WriteLine($"{Common.GetStrThread()} : MainThread : check status : {Common.GetThreadId(context.thread)} : ");

                    // Если обращаемся к свойству напрямую, то синхронизация снаружи контекста.
                    // Не рекомендуется так делать.
                    context.mutex.WaitOne();
                    Console.WriteLine($"{Common.GetStrThreads(context.thread)} : MainThread : check status : {Common.GetThreadId(context.thread)} : percent by property : {context.percent}");
                    context.mutex.ReleaseMutex();

                    // Если обращаемся через геттер/сеттер, то синхронизация должна быть инкапсулирована в методе.
                    // Так делать нормально.
                    Console.WriteLine($"{Common.GetStrThreads(context.thread)} : MainThread : check status : {Common.GetThreadId(context.thread)} : percent by getter  : {context.Percent}");
                }
                Thread.Sleep(1000);
            } while (countAlive > 0);

            Console.WriteLine($"{Common.GetStrThread()} : MainThread : END");
            common.Common.WriteSeparator();
        }

        class Context
        {
            public Thread thread;
            public Mutex mutex = new Mutex();

            public string copyFrom;
            public string copyTo;

            public int fileSize = 0;
            public int copySpeed = 0;


            /**
             * Свойство "percent" используется между потоками.
             * Доступ к нему нужно синхронизировать/
             */
            public int percent = 0;

            public int Percent
            {
                get
                {
                    // Синхронизация доступа инкапсулирована в методе
                    mutex.WaitOne();
                    int result = percent;
                    mutex.ReleaseMutex();

                    Console.WriteLine($"{Common.GetStrThreads(this.thread)} : Context.Percent.get : percent = {result}");

                    return percent;
                }
            }

            /**
             * Конструктор контекста потока.
             */
            public Context(
                string copyFrom,
                string copyTo
            )
            {
                this.copyFrom = copyFrom;
                this.copyTo = copyTo;
                Random random = new Random();
                this.fileSize = random.Next(1, 10000);
                this.copySpeed = 1 + random.Next(this.fileSize / 10, this.fileSize / 3);
                this.thread = new Thread(this.ThreadBody);
                Console.WriteLine(
                    $"{Common.GetStrThread()} : Context.constructor :"
                    + $" inner-thread-id = {this.thread.ManagedThreadId};"
                    + $" copyFrom = {copyFrom};"
                    + $" copyTo = {copyTo};"
                    + $" fileSize = {fileSize};"
                    + $" copySpeed = {copySpeed};"
                );

            }

            /**
             * Тело потока
             */ 
            protected void ThreadBody()
            {
                Console.WriteLine($"{Common.GetStrThreads(this.thread)} : Context.ThreadBody : BEG  : {this.copyFrom}");
                int copiedBytes = 0;
                while (copiedBytes < this.fileSize)
                {
                    copiedBytes += this.copySpeed;
                    copiedBytes = copiedBytes > this.fileSize ? this.fileSize : copiedBytes;

                    // При обращении к свойствам совместного доступа нужно синхронизировать доступ
                    mutex.WaitOne();
                    this.percent = 100 * copiedBytes / fileSize;
                    Console.WriteLine($"{Common.GetStrThreads(this.thread)} : Context.ThreadBody : COPY : {this.copyFrom} {this.percent}% ({copiedBytes}/{fileSize})");
                    mutex.ReleaseMutex();

                    Thread.Sleep(250);
                }
                Console.WriteLine($"{Common.GetStrThreads(this.thread)} : Context.ThreadBody : END  : {this.copyFrom}");
            }
        }
    }

}