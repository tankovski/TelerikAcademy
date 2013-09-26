using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSupermarketModel;
using System.Linq;
using System.Xml;
using System.Threading;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

           // File.Delete("../../../Products-Total-Report.xls");
            //using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../../../Products-Total-Report.xls;Extended Properties='Excel 8.0;HDR=Yes'"))
            //{
            //    conn.Open();
            //    try
            //    {
            //        OleDbCommand cmd = new OleDbCommand("CREATE TABLE [Sheet1] ([Vendor] string, [Incomes] string,[Expenses] string, [Taxes] string, [Financial Result] string)", conn);
            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception)
            //    {
                    
            //    }


           // List<int> list = new List<int>();

           //list = list.Intersect(new List<int>{1,2}).ToList();


           // //}

           // Application app = new Application();
            

           // Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
           // Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
           // Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
           // worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
           // worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
           // worksheet.Name = "Exported from DataTable";
            
           // System.Data.DataTable table = new System.Data.DataTable();

           // table.Columns.Add("Dosage", typeof(int));
           // table.Columns.Add("Drug", typeof(string));
           // table.Columns.Add("Patient", typeof(string));
           // table.Columns.Add("Date", typeof(DateTime));

           // //
           // // Here we add five DataRows.
           // //
           // table.Rows.Add(25, "Indocin", "David", DateTime.Now);
           // table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
           // table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
           // table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
           // table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now); ;
           // for (int i = 0; i < table.Rows.Count; i++)
           // {
           //     for (int j = 0; j < table.Columns.Count; j++)
           //     {
           //         worksheet.Cells[i+1, j+1] = table.Rows[i][j].ToString();
           //         worksheet.Cells[i+1, j+2].Borders.Color =
           //         System.Drawing.Color.Black.ToArgb();                 
           //     }
           // }

           //  //var workSheet_range = worksheet.get_Range("B5", "B10");
           // //workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
           // //worksheet.Cells[1, 3].Borders.Color =
           // //System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
           // workbook.SaveAs("../FileNamePath2.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
           // app.Quit();
            //Application excel = new Application();
            //excel.Visible = true;


            //Workbook wb = excel.Workbooks.Open("../../../Products-Total-Report.xls");


            //Worksheet sh = wb.Sheets.Add();

            //sh.Cells.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); 
            
            //sh.Name = "TestSheet";
            //sh.Cells[1, "A"].Value2 = "SNO";
            //sh.Cells[2, "B"].Value2 = "A";
            //sh.Cells[2, "C"].Value2 = "1122";
            //wb.Close(true);
            //excel.Quit();
        }
    }
}
