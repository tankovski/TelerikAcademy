using FindProductsThatContainString.Properties;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace FindProductsThatContainString
{
    class Program
    {
        static void Main(string[] args)
        {
            string containingStr = Console.ReadLine();
            SqlConnection dbCon = new SqlConnection(Settings.Default.DBNorthwindConectionString);
            containingStr = Regex.Replace(containingStr, "([#_%'\"\\\\])", "#$1");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdGetProducts = new SqlCommand("SELECT ProductName AS Names FROM Products WHERE ProductName LIKE '%" + containingStr + "%' ESCAPE '#'", dbCon);
                SqlDataReader reader = cmdGetProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Names"];
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
