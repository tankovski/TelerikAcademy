using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntetiesData;


class Program
{
    static void Main()
    {
        using (NorthwindEntities northwindEnteties = new NorthwindEntities())
        {
            string nativeQuery =
            "Select * from Employees e  "+
            "JOIN EmployeeTerritories et " +
            "ON e.EmployeeID = et.EmployeeID " +
            "JOIN Territories t " +
            "ON t.TerritoryID = et.TerritoryID";

            var customers = northwindEnteties.Database.SqlQuery<EmployeeExtend>(nativeQuery);

            foreach (var customer in customers)
            {
                Console.WriteLine("{0} {1} from {2}",customer.FirstName,customer.LastName,customer.TerritoryDescription);
            }

        }
    }
}

