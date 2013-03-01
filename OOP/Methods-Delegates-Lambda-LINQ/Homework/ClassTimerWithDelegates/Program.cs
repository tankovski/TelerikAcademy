using System;
using System.Threading;


class Program
{
    public static void DateAndTime()
    {
        Console.WriteLine(DateTime.Now);
    }


    static void Main(string[] args)
    {
        //Using delegates write a class Timer that 
        //can execute certain method at each t seconds.


        Timer timer = new Timer();
        timer.method = DateAndTime;
        timer.Start(1, 10);
    }
}

