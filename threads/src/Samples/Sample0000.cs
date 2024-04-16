using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{

    /**
     * Шаблон для копипаста
     */
    public class Sample0000
    {
        public static void Run()
        {

            common.Common.WriteSeparator();
            //common.Common.WriteSeparateString(MethodBase.GetCurrentMethod().Name);
            common.Common.WriteSeparateString(typeof(Sample0000).Name);

            Console.WriteLine("@TODO: ...");

            common.Common.WriteSeparator();
        }
    }

}