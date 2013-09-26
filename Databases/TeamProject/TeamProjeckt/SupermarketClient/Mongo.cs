using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using SQLiteModel;
using SqlSupermarketModel;
using SupermarketModel;

public class Mongo
{
    public class Report
    {
        public string VendorName { get; set; }
        public decimal Incomes { get; set; }
        public decimal Expenses { get; set; }
        public decimal Taxes { get; set; }
        public decimal FinancialResult
        {
            get
            {
                return this.Incomes - this.Expenses - this.Taxes;
            }
        }
    }

    private class ExpensesReport
    {
        public ObjectId Id { get; set; }
        public string vendorName { get; set; }
        public string month { get; set; }
        public decimal expenses { get; set; }
    }

    private class ProductReport
    {
        public ObjectId Id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string vendorName { get; set; }
        public int totalQuantitySold { get; set; }
        public decimal totalIncomes { get; set; }
    }

    private static string jsonFileDestination = @"..\..\..\Products-Reports\";

    private static MongoDatabase mongoDB = ConnectToMongoDB("Supermarket");

    public static ICollection<Report> ReadTotalReport()
    {
        var expensesReports = mongoDB.GetCollection<ExpensesReport>("ExpensesReports").FindAll().ToList();
        var productReports = mongoDB.GetCollection<ProductReport>("ProductReports").FindAll().ToList();
        
        var sqLiteDb = new SQLiteEntities();
        var taxes = sqLiteDb.Taxes;

        IDictionary<string, Report> totalReports = new Dictionary<string, Report>();

        foreach (var r in productReports)
        {
            if (!totalReports.Keys.Contains(r.vendorName))
            {
                totalReports.Add(new KeyValuePair<string, Report>(r.vendorName, new Report()));
                totalReports[r.vendorName].VendorName = r.vendorName;
            }

            totalReports[r.vendorName].Incomes += r.totalIncomes;

            var tax = taxes.Where(x => x.Product_Name == r.productName).First().Tax1;

            totalReports[r.vendorName].Taxes += r.totalIncomes * (decimal)tax;
        }

        foreach (var r in expensesReports)
        {
            totalReports[r.vendorName].Expenses = r.expenses;
        }

        return totalReports.Values.ToList();
    }

    public static void XmlToMongoDB()
    {
        if (!mongoDB.CollectionExists("ExpensesReports"))
        {
            mongoDB.CreateCollection("ExpensesReports");
        }

        MongoCollection expensesReports = mongoDB.GetCollection("ExpensesReports");
        expensesReports.RemoveAll();

        supermarketEntities db = new supermarketEntities();
        var expenses = db.Expenses
            .Include("Expenses")
            .Select(e => new
            {
                vendorName = e.Vendors.VendorName,
                month = e.Mounth,
                expenses = e.Expenses1
            });

        foreach (var e in expenses)
        {
            var bson = e.ToBsonDocument();
            expensesReports.Insert(bson);
        }
    }

    public static void SaveReportToMongoDB()
    {
        if (!mongoDB.CollectionExists("ProductReports"))
        {
            mongoDB.CreateCollection("ProductReports");
        }

        MongoCollection productReports = mongoDB.GetCollection("ProductReports");
        productReports.RemoveAll();

        var products = GenerateJSON().ToList();
        foreach (var product in products)
        {
            var bson = product.ToBsonDocument();
            productReports.Insert(bson);
            SaveToFile(product);
        }
    }

    private static MongoDatabase ConnectToMongoDB(string dbName)
    {
        MongoClient mongoClient = new MongoClient("mongodb://localhost/");
        MongoServer mongoServer = mongoClient.GetServer();
        MongoDatabase mongoDb = mongoServer.GetDatabase(dbName);
        return mongoDb;
    }

    private static IQueryable<object> GenerateJSON()
    {
        supermarketEntities db = new supermarketEntities();

        var products = db.SellsReports
            .Include("Product")
            .Select(r => new
            {
                productId = r.Product.ID,
                productName = r.Product.Product_Name,
                vendorName = r.Product.Vendor.VendorName,
                totalQuantitySold =
                    db.SellsReports
                    .Where(x => x.ProductID == r.ProductID)
                    .Sum(x => x.Quantity),
                totalIncomes =
                    db.SellsReports
                    .Where(x => x.ProductID == r.ProductID)
                    .Sum(x => x.Quantity * x.UnitPrice)
            })
            .Distinct();

        return products;
    }

    private static void SaveToFile(dynamic product)
    {
        try
        {
            DirectoryInfo dir = Directory.CreateDirectory(jsonFileDestination);
            using (StreamWriter output =
                new StreamWriter(jsonFileDestination + product.productId + ".json"))
            {
                output.Write(new JavaScriptSerializer().Serialize(product));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
