/**
 * Пример показывает как работать с простым DataSet, в котором две простых таблицы.
 * Структура таблиц не обвязана статической типизацией.
 * Т.е. тут легко получить ошибку во время исполнения, а не на этапе компиляции.
 * 
 * На основе статьи [Работа с БД/DataSet] (https://professorweb.ru/my/ADO_NET/base/level2/2_1.php)
 * + добрал немного инфы из мануалов
 */
using System;
using System.Collections;
using System.Data;
using System.Threading;

namespace Demo1
{
    internal class Program
    {
        protected static DataSet dataSet;
        protected static DataTable filesTable;

        static void Main(string[] args)
        {
            CreateDataset();
            FillDataset();

            DisplayExtendedProperties();
            
            DisplayDataset();
            Console.WriteLine("Sleep...");
            Thread.Sleep(2000);
            ChangeDataset();
            DisplayDataset();

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        protected static void CreateDataset()
        {
            Console.WriteLine();
            Console.WriteLine("-- CreateDataset");

            // Создание DataSet
            dataSet = new DataSet("DemoDataSet");
            dataSet.ExtendedProperties["StartAt"] = DateTime.Now;
            dataSet.ExtendedProperties["SomeGuid"] = Guid.NewGuid();

            DataTable optionsTable = new DataTable("MyOptionsTable");
            dataSet.Tables.Add(optionsTable);
            optionsTable.Columns.Add(
                new DataColumn(
                    "OptionKey",
                    typeof(string)
                )
            );
            optionsTable.Columns["OptionKey"].Unique = true;
            optionsTable.Columns["OptionKey"].AllowDBNull = false;
            optionsTable.PrimaryKey = new DataColumn[]{
                optionsTable.Columns["OptionKey"]
            };

            optionsTable.Columns.Add(
                new DataColumn(
                    "StringValue",
                    typeof(string)
                )
            );
            optionsTable.Columns.Add(
                new DataColumn(
                    "IntValue",
                    typeof(int)
                )
            );

            filesTable = new DataTable("MyFilesTable");
            dataSet.Tables.Add(filesTable);  

            DataColumn columnFileId = new DataColumn("ID", typeof(int));
            columnFileId.Caption = "File ID";
            columnFileId.ReadOnly = true;
            columnFileId.AllowDBNull = false;
            columnFileId.Unique = true;
            columnFileId.AutoIncrement = true;
            columnFileId.AutoIncrementSeed = 0;
            columnFileId.AutoIncrementStep = 1;

            DataColumn columnFilePath = new DataColumn("Path", typeof(string));
            columnFilePath.Caption = "Path";
            columnFilePath.Unique = true;

            DataColumn columnCreatedAt = new DataColumn("CreatedAt", typeof(DateTime));
            columnCreatedAt.Caption = "CreatedAt";
            columnCreatedAt.DefaultValue = DateTime.Now;

            DataColumn columnModifiedAt = new DataColumn("ModifiedAt", typeof(DateTime));
            columnModifiedAt.Caption = "ModifiedAt";

            filesTable.Columns.AddRange(new DataColumn[] {
                columnFileId,
                columnFilePath,
                columnCreatedAt,
                columnModifiedAt
            });
        }

        protected static void FillDataset()
        {
            Console.WriteLine();
            Console.WriteLine("-- FillDataset");

            {// Fill "MyOptionsTable" 
                DataTable optionsTable = dataSet.Tables["MyOptionsTable"];
                DataRow row;

                row = optionsTable.NewRow();
                row["OptionKey"] = "AppName";
                row["StringValue"] = "My Cool Application Name";
                optionsTable.Rows.Add(row);

                row = optionsTable.NewRow();
                row["OptionKey"] = "ProgrammersCount";
                row["IntValue"] = 1;
                optionsTable.Rows.Add(row);

            }
            {// Fill "MyFilesTable" 
                for (int i = 0; i < 5; i++)
                {
                    DataRow row = filesTable.NewRow();
                    row["Path"] = $"c:\\inp\\file-{i}.txt";
                    filesTable.Rows.Add(row);
                }
            }
        }

        protected static void ChangeDataset()
        {
            Console.WriteLine();
            Console.WriteLine("-- ChangeDataset");
            {
                Console.WriteLine("-- ChangeDataset/MyOptionsTable: ++ProgrammersCount");
                DataRow row = dataSet.Tables["MyOptionsTable"].Rows.Find("ProgrammersCount");
                row["IntValue"] = (int)row["IntValue"] + 1;
            }
            {
                Console.WriteLine("-- ChangeDataset/MyFilesTable: ");
                foreach (int delIndex in new int[] {4,2,1})
                {
                    dataSet.Tables["MyFilesTable"].Rows[delIndex].Delete();
                    Console.WriteLine($"-- ChangeDataset/MyFilesTable: {delIndex} deleted");
                }

                DataRow row0 = dataSet.Tables["MyFilesTable"].Rows[0];
                row0[dataSet.Tables["MyFilesTable"].Columns["ModifiedAt"].Ordinal] = DateTime.Now;
                Console.WriteLine($"-- ChangeDataset/MyFilesTable: 0 ModifiedAt changed");
            }

        }
        protected static void DisplayExtendedProperties()
        {
            Console.WriteLine();
            Console.WriteLine("----");
            Console.WriteLine("-- DisplayExtendedProperties");
            foreach (DictionaryEntry item in dataSet.ExtendedProperties)
            {
                //Console.WriteLine(item.ToString());
                Console.WriteLine($"{item.Key} = {item.Value}");

            }
            Console.WriteLine("----");
        }

        protected static void DisplayDataset()
        {
            Console.WriteLine();
            Console.WriteLine("----");
            Console.WriteLine("-- DisplayDataset");
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine($"-- table: {table.TableName}");
                for (int curRowIndex = 0; curRowIndex < table.Rows.Count; curRowIndex++)
                {
                    Console.WriteLine($"-- curRowIndex: {curRowIndex}");
                    DataRow curRow = table.Rows[curRowIndex];
                    for (int curColIndex = 0; curColIndex < table.Columns.Count; curColIndex++)
                    {
                        // Вывод текущей строки через "ToString" двумя эквивалентными способами
                        //Console.WriteLine(filesTable.Rows[curRowIndex][curColIndex].ToString() + "\t");
                        //Console.WriteLine(curRow[curColIndex].ToString() + "\t");

                        var curColValue = curRow[curColIndex];
                        DataColumn coolumnInfo = table.Columns[curColIndex];
                        Console.WriteLine($"{coolumnInfo.ColumnName}: {curColValue}");
                    }
                }
            }
            
            Console.WriteLine("----");
        }
    }
}
