using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SqlSupermarketModel;


public static class MySqlController
{
    public static ICollection<SqlSupermarketModel.Product> GetProducts()
    {
        SupermarketEntitiesModel super = new SupermarketEntitiesModel();
        var mySqlProducts = super.Products.ToList();
        ICollection<SqlSupermarketModel.Product> sqlProducts = new List<SqlSupermarketModel.Product>();

        foreach (var item in mySqlProducts)
        {
            var product = new SqlSupermarketModel.Product()
            {
                ID = item.ID,
                Product_Name = item.Product_Name,
                Base_Price = item.Base_Price,
                mesures_ID = item.Measures_ID,
                vendors_ID = item.Vendors_ID
            };

            sqlProducts.Add(product);
        }


        return sqlProducts;
    }

    public static ICollection<SqlSupermarketModel.Mesure> GetMesures()
    {
        SupermarketEntitiesModel super = new SupermarketEntitiesModel();
        var mySqlMesures = super.Measures.ToList();
        ICollection<SqlSupermarketModel.Mesure> sqlMesures = new List<SqlSupermarketModel.Mesure>();

        foreach (var item in mySqlMesures)
        {
            var mesure = new SqlSupermarketModel.Mesure()
            {
                ID = item.ID,
                Mesure_Name = item.Measure_Name
            };

            sqlMesures.Add(mesure);
        }

        return sqlMesures;
    }

    public static ICollection<SqlSupermarketModel.Vendor> GetVendors()
    {
        SupermarketEntitiesModel super = new SupermarketEntitiesModel();
        var mySqlVendors = super.Vendors.ToList();

        ICollection<SqlSupermarketModel.Vendor> sqlVendors = new List<SqlSupermarketModel.Vendor>();

        foreach (var item in mySqlVendors)
        {
            var vendor = new SqlSupermarketModel.Vendor()
            {
                ID = item.ID,
                VendorName = item.Vendor_Name
            };

            sqlVendors.Add(vendor);
        }

        return sqlVendors;
    }
}

