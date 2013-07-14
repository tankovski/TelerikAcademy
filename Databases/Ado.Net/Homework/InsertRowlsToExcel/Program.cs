using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

class Program
{
    static void Main()
    {
        using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../task.xlsx;Extended Properties=Excel 12.0;"))
        {
            string insertToTable = @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score)";
            using (OleDbCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = insertToTable;
                command.Parameters.AddWithValue("@Name", "Iliq");
                command.Parameters.AddWithValue("@Score", 19);
                command.ExecuteNonQuery();
            }
        }
    }
}

