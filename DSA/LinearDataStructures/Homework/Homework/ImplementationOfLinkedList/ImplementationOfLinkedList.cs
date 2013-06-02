using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfLinkedList
{
    class ImplementationOfLinkedList
    {
        static void Main()
        {
            OurLinkedList<int> linkedList = new OurLinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddLast(100);
            linkedList.AddFirst(10);
            linkedList.AddFirst(20);
            linkedList.AddLast(50);
            linkedList.AddAfter(linkedList.FirstElement.NextItem.NextItem.NextItem, 1000);
            linkedList.AddBefore(linkedList.FirstElement.NextItem.NextItem.NextItem,50000);
            linkedList.AddBefore(linkedList.FirstElement, 0);
            linkedList.RemoveFirst();
            linkedList.RemoveLast();           
          
            ListItem<int> next = linkedList.FirstElement;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.NextItem;
            }

            Console.WriteLine(linkedList.Count);
        }
    }
}
