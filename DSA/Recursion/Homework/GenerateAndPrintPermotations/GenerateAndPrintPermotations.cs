using System;

class GenerateAndPrintPermotations
{
    static void Main()
    {
        int[] arr = { 1,2,3 };
        GeneratePermutations(arr, 0);
    }

    static void GeneratePermutations<T>(T[] arr, int start)
    {
        if (start >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            GeneratePermutations(arr, start + 1);
            for (int i = start + 1; i < arr.Length; i++)
            {
                Swap(ref arr[start], ref arr[i]);
                GeneratePermutations(arr, start + 1);
                Swap(ref arr[start], ref arr[i]);
            }
        }
    }

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}

