using System;

class PrintingAllSubsetsOfKStringsFromGivenSetOfStrings
{
    static void NestedLoopss(int numberOfLoops, int numberOfIterations, string[] loops,
        int currentLoop, string[] emtyArray, int start)
    {

        if (currentLoop == numberOfLoops)
        {
            PrintLoops(emtyArray);
            return;
        }
        for (int counter = start; counter < numberOfIterations; counter++)
        {
            emtyArray[currentLoop] = loops[counter];
            NestedLoopss(numberOfLoops, numberOfIterations, loops, currentLoop + 1, emtyArray, counter + 1);
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
        int start = 0;
        string[] loops = { "test", "rock", "fun" };
        string[] arr = new string[loops.Length];
        NestedLoopss(numberOfLoops, loops.Length, loops, currentLoop, arr, start);
    }
}

