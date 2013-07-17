using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NorthwindEntetiesData;
using System.Data.Entity.Infrastructure;

class Program
{
    static void Main(string[] args)
    {
        NorthwindEntities objectContext = new NorthwindEntities();

        StringBuilder dbScript = new StringBuilder();
        dbScript.Append("USE NorthwindTwin ");

        string generatedScript =
            ((IObjectContextAdapter)objectContext).ObjectContext.CreateDatabaseScript();
        dbScript.Append(generatedScript);
        objectContext.Database.ExecuteSqlCommand("CREATE DATABASE NorthwindTwin");
        objectContext.Database.ExecuteSqlCommand(dbScript.ToString());


    //    using (var db = new NorthWindTwin())
    //    {


    //        Employee employee = new Employee
    //            {
    //                EmployeeID = 12,
    //                FirstName ="Gosho",
    //                LastName="Goshov"
    //            };
    //        db.Employees.Add(employee);
    //        db.SaveChanges();
    //        //// Create and save a new Blog
    //        //Console.Write("Enter a name for a new Blog: ");
    //        //var name = Console.ReadLine();

    //        ////var blog = new Blog { Name = name };
    //        ////db.Blogs.Add(blog);
    //        ////db.SaveChanges();

    //        //// Display all Blogs from the database
    //        ////var query = from b in db.Blogs
    //        ////            orderby b.Name
    //        ////            select b;

    //        //Console.WriteLine("All blogs in the database:");
    //        //foreach (var item in query)
    //        //{
    //        //    Console.WriteLine(item.Name);
    //        //}

    //        //Console.WriteLine("Press any key to exit...");
    //        //Console.ReadKey();
    //    }
    }
}


//public class NorthWindTwin : DbContext
//{
//    public NorthWindTwin()
//        : base("NorthWindTwin")
//    { }
//    public DbSet<User> Users { get; set; }
//    public DbSet<Group> Groups { get; set; }
//    public DbSet<Order_Detail> OrderDetails { get; set; }
//    public DbSet<Product> Products { get; set; }
//    public DbSet<Supplier> Suppliers { get; set; }
//    public DbSet<Employee> Employees { get; set; }
//    public DbSet<Order> Orders { get; set; }
//    public DbSet<Customer> Customers { get; set; }
//    public DbSet<CustomerDemographic> CustomerDemografics { get; set; }
//    public DbSet<Shipper> Shippers { get; set; }
//    public DbSet<Territory> Territories { get; set; }
//    public DbSet<Region> Regions { get; set; }
//}


