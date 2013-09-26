CREATE TABLE [Taxes] (
  [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  [Product_Name] [NVARCHAR(200)] NOT NULL, 
  [Tax] [DOUBLE(0, 2)] NOT NULL);  
CREATE TABLE [ProductsReport] (
  [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  [Vendor_Name] [NVARCHAR(200)] NOT NULL,   
  [Incomes] [DOUBLE(10, 2)] NOT NULL,
  [Expenses] [DOUBLE(10, 2)] NOT NULL,
  [Taxes] [DOUBLE(10, 2)] NOT NULL,
  [Financial Result] [DOUBLE(10, 2)] NOT NULL);  
INSERT INTO [Taxes] ([Product_Name],[Tax]) VALUES ('Beer "Becks"','0.2');
INSERT INTO [Taxes] ([Product_Name],[Tax]) VALUES ('Beer "Zagorka"','0.20');
INSERT INTO [Taxes] ([Product_Name],[Tax]) VALUES ('Chocolate "Milka"','0.18');
INSERT INTO [Taxes] ([Product_Name],[Tax]) VALUES ('Vodka "Targovishte"','0.25');
