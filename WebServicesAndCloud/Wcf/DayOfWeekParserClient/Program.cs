using DayOfWeekParserClient.ServiceReference1;
using System;
namespace DayOfWeekParserClient
{
    class Program
    {
        static void Main()
        {
          
            ServiceParserClient calculatorClient = new ServiceParserClient();          
            string result = calculatorClient.GetDayOfWeek(DateTime.Now);

            System.Console.WriteLine("The day of week is: " + result);

            
        }
    }
}
