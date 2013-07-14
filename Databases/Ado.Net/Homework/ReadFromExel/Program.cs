using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

class ReadFromExcel
{
    static void Main()
    {
        DataTable dt = new DataTable("newtable");
       
        using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../task.xlsx;Extended Properties=Excel 12.0;"))
        {
            connection.Open();
            string selectSql = @"SELECT * FROM [Sheet1$]";
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
            {
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            connection.Close();
        }

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine(row.ItemArray[0]+" - " + row.ItemArray[1]);
        }
    }
}