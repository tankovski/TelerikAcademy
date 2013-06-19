using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPasswords
{
    class Program
    {

        static void Main()
        {
            string input = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='*')
                {
                    count += 1;
                }
            }

            Console.WriteLine((long)Math.Pow(2,count));
        }
    }
}
