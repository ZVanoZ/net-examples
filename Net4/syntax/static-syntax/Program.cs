using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static_syntax.demos;

namespace static_syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----");
            // StaticConstructor10.run(); 
            Console.WriteLine("-----");
            StaticConstructor20.run();  // Тут статический конструктор сработает только если закомментировать выше "StaticConstructor10.run()" 
            Console.WriteLine("-----");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
