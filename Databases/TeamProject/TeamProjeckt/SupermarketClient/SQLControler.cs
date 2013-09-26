using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteModel;
using SqlSupermarketModel;


public static class SQLControler
{
    public static void WriteProducts(ICollection<Product> products)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Products.Select(x => x.ID).ToList();

            foreach (var product in products)
            {
                if (!ids.Contains(product.ID))
                {
                    sqlDB.Products.Add(product);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteMesures(ICollection<Mesure> mesures)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Mesures.Select(x => x.ID).ToList();
            foreach (var mesure in mesures)
            {
                if (!ids.Contains(mesure.ID))
                {

                    sqlDB.Mesures.Add(mesure);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteVendors(ICollection<Vendor> vendors)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Vendors.Select(x => x.ID).ToList();

            foreach (var vendor in vendors)
            {
                if (!ids.Contains(vendor.ID))
                {
                    sqlDB.Vendors.Add(vendor);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteSellsReports(ICollection<SellsReport> reports)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.SellsReports.Select(x => x.ID).ToList();

            foreach (var report in reports)
            {
                if (!ids.Contains(report.ID))
                {
                    sqlDB.SellsReports.Add(report);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static IEnumerable<XmlReport> GetDataForXmlReport()
    {
        using (supermarketEntities sqlDb = new supermarketEntities())
        {
            string query =
                "select VendorName, FromDate, SUM(Quantity * UnitPrice) as Sum from SellsReport s " +
                "inner join Products p on s.ProductID = p.ID " +
                "inner join Vendors v on p.vendors_ID = v.ID " +
                "group by VendorName, FromDate " +
                "order by VendorName";
            var objects = sqlDb.Database.SqlQuery<XmlReport>(query);

            return objects.ToList();
        }
    }

    public static void WriteVendorExpenses(ICollection<Expenses> expenses)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Expenses.Select(x => x.ID).ToList();

            foreach (var expens in expenses)
            {
                if (!ids.Contains(expens.ID))
                {
                    sqlDB.Expenses.Add(expens);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteSQLiteTotalReport(ICollection<Mongo.Report> reports)
    {
        var sqLiteDb = new SQLiteEntities();

        foreach (var product in reports)
        {
            SQLiteModel.ProductsReport sqlProduct = new ProductsReport();

            sqlProduct.Vendor_Name = product.VendorName;
            sqlProduct.Incomes = product.Incomes;
            sqlProduct.Expenses = product.Expenses;
            sqlProduct.Taxes = product.Taxes;
            sqlProduct.Financial_Result = product.FinancialResult;

            sqLiteDb.ProductsReports.Add(sqlProduct);
        }

        sqLiteDb.SaveChanges();
    }
}

