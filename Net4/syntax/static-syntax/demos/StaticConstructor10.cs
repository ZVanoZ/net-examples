using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static_syntax.demos.StaticConstructorClasses;

namespace static_syntax.demos
{
    internal class StaticConstructor10
    {
        public static void run() {
            Console.WriteLine("demo-StaticConstructor-beg");
            MyClass1 obj1 = new MyClass1();
            MyClass1 obj2 = new MyClass1();
            MyClass1 obj3 = new MyClass1();
            Console.WriteLine($"MyClass1.myClassName: {MyClass1.myClassName}");
            Console.WriteLine($"MyClass1.StaticMyClassName: {MyClass1.StaticMyClassName}");
            Console.WriteLine($"obj1.NonStaticMyClassName: {obj1.NonStaticMyClassName}");
            Console.WriteLine($"obj2.NonStaticMyClassName: {obj2.NonStaticMyClassName}");
            Console.WriteLine("demo-StaticConstructor-end");
        }

    }
    
}
