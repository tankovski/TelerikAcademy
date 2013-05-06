using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class PerformanceOfSquareRootSinAndNaturalLogarithm
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        List<Performance> performances = new List<Performance>();

        float floatOne = 50F;


        //Add float operations
        performances.Add(new Performance("Square root", "float", MesureFloatOperationsPerformance(floatOne, "square root", stopwatch)));
        performances.Add(new Performance("Natural logarithm", "float", MesureFloatOperationsPerformance(floatOne, "natural logarithm", stopwatch)));
        performances.Add(new Performance("Sinus", "float", MesureFloatOperationsPerformance(floatOne, "sinus", stopwatch)));

        double doubleOne = 50D;

        //Add double operations
        performances.Add(new Performance("Square root", "double", MesureDoubleOperationsPerformance(doubleOne, "square root", stopwatch)));
        performances.Add(new Performance("Natural logarithm", "double", MesureDoubleOperationsPerformance(doubleOne, "natural logarithm", stopwatch)));
        performances.Add(new Performance("Sinus", "double", MesureDoubleOperationsPerformance(doubleOne, "sinus", stopwatch)));

        decimal decimalOne = 50M;

        //Add double operations
        performances.Add(new Performance("Square root", "decimal", MesureDecimalOperationsPerformance(decimalOne, "square root", stopwatch)));
        performances.Add(new Performance("Natural logarithm", "decimal", MesureDecimalOperationsPerformance(decimalOne, "natural logarithm", stopwatch)));
        performances.Add(new Performance("Sinus", "decimal", MesureDecimalOperationsPerformance(decimalOne, "sinus", stopwatch)));

        var sortedPerformance = performances.OrderBy(perform => perform.PerformanceTime);
        foreach (var performance in sortedPerformance)
        {
            Console.WriteLine("{0} for {1} takes {2}", performance.Operation, performance.Type, performance.PerformanceTime);
        }
    }

    //Float operations
    public static TimeSpan MesureFloatOperationsPerformance(float num, string operation, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        switch (operation)
        {
            case "square root":
                {
                    stopwatch.Start();
                    Math.Sqrt(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "natural logarithm":
                {
                    stopwatch.Start();
                    Math.Log(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "sinus":
                {
                    stopwatch.Start();
                    Math.Sin(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            default:
                throw new ArgumentException("Invalid operations");
        }
    }

    //Double operations
    public static TimeSpan MesureDoubleOperationsPerformance(double num, string operation, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        switch (operation)
        {
            case "square root":
                {
                    stopwatch.Start();
                    Math.Sqrt(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "natural logarithm":
                {
                    stopwatch.Start();
                    Math.Log(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "sinus":
                {
                    stopwatch.Start();
                    Math.Sin(num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            default:
                throw new ArgumentException("Invalid operations");
        }
    }

    //Decimal operations
    public static TimeSpan MesureDecimalOperationsPerformance(decimal num, string operation, Stopwatch stopwatch)
    {
        stopwatch.Reset();
        switch (operation)
        {
            case "square root":
                {
                    stopwatch.Start();
                    Math.Sqrt((double)num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "natural logarithm":
                {
                    stopwatch.Start();
                    Math.Log((double)num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            case "sinus":
                {
                    stopwatch.Start();
                    Math.Sin((double)num);
                    stopwatch.Stop();

                    return stopwatch.Elapsed;
                }
            default:
                throw new ArgumentException("Invalid operations");
        }
    }
}
