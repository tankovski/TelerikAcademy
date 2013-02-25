using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GenericList<T>
{

    //Fields
    private T[] elements;
    private int count = 0;
    private int capacity;

    //Constructors
    public GenericList(int capacity = 1000)
    {
        this.capacity = capacity;
        elements = new T[capacity];
    }

    //Properties
    public int Count
    {
        get
        {
            return this.count;
        }
    }
    public int Capacity
    {
        get { return this.capacity; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The capacity can't be a negative number!");
            }
            this.capacity = value;
        }
    }


    //Methods
    public void Add(T element)
    {
        if (count == elements.Length)
        {
            AutoGrow();
        }
        if (count >= elements.Length)
        {
            throw new IndexOutOfRangeException(String.Format(
                "The list capacity of {0} was exceeded.", elements.Length));
        }
        this.elements[count] = element;
        count++;
    }
    public T this[int index]
    {
        get
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = elements[index];
            return result;
        }
    }
    public void RemoveAtIndex(int index)
    {
        if (index < 0)
        {
            throw new ArgumentException("The index must be a positive number!");
        }
        if (index <= count)
        {
            for (int i = index; i < count-1; i++)
            {
                elements[i] = elements[i + 1];
            }
            count--;
        }
        else
        {
            throw new ArgumentException("This position is emty!");
        }
    }
    public void Clear()
    {
        elements = new T[elements.Length];
        count = 0;
    }
    public void InsertAtPosition(int index, T element)
    {
        if (count == elements.Length)
        {
            AutoGrow();
        }
        for (int i = count; i >= index + 1; i--)
        {
            elements[i] = elements[i - 1];
        }
        elements[index] = element;
        count++;
    }
    public int FindByValue(T element)
    {
        return Array.IndexOf(elements, element);
    }
    public override string ToString()
    {
        string str = null;
        for (int i = 0; i < count; i++)
        {
            str += elements[i];
            if (i < count - 1)
            {
                str += ", ";
            }
        }
        return str;
    }
    private void AutoGrow()
    {
        T[] tempArray = new T[elements.Length * 2];
        Array.Copy(elements, 0, tempArray, 0, elements.Length);
        elements = tempArray;
        Capacity *= 2; ;
    }

    public T Max()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (this.count == 1)
        {
            return this.elements[0];
        }

        if (this.elements[0] is IComparable<T>)
        {
            T max = this.elements[0];

            for (int i = 1; i < this.count; i++)
            {
                if ((max as IComparable<T>).CompareTo(this.elements[i]) < 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }
        else
        {
            throw new ArgumentException("At least one object must implement IComparable.");
        }
    }
    public T Min()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        if (this.count == 1)
        {
            return this.elements[0];
        }

        if (this.elements[0] is IComparable<T>)
        {
            T min = this.elements[0];

            for (int i = 1; i < this.count; i++)
            {
                if ((min as IComparable<T>).CompareTo(this.elements[i]) > 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }
        else
        {
            throw new ArgumentException("At least one object must implement IComparable.");
        }
    }
}

