using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFrom1To12
{
    class GSMCallHistoryTest
    {
        static void Main(string[] args)
        {


            try
            {
                //Create battery and display for the GSM
                Battery battery = new Battery("BL-5C",360,7,Battery.BatteryType.LithiumLon);
                Display display = new Display(3,65536);
                //Create GSM
                GSM gsm = new GSM("1208", "nokia", 50, "Georgi", battery, display);
                //Console.WriteLine(gsm.ToString()); //Print GSM data

                //Mace some calls and print the history
                gsm.AddCall(new Call(new DateTime(2013, 02, 22, 19, 01, 22), "00359888888888", 200));
                gsm.AddCall(new Call(new DateTime(2013,02,22,20,02,33),"0887888888",302));
                gsm.AddCall(new Call(new DateTime(2013, 02, 22, 20, 30, 19), "0889-88-88-88", 178));
                gsm.PrintCallHistiry();
                //Calculate the price of all calls
                decimal price = 0.37m;
                gsm.CalculateTotalCallsPrice(price);

                //Remove the longest call and calculate the price again
                gsm.DeleteCall(1); //The calls in the list start from 0, so the second call(longest) is 1
                gsm.CalculateTotalCallsPrice(price);

                //Clear the history and print it
                gsm.ClearCallHistory();
                gsm.PrintCallHistiry();
                


            }
            catch (Exception ex)
            {

                Console.WriteLine("Error!"+ex.Message);
            }

        }
    }
}
