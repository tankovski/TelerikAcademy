using RetrivesNumberOfRows.Properties;
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
            SqlCommand cmdCountRows = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
            int rowsCount = (int)cmdCountRows.ExecuteScalar();
            Console.WriteLine("The number of rows in Categories table is "+rowsCount);
        }
    }
}

