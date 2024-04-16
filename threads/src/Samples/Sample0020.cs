using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    /**
     * Пример показывает как создать потоки без параметров
     */
    public static class Sample0020
    {
        public static void Run()
        {
            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(typeof(Sample0020).Name);

            Thread myThread1 = new Thread(Print);
            Thread myThread2 = new Thread(new ThreadStart(Print));
            Thread myThread3 = new Thread(() => Console.WriteLine("inline: myThread3 Hello Threads"));
            Thread myThread4 = new Thread(new ThreadStart(StaticPrint));

            void Print() => Console.WriteLine("defined-in-method: Hello Threads");

            myThread1.Start();
            myThread2.Start();
            myThread3.Start();
            myThread4.Start();

            myThread1.Join();
            myThread2.Join();
            myThread3.Join();
            myThread4.Join();

            common.Common.WriteSeparator();
        }

        static void StaticPrint()
        {
            Console.WriteLine("StaticPrint: Hello Threads");
        }
    }
}