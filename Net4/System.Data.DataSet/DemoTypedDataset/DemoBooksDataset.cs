using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DemoTypedDataset.BooksDataset;
using static DemoTypedDataset.BooksDataset.Catalog;

namespace DemoTypedDataset {
    public class DemoBooksDataset
    {
        protected static Catalog catalogDataSet;
        public static void run()
        {
            Console.WriteLine("-- DemoBoocsDataset::run/BEG");

            createDataset();
            fillDataset();
            showDataset();
            showByLinq();

            Console.WriteLine("-- DemoBoocsDataset::run/END");
        }
        public static void createDataset()
        {
            Console.WriteLine("-- DemoBoocsDataset::createDataset");
            catalogDataSet = new Catalog();
        }
        public static void fillDataset()
        {
            Console.WriteLine("-- DemoBoocsDataset::fillDataset");

            Catalog.BookRow row;

            row = catalogDataSet.Book.NewBookRow();
            row.author = "King";
            row.description = "Very interesting book";
            row.genre = "Fantasy";
            row.price = 22.ToString();
            row.id = "42011";
            row.title = "It";
            catalogDataSet.Book.Rows.Add(row);


            row = catalogDataSet.Book.NewBookRow();
            row.author = "O'Brien, Tim";
            row.description = "Microsoft's .NET initiative is explored in detail in this deep programmer's reference.";
            row.genre = "Computer";
            row.price = 36.ToString();
            row.id = "30012";
            row.title = "Microsoft .NET: The Programming Bible";
            catalogDataSet.Book.Rows.Add(row);
        }
        public static void showDataset()
        {
            Console.WriteLine("-- DemoBoocsDataset::showDataset");
            foreach (Catalog.BookRow book in catalogDataSet.Book)
            {
                Console.WriteLine($"-- book     :");
                Console.WriteLine($"id          : {book.id}");
                Console.WriteLine($"author      : {book.author}");
                Console.WriteLine($"description : {book.description}");
                Console.WriteLine($"genre       : {book.genre}");
                Console.WriteLine($"price       : {book.price}");
                Console.WriteLine($"title       : {book.title}");
            }
        }
        public static void showByLinq()
        {
            Console.WriteLine("-- DemoBoocsDataset::showByLinq");
            BookDataTable booksTable = catalogDataSet.Book;

            IEnumerable<Catalog.BookRow> queryResult = from book in booksTable.AsEnumerable()
                                                       where book.id == "42011"
                                                       select book
            ;
            foreach (Catalog.BookRow book in queryResult)
            {
                Console.WriteLine($"-- book     :");
                Console.WriteLine($"id          : {book.id}");
                Console.WriteLine($"author      : {book.author}");
                Console.WriteLine($"description : {book.description}");
                Console.WriteLine($"genre       : {book.genre}");
                Console.WriteLine($"price       : {book.price}");
                Console.WriteLine($"title       : {book.title}");
            }
        }
    }
}
