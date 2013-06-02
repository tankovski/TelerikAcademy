using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class First50MembersOfASequence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");
        string input = Console.ReadLine();
        int number;
        bool isNumber = int.TryParse(input, out number);

        if (!isNumber)
        {
            throw new ArgumentException("This is not a number");
        }

        List<int> first50Numbers = Add50Elements(number);

        for (int i = 0; i < 50; i++)
        {
            Console.Write(first50Numbers[i]+" ");
        }
        Console.WriteLine();
    }

    private static List<int> Add50Elements(int number)
    {
        Queue<int> sequence = new Queue<int>();
        List<int> first50Numbers = new List<int>();
        sequence.Enqueue(number);
        first50Numbers.Add(number);
        int count = 1;
        while (first50Numbers.Count < 50)
        {
            int S1 = sequence.Dequeue();
            int S2 = S1 + 1;
            int S3 = 2 * S1 + 1;
            int S4 = S1 + 2;

            sequence.Enqueue(S2);
            sequence.Enqueue(S3);
            sequence.Enqueue(S4);

            first50Numbers.Add(S2);
            first50Numbers.Add(S3);
            first50Numbers.Add(S4);

            count++;
        }

        return first50Numbers;
    }
}

