using System;

class PrintingAllOrderedKElementSubsetsFromNElementSet
{
    static void NestedLoopss(int numberOfLoops, int numberOfIterations, string[] loops,
        int currentLoop, string[] emtyArray)
    {

        if (currentLoop == numberOfLoops)
        {
            PrintLoops(emtyArray);
            return;
        }
        for (int counter = 0; counter < numberOfIterations; counter++)
        {
            emtyArray[currentLoop] = loops[counter];
            NestedLoopss(numberOfLoops, numberOfIterations, loops, currentLoop + 1, emtyArray);
        }

    }

    static void PrintLoops(string[] loops)
    {
        for (int i = 0; i < loops.Length; i++)
        {
            Console.Write("{0} ", loops[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int numberOfLoops = 2;
        int currentLoop = 0;
        string[] loops = { "hi", "a", "b" };
        string[] arr = new string[loops.Length];
        NestedLoopss(numberOfLoops, loops.Length, loops, currentLoop, arr);
    }
}

