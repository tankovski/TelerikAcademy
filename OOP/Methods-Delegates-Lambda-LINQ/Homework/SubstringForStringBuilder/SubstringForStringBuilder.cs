using System;
using System.Text;

class SubstringForStringBuilder
{
    static void Main()
    {

        //Implement an extension method Substring(int index, int length)
        //for the class StringBuilder that returns new StringBuilder and 
        //has the same functionality as Substring in the class String.


        string str = "This is some random text!";
        StringBuilder sb = new StringBuilder();
        sb.Append(str);
        StringBuilder sbSplit = sb.Substring(0, 12);
        Console.WriteLine(sbSplit.ToString());

    }
}

