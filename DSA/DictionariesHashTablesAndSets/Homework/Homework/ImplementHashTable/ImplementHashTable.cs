using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ImplementHashTable
{
    static void Main()
    {
        OurHashTable<int, int> hassTable = new OurHashTable<int, int>();

        for (int i = 0; i < 20; i++)
        {
            hassTable.Add(i, 1 + i);
        }

        Console.WriteLine(hassTable.Find(6));

        hassTable[6] = 333;

        Console.WriteLine(hassTable[6]);

        Console.WriteLine(hassTable.Keys);

        foreach (var item in hassTable)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }
        hassTable.Add(30, 1);
        hassTable.Add(300, 1);
        hassTable.Add(3000, 1);
        hassTable.Add(30000, 1);

        hassTable.Add(40, 1);
        hassTable.Add(400, 1);
        hassTable.Add(4000, 1);
        hassTable.Add(40000, 1);

        Console.WriteLine(hassTable.Count);
        Console.WriteLine(hassTable.Capacity);

       
    }
}

