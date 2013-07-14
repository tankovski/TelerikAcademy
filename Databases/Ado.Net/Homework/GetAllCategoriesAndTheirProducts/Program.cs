using GetAllCategoriesAndTheirProducts.Properties;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBNorthwindConectionString);
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdAllCategoryesAndProducts = new SqlCommand(
             "SELECT c.CategoryName,p.ProductName FROM Categories c JOIN Products p ON"+
             " c.CategoryID=p.CategoryID ORDER BY c.CategoryName", dbCon);
            SqlDataReader reader = cmdAllCategoryesAndProducts.ExecuteReader();
            int counter = 1;
            using (reader)
            {
                while (reader.Read())
                {
                    string categorieName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0}.{1} - {2}", counter, categorieName,productName);
                    counter++;
                }
            }
        }
    }
}

