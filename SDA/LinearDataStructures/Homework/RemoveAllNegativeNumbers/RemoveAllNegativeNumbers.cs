using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllNegativeNumbers
{
    class RemoveAllNegativeNumbers
    {
        public static int[] RemoveAllNegativeNumbersFromTheSequence(int[] sequence)
        {
            if (sequence.Length == 0 || sequence == null)
            {
                throw new ArgumentNullException("The sequence can not be empty or null!");
            }
            List<int> positiveNumbers = new List<int>();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] >= 0)
                {
                    positiveNumbers.Add(sequence[i]);
                }
            }

            return positiveNumbers.ToArray();
        }

        static void Main()
        {
            int[] sequence = new int[]
            {
                1,2,-4,3,-2,-6,0
            };

            sequence = RemoveAllNegativeNumbersFromTheSequence(sequence);
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
