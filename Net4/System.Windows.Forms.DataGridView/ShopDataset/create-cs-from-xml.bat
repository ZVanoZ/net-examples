@rem https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/dataset-datatable-dataview/generating-strongly-typed-datasets

@rem https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe
@rem ������ ������� �� ������:
@rem /c[lasses] 	������� ������, ��������������� ��������� �����. 
@rem                ����� ������� ������ XML � ������, ����������� ����� XmlSerializer.Deserialize.
@rem /d[ataset] 	������� ������, ������� �������� ������������ ������ DataSet � ������������� ��������� �����. 
@rem                ����� ������� ������ XML � ����������� �����, ����������� ����� DataSet.ReadXml.
@rem 
@rem /enableDataBinding 	��������� ��������� INotifyPropertyChanged ��� ���� ��������� ����� ��� ����������� �������� ������. 
@rem                        ������� �����: /edb.
@rem /enableLinqDataSet 	(�������� �����: /eld.) ���������, ��� ��������� ����� ������ ����� ����������� � ������� LINQ to DataSet. 
@rem                        ���� �������� ������������ ������ ��� �������� ��������� /dataset. 
@rem                        �������������� �������� ��. � �������� ����� �������� � LINQ to DataSet � ������ � �������������� �������� DataSet. 
@rem                        ����� �������� �� ������������� LINQ ��. � ������� LINQ � C# ��� LINQ � Visual Basic.
@rem 

@rem --------------------------------------------------------------------------

@rem c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\xsd.exe
@rem c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe
@rem path "%PATH%;c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\"
@rem path "%PATH%;c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\"
copy "c:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\x64\xsd.exe" .\xsd.exe

@rem --------------------------------------------------------------------------

xsd.exe /dataset ShopSchema.xsd /enableLinqDataSet /enableDataBinding /namespace:ShopSchema
@rem move ShopSchema.cs ShopSchemaDataset.cs

@rem --------------------------------------------------------------------------
