using System;

namespace DemoTypedDataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-".PadLeft(80, '-'));

            DemoBooksClasses.run();

            Console.WriteLine("-".PadLeft(80, '-'));

            DemoBooksDataset.run();

            Console.WriteLine("-".PadLeft(80, '-'));

            DemoShopDataset.run();

            Console.WriteLine("-".PadLeft(80, '-'));

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }
       
    }

}
