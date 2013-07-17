using System;
using NorthwindEntetiesData;
using System.Linq;



class Program
{
    static void Main()
    {
        using (NorthwindEntities northwindEnteties = new NorthwindEntities())
        {
            string nativeQuery =
                "SELECT c.CompanyName FROM Customers c " +
                "JOIN Orders e " +
                "ON e.CustomerID=c.CustomerID " +
                "WHERE e.ShippedDate > '01/01/1997' " +
                "AND e.ShippedDate < '12/31/1997' " +
                "AND e.ShipCountry = 'Canada'";

            var customers = northwindEnteties.Database.SqlQuery<string>(nativeQuery);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

        }
    }
}

