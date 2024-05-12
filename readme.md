<hr>

# О проекте

Примеры для .NET Разных версий 

<hr>

## Содержание

* [Net4](Net4)
  * [LINQ](Net4%2FLINQ)  
    Эксперименты с языком запросов.
  * [System.Data.DataSet](Net4%2FSystem.Data.DataSet)
    ````
    Учимся работать с чистым DataSet без визуальных компонент.
    ````
  * [System.Windows.Forms.DataGridView](Net4%2FSystem.Windows.Forms.DataGridView)
    * [DemoShopDataset](Net4%2FSystem.Windows.Forms.DataGridView%2FDemoShopDataset)
      ````
      Демонстрация использования System.Windows.Forms.DataGridView с биндингом схемы из связанного проекта ShopDataset.
        
      @TODO:                                                                       
      -------------------------------------------------------------------------------------
       Статус      : Задача                                                              
      ------------------------------------------------------------------------------------
       Выполнено   : Создать типизированную схему данных. 
       Выполнено   : Связать экземпляр схемы данных с компонентами DataGridView.
       Выполнено   : Сделать экспорт/импорт данных (файл XML). 
       Выполнено   : Сделать очистку shopDataSet от данных.
       В работе    : Написать GUI интерфейс для наполнения данными shopDataSet.   
                   : Сделать выборку данных с фильтрацией и сортировкой при помощи LINQ.
                   : Сделать связанные гриды с фильтрацией при смене активной строки. 
      -------------------------------------------------------------------------------------
      ````
    * [ShopDataset](Net4%2FSystem.Windows.Forms.DataGridView%2FShopDataset)  
      Типизированная схема данных для [DemoShopDataset](Net4%2FSystem.Windows.Forms.DataGridView%2FDemoShopDataset)

<hr>

## Мануалы

### learn.microsoft.com : dotnet/csharp

