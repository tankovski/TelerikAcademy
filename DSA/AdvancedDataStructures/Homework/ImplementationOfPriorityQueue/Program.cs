using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> heap = new PriorityQueue<string>();

            heap.Enqueue("Az");
            heap.Enqueue("az");
            heap.Enqueue("zzz");
            heap.Enqueue("kkk");
            heap.Enqueue("louol");
            heap.Enqueue("ss");

            while (heap.Count>0)
            {
                Console.WriteLine(heap.Dequeue());
            }
        }
    }
}
