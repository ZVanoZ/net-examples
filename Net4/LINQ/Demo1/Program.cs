using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n".PadRight(80, '-'));
            DemoIEnumerableInt();

            Console.WriteLine("\n".PadRight(80, '-'));
            DemoSelectWordsFirstLetter();

            Console.WriteLine("\n".PadRight(80, '-'));
            DemoSelectManyWordsFromPhrases();

            Console.WriteLine("\n".PadRight(80, '-'));
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        /**
         * https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/
         */
        static void DemoIEnumerableInt() {
            Console.WriteLine("\n-- DemoIEnumerableInt");
            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            // Output: 97 92 81

        }

        /**
         * https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/
         */
        static void DemoSelectWordsFirstLetter()
        {
            Console.WriteLine("\n-- DemoSelectWordsFirstLetter");

            List<string> words = new List<string>(){
                "an",
                "apple", 
                "a", 
                "day" 
            };

            var query = from word in words
                        select word.Substring(0, 1);

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

            /* This code produces the following output:

                a
                a
                a
                d
            */
        }

        /**
         * https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/
         */
        static void DemoSelectManyWordsFromPhrases()
        {
            Console.WriteLine("\n-- DemoSelectManyWords");

            List<string> phrases = new List<string>(){
                "an apple a day", 
                "the quick brown fox"
            };

            var query = from phrase in phrases
                        from word in phrase.Split(' ')
                        select word;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

            /* This code produces the following output:

                an
                apple
                a
                day
                the
                quick
                brown
                fox
            */
        }

    }
}
