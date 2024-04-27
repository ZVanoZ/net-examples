<hr>
# О проекте

Примеры для .NET 6.0 

<hr>

## Мануалы

* learn.microsoft.com : csharp
  * [Документация по языку C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/)  
    * [Ключевые слова C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/) dictionary
    * [Asynchronous programming with async and await](https://learn.microsoft.com/ru-ru/dotnet/csharp/asynchronous-programming/) manual
* learn.microsoft.com : dotnet
  * [Инструмент определения схемы XML (Xsd.exe)](https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe)
* learn.microsoft.com : API .NET 4.8
  * [System.Data](https://learn.microsoft.com/ru-ru/dotnet/api/system.data?view=netframework-4.8) namespace
    * [System.Data.DataSet](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.dataset?view=netframework-4.8) class 
      * [Типизированные наборы данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/typed-datasets) manual
        * [Создание строго типизированных наборов данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/generating-strongly-typed-datasets)  
          ??? Непонятно. При помощи xsd.exe на основании файла *.xsd генерируется *.cs с набором классов. 
    * [System.Data.DataTable](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.datatable?view=netframework-4.8) class 
* learn.microsoft.com : API .NET 8 
  * [System.Threading](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading?view=net-8.0) namespace
    * [System.Threading.ThreadState](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.threadstate?view=net-8.0) enum
  * [System.IO](https://learn.microsoft.com/ru-ru/dotnet/api/system.io?view=net-8.0) namespace
    * [System.IO.FileSystemWatcher](https://learn.microsoft.com/ru-ru/dotnet/api/system.io.filesystemwatcher?view=net-8.0) class

* [Работа с БД/DataSet](https://professorweb.ru/my/ADO_NET/base/level2/2_1.php)

<hr>

## Примеры кода:

* https://github.com/dotnet/samples.git
````
Куча всяких примеров. Компоненты конфигурируются в коде, а не визуальным редактором.

DataGridView
* windowsforms\datagridview\CSWinFormDataGridView\EditingControlHosting\
Пример привязки контрола для редактирования ячейки грида.

Использование компонент из пакетов "C1.*" (платные).
* windowsforms/FlexGridShowcaseDemo/cs/
Навороченный грид на базе компонента C1.Win.FlexGrid.C1FlexGrid
````
* 
