using System;
using NorthwindEntetiesData;
using System.Linq;

class Program
{
    static void Main()
    {
        using (NorthwindEntities nordwindEnteties = new NorthwindEntities())
        {
            var customerSupplier =
            from customer in nordwindEnteties.Customers
            join order in nordwindEnteties.Orders
            on customer.CustomerID equals order.CustomerID
            select new
            {
                CustomerName = customer.CompanyName,
                OrderShippedDate = order.ShippedDate,
                ShipCountry = order.ShipCountry
            };
            foreach (var customer in customerSupplier.Where(x=> x.OrderShippedDate>new DateTime(1997,1,1)&&
                x.OrderShippedDate< new DateTime(1997,12,31) && x.ShipCountry=="Canada"))
            {
                Console.WriteLine(customer.CustomerName);
            }
            
        }
        
    }
}

