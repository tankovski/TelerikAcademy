using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumberOfOccurrencesWithDictionary
{
    class CountNumberOfOccurrencesWithDictionary
    {
        static void Main()
        {
            double[] values = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> dictionary = new Dictionary<double, int>();
            foreach (var value in values)
            {
                int count = 0;
                if (dictionary.ContainsKey(value))
                {
                    count = dictionary[value];
                }
                dictionary[value] =count+ 1;
            }

            foreach (var value in dictionary)
            {
                Console.WriteLine("{0} -> {1} times",value.Key,value.Value);
            }
        }
    }
}
