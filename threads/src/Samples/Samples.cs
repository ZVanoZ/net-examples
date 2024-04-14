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
    }


}

