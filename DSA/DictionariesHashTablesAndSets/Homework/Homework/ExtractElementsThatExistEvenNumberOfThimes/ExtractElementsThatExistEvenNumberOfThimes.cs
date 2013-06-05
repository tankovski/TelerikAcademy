using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractElementsThatExistEvenNumberOfThimes
{
    class ExtractElementsThatExistEvenNumberOfThimes
    {
        static void Main(string[] args)
        {
            string[] values = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var value in values)
            {
                int count = 0;
                if (dictionary.ContainsKey(value))
                {
                    count = dictionary[value];
                }
                dictionary[value] = count + 1;
            }

            foreach (var value in dictionary)
            {
                if (value.Value%2==1)
                {
                    Console.WriteLine(value.Key);
                }
            }
        }
    }
}
