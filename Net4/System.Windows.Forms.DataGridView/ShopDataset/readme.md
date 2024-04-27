# ShopDataset 

Содержит файлы для генерации типизированного набора классов DataSet.  
При помощи [create-cs-from-xml.bat](create-cs-from-xml.bat) генерируем [ShopSchema.cs](ShopSchema.cs) на основании [ShopSchema.xsd](ShopSchema.xsd)
[ShopSchema.xsd](ShopSchema.xsd) Редактируется при помощи графического редактора Visual Studio.

## Ссылки

* [Практическое руководство. Добавление столбцов в объект DataTable](https://learn.microsoft.com/ru-ru/previous-versions/0c5wf85e(v=vs.140))
* [Практическое руководство. Создание объектов DataRelation с помощью конструктора набора данных](https://learn.microsoft.com/ru-ru/previous-versions/ms171912(v=vs.140))
  * [Практическое руководство. Разделение наборов данных и адаптеров таблиц на разные проекты](https://learn.microsoft.com/ru-ru/previous-versions/bb384586(v=vs.140))

## Глюки графического редактора

Редактор не очень удобный и имеет ряд глюков.
* Создать корректное реляционное отношение можно только перетягиванием пиктограммы "Relation" на дочернюю таблицу.  
Иначе слетает тип данных и автоинкремент в главной таблице.  
Инструкция тут [Практическое руководство. Создание объектов DataRelation с помощью конструктора набора данных/Чтобы создать отношение между двумя таблицами DataTables](https://learn.microsoft.com/ru-ru/previous-versions/ms171912(v=vs.140)?f1url=%3FappId%3DDev17IDEF1%26l%3DRU-RU%26k%3Dk(vs.datasource.RealtionBuilder)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%253Dv4.8)%26rd%3Dtrue)
