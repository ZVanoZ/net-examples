
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DemoTypedDataset.ShopSchemaDataset;
using static DemoTypedDataset.ShopSchemaDataset.ShopDataSet;

namespace DemoTypedDataset
{
    public class DemoShopDataset
    {
        protected static ShopDataSet shopDataset = new ShopDataSet();
        public static void run()
        {
            Console.WriteLine("-- DemoShopDataset::run/BEG");

            fillDataset();

            showAuthors();
            showBooks();

            linqBooksForAuthorId();
            linqBooksForAuthorId(2);

            linqBooksWithAutors();

            Console.WriteLine("-- DemoShopDataset::run/END");
        }
        public static void fillDataset()
        {
            Console.WriteLine("-- DemoShopDataset::fillDataset");
            { 
                ShopDataSet.AuthorsRow row;

                row = shopDataset.Authors.NewAuthorsRow();
                row.ID = 1;
                row.Firstname = "Autor1Firstname";
                row.Birthday = DateTime.ParseExact("2001-01-15", "yyyy-MM-dd", null);
                shopDataset.Authors.Rows.Add(row);

                row = shopDataset.Authors.NewAuthorsRow();
                row.ID = 2;
                row.Firstname = "Autor2Firstname";
                row.Birthday = DateTime.ParseExact("2002-02-20", "yyyy-MM-dd", null);
                shopDataset.Authors.Rows.Add(row);
            }
            {
                ShopDataSet.BooksRow row;
                
                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 1;
                row.Title = "Author 1 book 1 Title";
                row.Price = 13.4;
                row.CreatedAt = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);

                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 2;
                row.Title = "Author 2 book 1 Title";
                row.Price = 1.95;
                row.CreatedAt = DateTime.ParseExact("2020-01-13", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);

                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 2;
                row.Title = "Author 2 book 2 Title";
                row.Price = 15.95;
                row.CreatedAt = DateTime.ParseExact("2023-05-13", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);

                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 1;
                row.Title = "Author 1 book 2 Title";
                row.Price = 19.99;
                row.CreatedAt = DateTime.ParseExact("2022-02-01", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);

                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 1;
                row.Title = "Author 1 book 3 Title";
                row.Price = 9.95;
                row.CreatedAt = DateTime.ParseExact("2022-03-01", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);

                row = shopDataset.Books.NewBooksRow();
                row.Author_ID = 2;
                row.Title = "Author 2 book 3 Title";
                row.Price = 99.99;
                row.CreatedAt = DateTime.ParseExact("2024-03-30", "yyyy-MM-dd", null);
                shopDataset.Books.Rows.Add(row);
            }
        }
        public static void showAuthors() {
            Console.WriteLine("-- DemoShopDataset::showAuthors()");
            showAuthors(shopDataset.Authors);
        }
        public static void showAuthors(
            AuthorsDataTable table
        )
        {
            Console.WriteLine("-- DemoShopDataset::showAuthors(AuthorsDataTable)");
            foreach (ShopDataSet.AuthorsRow row in table)
            {
                Console.WriteLine($"-- row     :");
                Console.WriteLine($"ID         : {row.ID}");
                Console.WriteLine($"Firstname  : {row.Firstname}");
                Console.WriteLine($"Birthday   : {row.Birthday}");
            }
        }
        public static void showBooks()
        {
            Console.WriteLine("-- DemoShopDataset::showBooks()");
            showBooks(shopDataset.Books);
        }

        public static void showBooks(
            IEnumerable<ShopDataSet.BooksRow> table
        )
        {
            Console.WriteLine("-- DemoShopDataset::showAuthors(IEnumerable<ShopDataSet.BooksRow> table)");
            foreach (ShopDataSet.BooksRow row in table)
            {
                Console.WriteLine($"-- row     :");
                Console.WriteLine($"ID         : {row.ID}");
                Console.WriteLine($"Author_ID  : {row.Author_ID}");
                Console.WriteLine($"Title      : {row.Title}");
                Console.WriteLine($"Price      : {row.Price}");
            }
        }

        public static void linqBooksForAuthorId(
            UInt64 authorId=1
        ) {
            Console.WriteLine("-- DemoShopDataset::linqBooksForAuthorId");
            Console.WriteLine("-- authorId: " + authorId);
            IEnumerable<ShopDataSet.BooksRow> queryResult = 
                from book in shopDataset.Books.AsEnumerable()
                where book.Author_ID == authorId
                orderby book.Price descending
                select book
            ;
            showBooks(queryResult); 
        }
        public static void linqBooksWithAutors()
        {
            var query =
                from book in shopDataset.Books
                join autor in shopDataset.Authors 
                    on book.Author_ID equals autor.ID
                select new
                { 
                    bookTitle = book.Title,
                    //autorName = autor.Firstname + " " + (autor.Middlename ?? "-") + (" " + autor.Lastname ?? "-"),
                    autorName = autor.Firstname + " " + autor?.Middlename,
                    bookPrice = book.Price, 
                }
            ;
            foreach (var row in query)
            {
                Console.WriteLine($"-- row     :");
                Console.WriteLine($"bookTitle  : {row.bookTitle}");
                Console.WriteLine($"autorName  : {row.autorName}");
                Console.WriteLine($"bookPrice  : {row.bookPrice}");
            }
        }
    }
}
