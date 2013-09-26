using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{

    static void TransferProducts()
    {
        SQLControler.WriteProducts(MySqlController.GetProducts());
    }

    static void TransferMesures()
    {
        SQLControler.WriteMesures(MySqlController.GetMesures());
    }

    static void TransferVendors()
    {
        SQLControler.WriteVendors(MySqlController.GetVendors());
    }

    static void TransferReportsFromExcel()
    {
        SQLControler.WriteSellsReports(ZipReader.ReadFromRar());
    }

    static void TransferDataFromMySqlToSql()
    {
        TransferMesures();
        TransferVendors();
        TransferProducts();
    }

    static void WriteReportFromSqlToXmlFile()
    {
        XmlController.WriteXmlReport(SQLControler.GetDataForXmlReport());
    }

    static void WriteVendorExpensesFromXmlToSql()
    {
        SQLControler.WriteVendorExpenses(XmlController.ReadExpensesFromXml());
    }

    static void WriteExcelReport()
    {
        var totalReport = Mongo.ReadTotalReport();
        ExcelController.WriteExcelReports(totalReport);
        SQLControler.WriteSQLiteTotalReport(totalReport);
    }

    static void Main()
    {
        Console.Write("Transfering data from mySQL to SQL Server Database... ");
        TransferDataFromMySqlToSql();
        Console.WriteLine("Succesfull!");

        Console.Write("Transfering data from Excel to SQL Server Database... ");
        TransferReportsFromExcel();
        Console.WriteLine("Succesfull!");

        Console.Write("Writing report to XML file... ");
        WriteReportFromSqlToXmlFile();
        Console.WriteLine("Succesfull!");

        Console.Write("Writing report to Pdf file...");
        PdfController.GeneratePdfReports();
        Console.WriteLine("Succesfull!");

        Console.Write("Saving Sales Reports to MongoDB... ");
        Mongo.SaveReportToMongoDB();
        Console.WriteLine("Succesfull!");

        Console.Write("Saving Vendor Expenses from XML to SQL server...");
        WriteVendorExpensesFromXmlToSql();
        Console.WriteLine("Succefull!");

        Console.Write("Saving XML to MongoDB... ");
        Mongo.XmlToMongoDB();
        Console.WriteLine("Succesfull!");

        Console.Write("Writing Excel and SQLite Total report... ");
        WriteExcelReport();
        Console.WriteLine("Succesfull!");
    }
}

