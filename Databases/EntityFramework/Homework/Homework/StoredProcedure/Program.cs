using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindEntetiesData;
using System.Data.Objects;

namespace StoredProcedure
{
    class Program
    {
        static decimal FindSupplierIncomesForPeriodOfTime(string name, DateTime startDate, DateTime endDate)
        {
            using (NorthwindEntities nwDb = new NorthwindEntities())
            {
                var outputParameter = new ObjectParameter("result", typeof(decimal));
                nwDb.FindTotalSupplierIncomes(name,startDate,endDate, outputParameter);
                return decimal.Parse(outputParameter.Value.ToString());
            }
        }
        static void Main()
        {

          decimal incomes =  FindSupplierIncomesForPeriodOfTime("Antonio del Valle Saavedra", new DateTime(1997, 01, 01),
                    new DateTime(1998, 01, 01));
          Console.WriteLine(incomes);
           
        }
    }
}
