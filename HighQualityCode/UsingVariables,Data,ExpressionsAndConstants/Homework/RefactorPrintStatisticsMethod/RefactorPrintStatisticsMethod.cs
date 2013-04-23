using System;

class RefactorPrintStatisticsMethod
{
    public void PrintStatistics(double[] arr, int count)
    {
        double max = FindMaxElement(arr, count);
        Console.WriteLine(max); 

        double min = FindMinElement(arr, count);
        Console.WriteLine(min); 

        double averige = CalculateAverige(arr, count);
        Console.WriteLine(averige); 
    }

    private static double CalculateAverige(double[] arr, int count)
    {
        double sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += arr[i];
        }

        double averige = sum / count;

        return averige;
    }

    private static double FindMinElement(double[] arr, int count)
    {
        double min = double.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double FindMaxElement(double[] arr, int count)
    {
        double max = double.MinValue;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    static void Main(string[] args)
    {
    }
}