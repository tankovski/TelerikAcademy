using NameAndDescriptionOfAllCategories.Properties;
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
            SqlCommand cmdGetAllNamesAndDescriptions = new SqlCommand(
                "SELECT CategoryName,Description FROM Categories", dbCon);
            SqlDataReader reader = cmdGetAllNamesAndDescriptions.ExecuteReader();
            Console.WriteLine("The categoryes are:");
            int counter = 1;
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string categoryDescription = (string)reader["Description"];
                    Console.WriteLine("{0}.{1} - {2}", counter, categoryName, categoryDescription);
                    counter++;
                }
            }
        }
    }
}

