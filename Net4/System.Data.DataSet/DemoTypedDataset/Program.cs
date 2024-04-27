using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace DemoTypedDataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemoBoocsClasses.run();

            DemoBoocsDataset.run();

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }
       
    }

}
