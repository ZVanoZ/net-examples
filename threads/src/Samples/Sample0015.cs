using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class Sample0015
    {
        public static void Run()
        {
            common.Common.WriteSeparator();
            //common.Common.WriteSeparateString(MethodBase.GetCurrentMethod().Name);
            common.Common.WriteSeparateString(typeof(Sample0015).Name);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
                Console.WriteLine(i);
            }

            common.Common.WriteSeparator();

        }
    }

}