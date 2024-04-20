/**
 * @see: https://learn.microsoft.com/ru-ru/dotnet/api/system.io.filesystemwatcher?view=net-8.0
 */

using System;
using System.IO;

namespace MyNamespace
{
    class MyClassCS
    {
        static void Main()
        {
            Console.WriteLine($"== dir:{AppDomain.CurrentDomain.BaseDirectory}");
            //string monitorDir = AppDomain.CurrentDomain.BaseDirectory;
            string monitorDir = "c:\\tmp\\";

            using var watcher = new FileSystemWatcher(monitorDir);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(
            object sender, 
            ErrorEventArgs errEvent
        )
        {
            Console.WriteLine("OnError: ");
            Exception errException = errEvent.GetException();
            PrintException(errException);
        }

        private static void PrintException(Exception? ex)
        {
            Console.WriteLine("PrintException:");
            if (ex == null)
            {
                Console.WriteLine("PrintException: @skip: ex is null");
                return;
            }
            try {
                Console.WriteLine("PrintException: write");
                Console.WriteLine($"PrintException: Message: {ex.Message}");
                Console.WriteLine("PrintException: Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("PrintException: InnerException:");
                PrintException(ex.InnerException);
            }
            catch    (Exception) {
                Console.WriteLine("PrintException: error");

            }

        }
    }
}