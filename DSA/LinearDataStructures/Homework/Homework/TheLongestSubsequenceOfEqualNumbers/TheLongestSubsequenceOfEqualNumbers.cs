using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TheLongestSubsequenceOfEqualNumbers
{
    public static List<int> FindingTheLongestSubsequenceOfEqualNumbers(List<int> list)
    {

        if (list.Count == 0 || list == null)
        {
            throw new ArgumentNullException("The list can not be empty or null!");
        }
        int number = 0;
        int sumOfEqualNumbers = 1;
        int maxSumOfEqualNumbers = 0;
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] == list[i + 1])
            {
                sumOfEqualNumbers += 1;
            }
            else
            {
                sumOfEqualNumbers = 1;
            }
            if (sumOfEqualNumbers > maxSumOfEqualNumbers)
            {
                maxSumOfEqualNumbers = sumOfEqualNumbers;
                number = list[i];
            }
        }

        List<int> maxSequence = new List<int>(maxSumOfEqualNumbers);
        for (int i = 0; i < maxSumOfEqualNumbers; i++)
        {
            maxSequence.Add(number);
        }

        return maxSequence;
    }

    static void Main()
    {
        List<int> list = new List<int>()
            {
                1, 2, 2, 2, 3, 2, 4, 5,5,5,5, 7, 8
            };

        List<int> maxSequence = FindingTheLongestSubsequenceOfEqualNumbers(list);
        foreach (var item in maxSequence)
        {
            Console.Write(item + " ");
        }
    }
}

