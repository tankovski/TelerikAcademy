using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCombinationsWithoutDuplicates
{
    class PrintCombinationsWithoutDuplicates
    {

        static void NestedLoopss(int numberOfLoops, int numberOfIterations, int[] loops, int currentLoop, int start)
        {
            if (currentLoop == numberOfLoops)
            {
                PrintLoops(loops, numberOfLoops);
                return;
            }
            for (int counter = start; counter <= numberOfIterations; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoopss(numberOfLoops, numberOfIterations, loops, currentLoop + 1, counter + 1);
            }
        }
        static void PrintLoops(int[] loops, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Console.Write("{0} ", loops[i]);
            }
            Console.WriteLine();
        }
        static void Main()
        {
            int numberOfLoops = 2;
            int loopLenght = 4;
            int start = 1;
            int currentLoop = 0;
            int[] loops = new int[numberOfLoops];
            NestedLoopss(numberOfLoops, loopLenght, loops, currentLoop, start);
        }
    }
}

