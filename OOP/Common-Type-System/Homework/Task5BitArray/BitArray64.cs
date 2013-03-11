using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;



public class BitArray64 : IEnumerable<int>
{
    //Fields
    ulong number;

    //Properties
    public ulong Number
    {
        get { return this.number; }
        set { this.number = value; }
    }

    //Constructor
    public BitArray64(ulong number)
    {
        this.Number = number;
    }

    //Methods
    //Implement foreach
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 63; i >= 0; i--)
        {
            yield return this[i];
        }
    }

    //implement Equals(...),GetHashCode(),[],==,!=
    public override bool Equals(object param)
    {
        BitArray64 bitArray = param as BitArray64;

        if ((object)bitArray == null)
        {
            return false;
        }

        if (!Object.Equals(this.number, bitArray.number))
        {
            return false;
        }

        return true;
    }
    public override int GetHashCode()
    {
        return this.number.GetHashCode();
    }
    public int this[int index]
    {
        get
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("Index must be in range [0, 63].");
            }

            return (int)((this.number >> index) & 1);
        }
    }
    public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
    {
        return BitArray64.Equals(bitArray1, bitArray2);
    }

    public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
    {
        return !(BitArray64.Equals(bitArray1, bitArray2));
    }
    

    //Override ToString() method
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(64);
        for (int i = 63; i >= 0; i--)
        {
            sb.Append(this[i]);
        }
        return sb.ToString();
    }
}