* [Документация по языку C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/)  
  ([dotnet-csharp.pdf](https://learn.microsoft.com/pdf?url=https%3A%2F%2Flearn.microsoft.com%2Fru-ru%2Fdotnet%2Fcsharp%2Ftoc.json) ~37МБ)
  * [Ключевые слова C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/) dictionary
  * [Asynchronous programming with async and await](https://learn.microsoft.com/ru-ru/dotnet/csharp/asynchronous-programming/) manual
* [Синтаксис LINQ](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/)
  * https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/get-started/write-linq-queries
  * https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/get-started/walkthrough-writing-queries-linq
  * [Join Операции в LINQ](https://learn.microsoft.com/ru-ru/dotnet/csharp/linq/standard-query-operators/join-operations)
 
### learn.microsoft.com : dotnet/standard

* [Инструмент определения схемы XML (Xsd.exe)](https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe)
* [Доступ к данным в .NET](https://learn.microsoft.com/ru-ru/dotnet/navigate/data-access/)
  * Microsoft.Data.Sqlite
    * [Sqlite/Общие сведения о Microsoft.Data.Sqlite](https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/?tabs=netcore-cli)
    * [Sqlite/Строки подключения](https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/connection-strings)
    * [Sqlite/Базы данных в памяти](https://learn.microsoft.com/ru-ru/dotnet/standard/data/sqlite/in-memory-databases)
   
### learn.microsoft.com : dotnet/framework/data

* https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/queries-in-linq-to-dataset
* [Использование XML в наборах данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset) раздел
* [Наборы данных, таблицы данных и объекты DataView](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/) раздел
* [Типизированные наборы данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/typed-datasets) manual
  * [Создание строго типизированных наборов данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/generating-strongly-typed-datasets)
* [Запросы в LINQ to DataSet](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/queries-in-linq-to-dataset)
* Запросы к DataSet
  * [Запросы к наборам данных (LINQ to DataSet)](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/querying-datasets-linq-to-dataset)
  * [Запросы к одной таблице (LINQ to DataSet)](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/single-table-queries-linq-to-dataset)
  * [Запросы между таблицами (LINQ to DataSet)](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/cross-table-queries-linq-to-dataset)
  * [Запросы к типизированным наборам данных](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/querying-typed-datasets)
  * [Привязка данных и LINQ to DataSet](https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/data-binding-and-linq-to-dataset)

### .NET 4

* "\Learn\.NET\winforms" - Руководство по рабочему столу .NET для Windows Forms  
[Скачать PDF\dotnet-desktop-winforms-netframeworkdesktop-4.8.pdf](https://learn.microsoft.com/pdf?url=https%3A%2F%2Flearn.microsoft.com%2Fru-ru%2Fdotnet%2Fdesktop%2Fwinforms%2Ftoc.json%3Fview%3Dnetframeworkdesktop-4.8)
* [System.Data](https://learn.microsoft.com/ru-ru/dotnet/api/system.data?view=netframework-4.8) namespace
  * [System.Data.DataSet](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.dataset?view=netframework-4.8) class
  * [System.Data.DataTable](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.datatable?view=netframework-4.8) class
* System.Windows.Forms
  * [System.Windows.Forms.BindingSource](https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.forms.bindingsource?view=netframework-4.8) class
  * [System.Windows.Forms.OpenFileDialog](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=netframework-4.8) class
  * [System.Windows.Forms.SaveFileDialog](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?view=netframework-4.8) class

* Элементы управления для использования в Windows Forms
  * [Практическое руководство. Совместное использование одних и тех же данных в нескольких формах посредством компонента BindingSource](https://learn.microsoft.com/ru-ru/dotnet/desktop/winforms/controls/how-to-share-bound-data-across-forms-using-the-bindingsource-component?view=netframeworkdesktop-4.8)

### .NET 8

* [System.IO](https://learn.microsoft.com/ru-ru/dotnet/api/system.io?view=net-8.0) namespace
  * [System.IO.FileSystemWatcher](https://learn.microsoft.com/ru-ru/dotnet/api/system.io.filesystemwatcher?view=net-8.0) class
* [System.Threading](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading?view=net-8.0) namespace
  * [System.Threading.ThreadState](https://learn.microsoft.com/ru-ru/dotnet/api/system.threading.threadstate?view=net-8.0) enum

### Visual Studio

* [Индекс/Документация по интегрированной среде разработки Visual Studio](https://learn.microsoft.com/ru-ru/visualstudio/ide/?view=vs-2022)
  [Скачать PDF\visualstudio-vs-2022.pdf](https://learn.microsoft.com/pdf?url=https%3A%2F%2Flearn.microsoft.com%2Fru-ru%2Fvisualstudio%2Ftoc.json%3Fview%3Dvs-2022)
```text
Слева снизу есть кнопка "Скачать PDF".
Жамкаем и получаем оффлайн версию размером около 120МБ 
```
* [Сочетания клавиш в Visual Studio](Сочетания клавиш в Visual Studio)
* [Панель инструментов](https://learn.microsoft.com/ru-ru/visualstudio/ide/reference/toolbox?view=vs-2022)
```
Справочные материалы
Вкладка "Компоненты", панель элементов
Панель элементов, вкладка "Данные"
Вкладка HTML, панель элементов
```
* [Справочные материалы\Общие элементы пользовательского интерфейса\Вставка JSON или XML в качестве классов](https://learn.microsoft.com/ru-ru/visualstudio/ide/reference/paste-json-xml?view=vs-2022)
* [Learn\Visual Studio\Работа с данными\Работа с данными в Visual Studio](https://learn.microsoft.com/ru-ru/visualstudio/data-tools/accessing-data-in-visual-studio?view=vs-2022)
  [Скачать PDF\visualstudio-data-tools-vs-2022.pdf](https://learn.microsoft.com/pdf?url=https%3A%2F%2Flearn.microsoft.com%2Fru-ru%2Fvisualstudio%2Fdata-tools%2Ftoc.json%3Fview%3Dvs-2022)
````
Пошаговое руководство. Создание классов LINQ to SQL с помощью наследования одной таблицы (конструктор O/R)
Наборы данных и XML
Создание базы данных и добавление таблиц в приложениях платформа .NET Framework с помощью Visual Studio
Подключение в базу данных в Visual Studio
Сохранение и изменение строка подключения базы данных для приложений платформа .NET Framework
Добавление новых источников данных в приложениях ADO.NET (платформа .NET Framework)
Инструменты LINQ to SQL в Visual Studio
````
  * [Пошаговое руководство. Создание dataTable для приложений платформа .NET Framework с помощью конструктора наборов данных](https://learn.microsoft.com/ru-ru/visualstudio/data-tools/walkthrough-creating-a-datatable-in-the-dataset-designer?view=vs-2022)  
  ````
  Это руководство позволяет при помощи конструктора создать *.XSD файл с локальной схемой DataSet.
  Почему-то в PDF эта статья отсутствует! Отправил сообщение в форме обратной связи.
  ````
  * 
* [Learn\Visual Studio\XML-инструменты](https://learn.microsoft.com/ru-ru/visualstudio/xml-tools/xml-schema-designer?view=vs-2022)
  [Скачать PDF\visualstudio-xml-tools-vs-2022.pdf](https://learn.microsoft.com/pdf?url=https%3A%2F%2Flearn.microsoft.com%2Fru-ru%2Fvisualstudio%2Fxml-tools%2Ftoc.json%3Fview%3Dvs-2022)
```text

```
* [Работа с наборами данных в Visual Studio](https://learn.microsoft.com/ru-ru/previous-versions/8bw9ksd6(v=vs.140))
* [Практическое руководство. Открытие набора данных в конструкторе наборов данных](https://learn.microsoft.com/ru-ru/previous-versions/7973zb70(v=vs.140))
* [Практическое руководство. Редактирование набора данны](https://learn.microsoft.com/ru-ru/previous-versions/76ah1sx7(v=vs.140))
* [Практическое руководство. Добавление столбцов в объект DataTable](https://learn.microsoft.com/ru-ru/previous-versions/0c5wf85e(v=vs.140))
* [Практическое руководство. Создание объектов DataRelation с помощью конструктора набора данных](https://learn.microsoft.com/ru-ru/previous-versions/ms171912(v=vs.140))
* [Практическое руководство. Разделение наборов данных и адаптеров таблиц на разные проекты](https://learn.microsoft.com/ru-ru/previous-versions/bb384586(v=vs.140))
* [Пошаговое руководство. Отображение данных на форме в приложении Windows](https://learn.microsoft.com/ru-ru/previous-versions/wwh8ka92(v=vs.140))

### Статьи

* [Работа с БД/DataSet](https://professorweb.ru/my/ADO_NET/base/level2/2_1.php)
* [Habr/Синтаксис запросов LINQ — недооцененный инструмент для разработчиков C#](https://habr.com/ru/companies/otus/articles/723438/) 

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
 

<hr>

## Глюки Visual Studio 2022

Редактор XSD.
* Создать корректное реляционное отношение можно только перетягиванием пиктограммы "Relation" на дочернюю таблицу.  
  Иначе слетает тип данных и автоинкремент в главной таблице.  
  Инструкция тут [Практическое руководство. Создание объектов DataRelation с помощью конструктора набора данных/Чтобы создать отношение между двумя таблицами DataTables](https://learn.microsoft.com/ru-ru/previous-versions/ms171912(v=vs.140)?f1url=%3FappId%3DDev17IDEF1%26l%3DRU-RU%26k%3Dk(vs.datasource.RealtionBuilder)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%253Dv4.8)%26rd%3Dtrue)
* Обновление информации о перегенерированной схеме DataSet происходит только если переоткрыть Visual Studiom  
