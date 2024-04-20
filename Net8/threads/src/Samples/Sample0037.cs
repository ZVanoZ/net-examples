using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    /**
     * В этом примере боремся с невозможностью типизировать входящие параметры потока в связке с ParameterizedThreadStart.
     * Для этого тело потока помещаем внутрь класса ThreadContext, который содержит данные для потока (контекст выполнения).
     * Таким образом все параметры красиво доступны через this в методе ThreadBody
     */
    public static class Sample0037
    {
        public static void Run()
        {
            common.Common.WriteSeparator();
            common.Common.WriteSeparateString(typeof(Sample0037).Name);

            ThreadContext threadContext = new ThreadContext("Val1", 123);
            Thread myThread1 = new Thread(threadContext.ThreadBody);
            myThread1.Start();
            
            myThread1.Join();
            common.Common.WriteSeparator();
        }

        class ThreadContext
        {
            public string val1;
            public int val2;
            public ThreadContext(string val1, int val2)
            {
                this.val1 = val1;
                this.val2 = val2;
            }
            public void ThreadBody()
            {
                Console.WriteLine($"static: {this.val1}, {this.val2}");
            }
        }
    }
}