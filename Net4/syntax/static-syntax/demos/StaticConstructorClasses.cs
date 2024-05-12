using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace static_syntax.demos.StaticConstructorClasses
{
    public class MyClass1
    {
        public static string myClassName = "???";
        public static string StaticMyClassName
        {
            get
            {
                Console.WriteLine("MyClass/StaticMyClassName");
                // return MyClass1.myClassName; // Можно так
                return myClassName; // ... или так, результат одинаковый.
            }
        }

        public string NonStaticMyClassName
        {
            get
            {
                Console.WriteLine("MyClass/NonStaticMyClassName");
                return myClassName;
            }
        }

        public MyClass1()
        {
            Console.WriteLine("MyClass/constructor");
        }

        static MyClass1()
        {
            Console.WriteLine("MyClass/constructor(satic)");
            myClassName = typeof(MyClass1).Name;
        }
    }
}
