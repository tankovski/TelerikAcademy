using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntetiesData;
using System.Data.Objects;


    class Program
    {
        static void Main()
        {
            using (NorthwindEntities northwindEnteties = new NorthwindEntities())
            {
                var person = northwindEnteties.Employees.FirstOrDefault(e => e.EmployeeID == 11);
                person.FirstName = "AAAAA";

                northwindEnteties.SaveChanges();
            }

            using (SecondContext.SecondContextEntities northwindEnteties2 = new SecondContext.SecondContextEntities())
            {
                var person = northwindEnteties2.Employees.FirstOrDefault(e => e.EmployeeID == 11);
                person.FirstName = "DDDD";
                northwindEnteties2.SaveChanges();
            }


        }
    }

