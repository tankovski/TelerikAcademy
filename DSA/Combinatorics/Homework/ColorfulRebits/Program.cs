using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRebits
{
    class Program
    {
        static void Main()
        {
            int numberOfRabbits = int.Parse(Console.ReadLine());
            int[] rabbits = new int[numberOfRabbits];

            for (int i = 0; i < numberOfRabbits; i++)
            {
                rabbits[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(rabbits);
            List<int> number = new List<int>();
            List<int> ocurrance = new List<int>();
            int counter;
            for (int i = 0; i < numberOfRabbits; i += counter)
            {
                counter = 1;
                for (int l = i + 1; l < numberOfRabbits; l++)
                {

                    if (rabbits[i] == rabbits[l])
                    {
                        counter += 1;
                    }
                }

                number.Add(rabbits[i]);
                ocurrance.Add(counter);
            }

            int sum = 0;
            for (int i = 0; i < number.Count; i++)
            {
                sum += ((ocurrance[i]) / (number[i] + 1)) * (number[i] + 1);

                if ((ocurrance[i]) % (number[i] + 1)>0)
                {
                    sum += number[i] + 1;
                }
                
            }


            Console.WriteLine(sum);
        }
    }
}
