using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntetiesData;
using System.Transactions;


class Program
{
    static void PlaceNewOrder(string customerId,int employeeId,Order_Detail[] details)
    {
        using (NorthwindEntities nwDb = new NorthwindEntities())
        {
            using (TransactionScope scope = new TransactionScope())
            {

                Order order = new Order
                {
                    CustomerID = customerId,
                    EmployeeID = employeeId,
                    ShipVia = 1,
                    ShipName = "UnknownShip",
                    ShipAddress = "UnknownAddress",
                    ShipCity = "Unknown",
                    ShipRegion = "Unknown",
                    ShipPostalCode = "121311",
                    ShipCountry = "Unknown",
                    Order_Details = details

                };

                nwDb.Orders.Add(order);
                nwDb.SaveChanges();

                scope.Complete();
            }
        }
    }

    static void Main()
    {

        PlaceNewOrder("ANTON", 1, new Order_Detail[]{
                    new Order_Detail()
                    {                       
                        ProductID = 1,
                        UnitPrice = 12m,
                        Quantity = 10,
                        Discount = 1
                    },
                    new Order_Detail()
                    {                      
                        ProductID = 12,
                        UnitPrice = 12m,
                        Quantity = 10,
                        Discount = 1
                    },
            });


    }
}

