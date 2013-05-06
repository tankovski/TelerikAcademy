using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

class PerfomanceOfAddSubtracktAndMore
{
    static void Main(string[] args)
    {
        Stopwatch stoplatch = new Stopwatch();
        List<Performance> performances = new List<Performance>();
 
        int intOne = 50;
        int intTwo = 50;

        //Add int operations performance
        performances.Add(new Performance("Add", "Int", MesurePerformanceOfIntOperations(intOne, intTwo, "+", stoplatch)));
        performances.Add(new Performance("Subtrack", "Int", MesurePerformanceOfIntOperations(intOne, intTwo, "-", stoplatch)));
        performances.Add(new Performance("Increment", "Int", MesurePerformanceOfIntOperations(intOne, intTwo, "++", stoplatch)));
        performances.Add(new Performance("Multiply", "Int", MesurePerformanceOfIntOperations(intOne, intTwo, "*", stoplatch)));
        performances.Add(new Performance("Increment", "Int", MesurePerformanceOfIntOperations(intOne, intTwo, "/", stoplatch)));

        long longOne = 50L;
        long longTwo = 50L;

        //Add long operations performance
        performances.Add(new Performance("Add", "long", MesurePerformanceOfLongOperations(longOne, longTwo, "+", stoplatch)));
        performances.Add(new Performance("Subtrack", "long", MesurePerformanceOfLongOperations(longOne, longTwo, "-", stoplatch)));
        performances.Add(new Performance("Increment", "long", MesurePerformanceOfLongOperations(longOne, longTwo, "++", stoplatch)));
        performances.Add(new Performance("Multiply", "long", MesurePerformanceOfLongOperations(longOne, longTwo, "*", stoplatch)));
        performances.Add(new Performance("Increment", "long", MesurePerformanceOfLongOperations(longOne, longTwo, "/", stoplatch)));

        float floatOne = 50F;
        float floatTwo = 50F;

        //Add float operations performance
        performances.Add(new Performance("Add", "float", MesurePerformanceOfFloatOperations(floatOne, floatTwo, "+", stoplatch)));
        performances.Add(new Performance("Subtrack", "float", MesurePerformanceOfFloatOperations(floatOne, floatTwo, "-", stoplatch)));
        performances.Add(new Performance("Increment", "float", MesurePerformanceOfFloatOperations(floatOne, floatTwo, "++", stoplatch)));
        performances.Add(new Performance("Multiply", "float", MesurePerformanceOfFloatOperations(floatOne, floatTwo, "*", stoplatch)));
        performances.Add(new Performance("Increment", "float", MesurePerformanceOfFloatOperations(floatOne, floatTwo, "/", stoplatch)));

        double doubleOne = 50D;
        double doubleTwo = 50D;

        //Add double operations performance
        performances.Add(new Performance("Add", "double", MesurePerformanceOfDoubleOperations(doubleOne, doubleTwo, "+", stoplatch)));
        performances.Add(new Performance("Subtrack", "double", MesurePerformanceOfDoubleOperations(doubleOne, doubleTwo, "-", stoplatch)));
        performances.Add(new Performance("Increment", "double", MesurePerformanceOfDoubleOperations(doubleOne, doubleTwo, "++", stoplatch)));
        performances.Add(new Performance("Multiply", "double", MesurePerformanceOfDoubleOperations(doubleOne, doubleTwo, "*", stoplatch)));
        performances.Add(new Performance("Increment", "double", MesurePerformanceOfDoubleOperations(doubleOne, doubleTwo, "/", stoplatch)));

        decimal decimalOne = 50;
        decimal decimalTwo = 50;

        //Add double operations performance
        performances.Add(new Performance("Add", "decimal", MesurePerformanceOfDecimalOperations(decimalOne, decimalTwo, "+", stoplatch)));
        performances.Add(new Performance("Subtrack", "decimal", MesurePerformanceOfDecimalOperations(decimalOne, decimalTwo, "-", stoplatch)));
        performances.Add(new Performance("Increment", "decimal", MesurePerformanceOfDecimalOperations(decimalOne, decimalTwo, "++", stoplatch)));
        performances.Add(new Performance("Multiply", "decimal", MesurePerformanceOfDecimalOperations(decimalOne, decimalTwo, "*", stoplatch)));
        performances.Add(new Performance("Increment", "decimal", MesurePerformanceOfDecimalOperations(decimalOne, decimalTwo, "/", stoplatch)));

        var sortedPerformance = performances.OrderBy(perform => perform.PerformanceTime);
        foreach (var performance in sortedPerformance)
        {
            Console.WriteLine("{0} for {1} takes {2}", performance.Operation, performance.Type, performance.PerformanceTime);
        }
    }

