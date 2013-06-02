using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortASequenceOfIntegersInList
{
    class SortASequenceOfIntegersInList
    {
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
                list.Sort();
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
        }
    }
}
