using System;
using System.Collections.Generic;

class SwquenceOfIntegersReadedFromTheConsole
{
    public static int CalculateSum(List<int> list)
    {
        if (list.Count == 0 || list == null)
        {
            throw new ArgumentNullException("The list can not be null or emty");
        }

        int sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sum += list[i];
        }

        return sum;
    }

    public static double CalculateAverige(List<int> list)
    {
        if (list.Count == 0 || list == null)
        {
            throw new ArgumentNullException("The list can not be null or emty");
        }

        int sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sum += list[i];
        }

        double averige = sum / list.Count;

        return averige;
    }

    static void Main()
    {
        try
        {
            string input = null;
            List<int> list = new List<int>();

            Console.WriteLine("Enter sequence of numbers, each one on new line. When finish enter empty line.");
            while (input != String.Empty)
            {
                input = Console.ReadLine();
                int num;
                if (int.TryParse(input, out num))
                {
                    if (num < 0)
                    {
                        throw new ArgumentException("The numbers must be positive!");
                    }
                    list.Add(num);
                }
                else if (input != String.Empty)
                {
                    throw new ArgumentException("This is not a number!");
                }
            }

            int sum = CalculateSum(list);
            Console.WriteLine("The sum of all numbers are: " + sum);

            double averige = CalculateAverige(list);
            Console.WriteLine("The averige of all numbers are: " + averige);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error! " + ex.Message);
        }
    }
}

