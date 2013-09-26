using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class ExcelController
{
    public static void WriteExcelReports(ICollection<Mongo.Report> reports)
    {
        if (File.Exists("../../../Products-Total-Report.xls"))
        {
            File.Delete("../../../Products-Total-Report.xls");
        }

        using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../../../Products-Total-Report.xls;Extended Properties='Excel 8.0;HDR=Yes'"))
        {
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("CREATE TABLE [Sheet1] ([Vendor] string, [Incomes] string,[Expenses] string," +
            " [Taxes] string, [FinancialResult] string)", conn);
            cmd.ExecuteNonQuery();


            conn.Close();
            conn.Open();
            foreach (var item in reports)
            {
                string vendor = item.VendorName;
                decimal incomes = item.Incomes;
                decimal expenses = item.Expenses;
                decimal taxes = item.Taxes;
                decimal finansualResult = item.FinancialResult;

                OleDbCommand insertCmd = new OleDbCommand(@"INSERT INTO [Sheet1$] (Vendor, Incomes,Expenses,Taxes,FinancialResult) VALUES " +
                    "(@Vendor, @Incomes,@Expenses,@Taxes,@FinancialResult)", conn);
                insertCmd.Parameters.AddWithValue("@Vendor", vendor);
                insertCmd.Parameters.AddWithValue("@Incomes", incomes);
                insertCmd.Parameters.AddWithValue("@Expenses", expenses);
                insertCmd.Parameters.AddWithValue("@Taxes", taxes);
                insertCmd.Parameters.AddWithValue("@FinancialResult", finansualResult);

                insertCmd.ExecuteNonQuery();
            }


        }


    }
}

