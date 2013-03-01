using System;
using System.Linq;

class PrintAllNumbersDivisibleBy3And7
{
    static void Main(string[] args)
    {

        //Write a program that prints from given array of integers
        //all numbers that are divisible by 7 and 3. Use the built-in
        //extension methods and lambda expressions. Rewrite the same with LINQ.


        int[] array = { 1, 3, 231, 7, 21, 42, 56, 73, 63, 210 };

        //With lambda expression

        //int[] ourNumbers = Array.FindAll(array,num=>num%21==0);
        //foreach (int num in ourNumbers)
        //{
        //    Console.WriteLine(num);
        //}


        //With LINQ

        var ourNumbers =
            from num in array
            where num % 21 == 0
            select num;
        foreach (int num in ourNumbers)
        {
            Console.WriteLine(num);
        }
    }
}

