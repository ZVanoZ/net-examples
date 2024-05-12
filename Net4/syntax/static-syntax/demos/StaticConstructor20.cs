using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static_syntax.demos.StaticConstructorClasses;

namespace static_syntax.demos
{
    /**
     * Демострация неявного вызова статического конструктора при обращении к статисескому свойству.
     **/
    internal class StaticConstructor20
    {
        public static void run() {
            Console.WriteLine("demo-StaticConstructor20-beg");
            Console.WriteLine($"MyClass1.myClassName: {MyClass1.myClassName}");
            Console.WriteLine($"MyClass1.StaticMyClassName: {MyClass1.StaticMyClassName}");
//            new MyClass1();
//            new MyClass1();
//            new MyClass1();
            Console.WriteLine("demo-StaticConstructor20-end");
        }

    }

}
