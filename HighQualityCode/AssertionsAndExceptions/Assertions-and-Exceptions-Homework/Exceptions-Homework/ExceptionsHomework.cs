using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentNullException("The array is empty or not initialized!");
        }
        if (startIndex < 0 || count < 0)
        {
            throw new ArgumentOutOfRangeException("Start index and substring lenght must be a positive numbers!");
        }
        if (arr.Length < startIndex + count)
        {
            throw new IndexOutOfRangeException("The substing you wnat is too big!");
        }
        if (startIndex > arr.Length)
        {
            throw new ArgumentOutOfRangeException("Start index is bigger than array lenght!");
        }
        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("Count must be smaller than string lenght");
        }
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count must be a positive number");
        }
        if (str == null || str.Length == 0)
        {
            throw new ArgumentNullException("The string is not initialized!");
        }
        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("The number must be positive!");
        }
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;

            }
        }
        return true;
    }

    static void Main()
    {
        try
        {

            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

            Console.WriteLine("23 is prime - " + CheckPrime(23));
            Console.WriteLine("33 is prime - " + CheckPrime(33));

            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error!" + ex.Message);
        }
    }
}
