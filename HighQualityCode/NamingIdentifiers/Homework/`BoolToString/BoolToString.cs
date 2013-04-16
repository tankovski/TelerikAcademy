using System;

class BoolToString
{
    const int maxCount = 6;

    class Printer
    {
        public void PrintBool(bool forPrinting)
        {
            string boolToString = forPrinting.ToString();
            Console.WriteLine(boolToString);
        }
    }
    static void Main(string[] args)
    {
        Printer printer = new Printer();
        printer.PrintBool(true);
    }
}

