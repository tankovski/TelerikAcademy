using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllNumbersThatOccurOddNumberOfTimes
{
    class RemoveAllNumbersThatOccurOddNumberOfTimes
    {
        public static int[] RemoveNumbersThatExistOddNumberOfTimes(int[] sequence)
        {
            if (sequence.Length == 0 || sequence == null)
            {
                throw new ArgumentNullException("The sequence can not be empty or null!");
            }

            List<int> sortedSequence = sequence.ToList();
            sortedSequence.Sort();
            List<int> numbersForRemoving = FindEachNumberOccurOddNumberOfThimes(sortedSequence);

            List<int> removedNumbers = sequence.ToList();
            for (int i = 0; i < numbersForRemoving.Count; i++)
            {
                removedNumbers.RemoveAll(num => num == numbersForRemoving[i]);
            }

            return removedNumbers.ToArray();
        }

        private static List<int> FindEachNumberOccurOddNumberOfThimes(List<int> sortedSequence)
        {
            List<int> numbersForRemoving = new List<int>();
            int numberOfOcurences = 1;

            for (int i = 0; i < sortedSequence.Count; i += numberOfOcurences)
            {
                int number = sortedSequence[i];
                numberOfOcurences = 1;
                for (int l = i + 1; l < sortedSequence.Count; l++)
                {
                    if (sortedSequence[i] == sortedSequence[l])
                    {
                        numberOfOcurences += 1;
                    }
                }
                if (numberOfOcurences % 2 == 0)
                {
                    numbersForRemoving.Add(number);
                }
            }

            return numbersForRemoving;
        }

        static void Main()
        {
            int[] sequence = new int[] 
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 
            };

            int[] sequenceWithRemovedNumbers = RemoveNumbersThatExistOddNumberOfTimes(sequence);

            for (int i = 0; i < sequenceWithRemovedNumbers.Length; i++)
            {
                Console.Write(sequenceWithRemovedNumbers[i]+" ");
            }
        }
    }
}
