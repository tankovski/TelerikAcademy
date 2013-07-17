using System;
using NorthwindEntetiesData;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static List<Order> GetSalesInRegionForPeriodOfTime(string region, DateTime startDate, DateTime endDate)
    {
        using (NorthwindEntities northwindEnteties = new NorthwindEntities())
        {
            var sales = northwindEnteties.Orders.Where(o => o.ShipRegion == region && o.ShippedDate > startDate &&
                o.ShippedDate < endDate).ToList();

            return sales;
        }

    }

    static void Main()
    {
        List<Order> sales = GetSalesInRegionForPeriodOfTime("RJ", new DateTime(1995, 1, 1), new DateTime(2000, 1, 1));
        foreach (var item in sales)
        {
            Console.WriteLine(item.OrderID + " - " + item.ShipRegion + " - " + item.ShippedDate);
        }
    }
}

