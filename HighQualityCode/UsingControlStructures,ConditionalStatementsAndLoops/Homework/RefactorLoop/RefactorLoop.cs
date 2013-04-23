using System;

class RefactorLoop
{
    static void Main(string[] args)
    {
        for (int index = 0; index < 100; index++)
        {
            Console.WriteLine(array[index]);
            if (array[index] == expectedValue)
            {
                Console.WriteLine("Value Found");
                break;
            }
        }
    }
}

