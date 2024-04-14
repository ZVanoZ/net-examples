using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class Sample0010
    {
        public static void Run()
        {
            Common.WriteSeparator();
            //Common.WriteSeparateString(MethodBase.GetCurrentMethod().Name);
            Common.WriteSeparateString(typeof(Sample0010).Name);

            // получаем текущий поток
            Thread currentThread = Thread.CurrentThread;
            //получаем имя потока
            Console.WriteLine($"Имя потока: {currentThread.Name}");
            currentThread.Name = "Метод Main";
            Console.WriteLine($"Имя потока: {currentThread.Name}");

            Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
            Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
            Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
            Console.WriteLine($"Статус потока: {currentThread.ThreadState}");

            Common.WriteSeparator();

        }
    }

}