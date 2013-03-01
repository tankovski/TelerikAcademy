using System;
using System.Collections.Generic;
using System.Linq;


class IEnumerableSumProductMinMaxAverage
{
    static void Main(string[] args)
    {

        //Implement a set of extension methods for IEnumerable<T> 
        //that implement the following group functions: sum, product,
        //min, max, average.
        try
        {
            IEnumerable<uint> list = new uint[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("The sum is {0}", list.Sum<uint>());
            Console.WriteLine("The product is {0}", list.Product<uint>());
            Console.WriteLine("The averige is {0}", list.Average<uint>());
            Console.WriteLine("The min element is {0}", list.Min<uint>());
            Console.WriteLine("The max element is {0}", list.Max<uint>());
        }
        catch (Exception ex)
        {

            Console.WriteLine("Error!" + ex.Message);
        }

    }
}

