using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowManyTimesNumberOccurs
{
    class HowManyTimesNumberOccurs
    {
        public static string[] FindHowManyTimesNumberOccurs(int[] sequence)
        {
            if (sequence.Length == 0 || sequence == null)
            {
                throw new ArgumentNullException("The sequence can not be empty or null!");
            }

            Array.Sort(sequence);
            List<string> numbersAndHowManyTimesOccurs = new List<string>();
            int number = 0;
            int numberOfOccurs = 1;

            for (int i = 0; i < sequence.Length; i+=numberOfOccurs)
            {
                numberOfOccurs = 1;
                number=sequence[i];
                for (int l = i+1; l < sequence.Length; l++)
                {
                    if (sequence[i]==sequence[l])
                    {
                        numberOfOccurs += 1;
                    }
                }
                numbersAndHowManyTimesOccurs.Add(String.Format("{0}->{1} times", number, numberOfOccurs));
            }

            return numbersAndHowManyTimesOccurs.ToArray();
        }
        static void Main()
        {
           int[] sequence = {1,1,2,3,222,333,5,2,1,333};
           string[] numberOfOccurs = FindHowManyTimesNumberOccurs(sequence);
           foreach (var item in numberOfOccurs)
           {
               Console.WriteLine(item);
           }
        }
    }
}
