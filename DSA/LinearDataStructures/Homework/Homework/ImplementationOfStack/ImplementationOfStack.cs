using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfStack
{
    class ImplementationOfStack
    {
        static void Main(string[] args)
        {   
            OurStack<int> stack = new OurStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(5);

            int[] stackToArray = stack.ToArray();
            for (int i = 0; i < stackToArray.Length; i++)
            {
                Console.Write(stackToArray[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Contains(0));
            stack.Clear();
            Console.WriteLine(stack.Count);
        }
    }
}
