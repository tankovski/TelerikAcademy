using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfQueue
{
    class ImplementationOfQueue
    {
        static void Main(string[] args)
        {
            OurQueue<int> queue = new OurQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(15);
            queue.Enqueue(25);
            queue.Enqueue(35);

            int[] array = queue.ToArray();
            Console.WriteLine(queue.Peek());
            while (queue.Count>0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            Console.WriteLine(queue.Contains(15));     
        }
    }
}
