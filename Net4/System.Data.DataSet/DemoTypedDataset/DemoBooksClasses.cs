/**
 * На основании статьи [Как создать XML и XSD схему и наоборот](https://www.devowl.net/2017/11/xml-from-xsd-or-another-xml.html)
 */
using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using DemoTypedDataset.BooksClasses;

namespace DemoTypedDataset
{
    public class DemoBooksClasses
    {
        public static void run() {
            Console.WriteLine("-- DemoBoocsClasses::run/BEG");
            // Создание первой книги
            var book1 = new CatalogBook()
            {
                author = "King",
                description = "Very interesting book",
                genre = "Fantasy",
                price = 22.ToString(),
                id = "42011",
                title = "It"
            };

            // Создание второй книги
            var book2 = new CatalogBook()
            {
                author = "O'Brien, Tim",
                description = "Microsoft's .NET initiative is explored in detail in this deep programmer's reference.",
                genre = "Computer",
                price = 36.ToString(),
                id = "30012",
                title = "Microsoft .NET: The Programming Bible"
            };

            // Создание корневого элемента каталога, содержащего две книги выше
            var catalog = new Catalog()
            {
                Items = new[] { book1, book2 }
            };

            // Содержит XML объекта catalog
            var xmlCatalog = Serialize(catalog);

            // Записываем строку в файл
            // TODO Сделано для демонстрации. Желательно вызывая метод Serialize передавать Stream к файлу
            File.WriteAllText("Output.xml", xmlCatalog);
            Console.WriteLine(xmlCatalog);

            Console.WriteLine("-- DemoBoocsClasses::run/END");
        }

        private static string Serialize<TType>(TType sourceObject)
        {
            if (sourceObject == null)
            {
                return string.Empty;
            }

            // Используем XmlSerializer для перобразования в XML строку
            var xmlserializer = new XmlSerializer(typeof(TType));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings() { Indent = true }))
            {
                xmlserializer.Serialize(writer, sourceObject);
                return stringWriter.ToString();
            }
        }
    }
}
