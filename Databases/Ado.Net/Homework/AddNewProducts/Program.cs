using AddNewProducts.Properties;
using System;
using System.Data.SqlClient;

class Program
{
    static void InsertProduct(SqlConnection dbCon, string productName, int SupplierID, int CategoryID, string QuantityPerUnit,
        decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued)
    {
        using (dbCon)
        {
            SqlCommand cmdInsertProduct = new SqlCommand(
                "INSERT INTO Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock," +
                "UnitsOnOrder,ReorderLevel,Discontinued)" +
                " VALUES(@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit," +
                "@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", dbCon);

            cmdInsertProduct.Parameters.AddWithValue("@ProductName", productName);
            cmdInsertProduct.Parameters.AddWithValue("@SupplierID", SupplierID);
            cmdInsertProduct.Parameters.AddWithValue("@CategoryID", CategoryID);
            cmdInsertProduct.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
            cmdInsertProduct.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@Discontinued", Discontinued);

            cmdInsertProduct.ExecuteNonQuery();
        }
    }

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBNorthwindConectionString);
        dbCon.Open();
        using (dbCon)
        {
            InsertProduct(dbCon, "TestProduct2", 1, 1, "1", 50M, 1, 1, 1, true);
        }
    }
}

