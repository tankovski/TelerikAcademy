using System;


class Program
{
    static void Main()
    {

        //Print some number in binary representation just to compare with it
        int num = 8765;
        Console.WriteLine(Convert.ToString(num, 2).PadLeft(64,'0'));
        //Making the BitArray64 with the same number but from ulong type
        ulong number = 8765;
        BitArray64 bits = new BitArray64(number);
        //Test foreach
        foreach (var bit in bits)
        {
            Console.Write(bit);
        }
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------");
        //Making new BitArray64 and compare it with the old one
        BitArray64 bits2 = new BitArray64((ulong)8766);
        Console.WriteLine(bits.Equals(bits2));
        Console.WriteLine(bits==bits2);
        Console.WriteLine(bits!=bits2);
        Console.WriteLine("-----------------------------------------------------------------");
        //Test ToString() method
        Console.WriteLine(bits);
        //Test overriten operator[]
        Console.WriteLine(bits[0]);
    }
}

