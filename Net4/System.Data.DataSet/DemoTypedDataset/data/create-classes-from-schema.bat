@rem https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/generating-strongly-typed-datasets

@rem https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe
@rem Формат классов на выходе:
@rem /c[lasses] 	Создает классы, соответствующие указанной схеме. 
@rem                Чтобы считать данные XML в объект, используйте метод XmlSerializer.Deserialize.
@rem /d[ataset] 	Создает классы, которые являются производными класса DataSet и соответствуют указанной схеме. 
@rem                Чтобы считать данные XML в производный класс, используйте метод DataSet.ReadXml.
@rem 
@rem /enableDataBinding 	Реализует интерфейс INotifyPropertyChanged для всех созданных типов для обеспечения привязки данных. 
@rem                        Краткая форма: /edb.
@rem /enableLinqDataSet 	(Короткая форма: /eld.) Указывает, что созданный набор данных можно запрашивать с помощью LINQ to DataSet. 
@rem                        Этот параметр используется только при указании параметра /dataset. 
@rem                        Дополнительные сведения см. в разделах Общие сведения о LINQ to DataSet и Запрос к типизированным объектам DataSet. 
@rem                        Общие сведения об использовании LINQ см. в разделе LINQ — C# или LINQ — Visual Basic.
@rem 

@rem --------------------------------------------------------------------------

@rem c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\xsd.exe
@rem c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe
@rem path "%PATH%;c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\"
@rem path "%PATH%;c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\"
copy c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\xsd.exe .\xsd.exe

@rem --------------------------------------------------------------------------


@rem BooksSchema.xml >> BooksSchema.xsd
xsd.exe BooksSchema.xml
@rem BooksSchema.xsd >> BooksSchema.cs
@rem xsd.exe /classes BooksSchema.xsd
xsd.exe /classes BooksSchema.xsd /n:DemoTypedDataset.BooksClasses
move BooksSchema.cs BooksClasses.cs

xsd.exe /dataset BooksSchema.xsd /enableLinqDataSet /namespace:DemoTypedDataset.BooksDataset
move BooksSchema.cs BooksDataset.cs

@rem --------------------------------------------------------------------------


@rem csc.exe /t:library XSDSchemaFileName.cs /r:System.dll /r:System.Data.dll  