    //Int operations
    private static TimeSpan MesurePerformanceOfIntOperations(int numOne, int numTwo, string sign, Stopwatch stoplatch)
    {
        stoplatch.Reset();
        long sum = 0;

        switch (sign)
        {
            case "+":
                {
                    stoplatch.Start();
                    sum = numOne + numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "-":
                {
                    stoplatch.Start();
                    sum = numOne - numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "++":
                {
                    stoplatch.Start();
                    numOne++;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "*":
                {
                    stoplatch.Start();
                    sum = numOne * numTwo * 555555555;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "/":
                {
                    stoplatch.Start();
                    sum = numOne / numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            default:
                throw new ArgumentException("This is not a valid sign");               
        }
    }

    //Long operations
    private static TimeSpan MesurePerformanceOfLongOperations(long numOne, long numTwo, string sign, Stopwatch stoplatch)
    {
        stoplatch.Reset();
        long sum = 0;

        switch (sign)
        {
            case "+":
                {
                    stoplatch.Start();
                    sum = numOne + numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "-":
                {
                    stoplatch.Start();
                    sum = numOne - numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "++":
                {
                    stoplatch.Start();
                    numOne++;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "*":
                {
                    stoplatch.Start();
                    sum = numOne * numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "/":
                {
                    stoplatch.Start();
                    sum = numOne / numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            default:
                throw new ArgumentException("This is not a valid sign");
        }
    }

    //Float operations
    private static TimeSpan MesurePerformanceOfFloatOperations(float numOne, float numTwo, string sign, Stopwatch stoplatch)
    {
        stoplatch.Reset();
        float sum = 0;

        switch (sign)
        {
            case "+":
                {
                    stoplatch.Start();
                    sum = numOne + numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "-":
                {
                    stoplatch.Start();
                    sum = numOne - numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "++":
                {
                    stoplatch.Start();
                    numOne++;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "*":
                {
                    stoplatch.Start();
                    sum = numOne * numTwo * 555555555;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "/":
                {
                    stoplatch.Start();
                    sum = numOne / numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            default:
                throw new ArgumentException("This is not a valid sign");
        }
    }

    //Double operations
    private static TimeSpan MesurePerformanceOfDoubleOperations(double numOne, double numTwo, string sign, Stopwatch stoplatch)
    {
        stoplatch.Reset();
        double sum = 0;

        switch (sign)
        {
            case "+":
                {
                    stoplatch.Start();
                    sum = numOne + numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "-":
                {
                    stoplatch.Start();
                    sum = numOne - numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "++":
                {
                    stoplatch.Start();
                    numOne++;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "*":
                {
                    stoplatch.Start();
                    sum = numOne * numTwo * 555555555;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "/":
                {
                    stoplatch.Start();
                    sum = numOne / numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            default:
                throw new ArgumentException("This is not a valid sign");
        }
    }

    //Decimal operations
    private static TimeSpan MesurePerformanceOfDecimalOperations(decimal numOne, decimal numTwo, string sign, Stopwatch stoplatch)
    {
        stoplatch.Reset();
        decimal sum = 0;

        switch (sign)
        {
            case "+":
                {
                    stoplatch.Start();
                    sum = numOne + numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "-":
                {
                    stoplatch.Start();
                    sum = numOne - numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "++":
                {
                    stoplatch.Start();
                    numOne++;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "*":
                {
                    stoplatch.Start();
                    sum = numOne * numTwo * 555555555;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            case "/":
                {
                    stoplatch.Start();
                    sum = numOne / numTwo;
                    stoplatch.Stop();
                    return stoplatch.Elapsed;
                }
            default:
                throw new ArgumentException("This is not a valid sign");
        }
    }
}

