using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BinaryHeap<T> : ICollection<T> where T : IComparable<T>
{
    // Constants
    private const int DEFAULT_SIZE = 4;
    // Fields
    private T[] data = new T[DEFAULT_SIZE];
    private int count = 0;
    private int capacity = DEFAULT_SIZE;
    private bool sorted;

    // Properties
    /// <summary>
    /// Gets the number of values in the heap. 
    /// </summary>
    public int Count
    {
        get { return this.count; }
    }
    /// <summary>
    /// Gets or sets the capacity of the heap.
    /// </summary>
    public int Capacity
    {
        get { return this.capacity; }
        set
        {
            int previousCapacity = this.capacity;
            this.capacity = Math.Max(value, this.count);
            if (this.capacity != previousCapacity)
            {
                T[] temp = new T[this.capacity];
                Array.Copy(this.data, temp, this.count);
                this.data = temp;
            }
        }
    }
    // Methods
    /// <summary>
    /// Creates a new binary heap.
    /// </summary>
    public BinaryHeap()
    {
    }
    private BinaryHeap(T[] data, int count)
    {
        Capacity = count;
        this.count = count;
        Array.Copy(data, this.data, count);
    }
    /// <summary>
    /// Gets the first value in the heap without removing it.
    /// </summary>
    /// <returns>The lowest value of type TValue.</returns>
    public T Peek()
    {
        return this.data[0];
    }

    /// <summary>
    /// Removes all items from the heap.
    /// </summary>
    public void Clear()
    {
        this.count = 0;
        this.data = new T[this.capacity];
    }
    /// <summary>
    /// Adds a key and value to the heap.
    /// </summary>
    /// <param name="item">The item to add to the heap.</param>
    public void Add(T item)
    {
        if (this.count == this.capacity)
        {
            Capacity *= 2;
        }
        this.data[this.count] = item;
        UpHeap();
        this.count++;
    }

    /// <summary>
    /// Removes and returns the first item in the heap.
    /// </summary>
    /// <returns>The next value in the heap.</returns>
    public T Remove()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("Cannot remove item, heap is empty.");
        }
        T v = this.data[0];
        this.count--;
        this.data[0] = this.data[this.count];
        this.data[this.count] = default(T); //Clears the Last Node
        DownHeap();
        return v;
    }
    private void UpHeap()
    //helper function that performs up-heap bubbling
    {
        this.sorted = false;
        int p = this.count;
        T item = this.data[p];
        int par = Parent(p);
        while (par > -1 && item.CompareTo(this.data[par]) < 0)
        {
            this.data[p] = this.data[par]; //Swap nodes
            p = par;
            par = Parent(p);
        }
        this.data[p] = item;
    }
    private void DownHeap()
    //helper function that performs down-heap bubbling
    {
        this.sorted = false;
        int n;
        int p = 0;
        T item = this.data[p];
        while (true)
        {
            int ch1 = Child1(p);
            if (ch1 >= this.count) break;
            int ch2 = Child2(p);
            if (ch2 >= this.count)
            {
                n = ch1;
            }
            else
            {
                n = this.data[ch1].CompareTo(this.data[ch2]) < 0 ? ch1 : ch2;
            }
            if (item.CompareTo(this.data[n]) > 0)
            {
                this.data[p] = this.data[n]; //Swap nodes
                p = n;
            }
            else
            {
                break;
            }
        }
        this.data[p] = item;
    }
    private void EnsureSort()
    {
        if (this.sorted) return;
        Array.Sort(this.data, 0, this.count);
        this.sorted = true;
    }
    private static int Parent(int index)
    //helper function that calculates the parent of a node
    {
        return (index - 1) >> 1;
    }
    private static int Child1(int index)
    //helper function that calculates the first child of a node
    {
        return (index << 1) + 1;
    }
    private static int Child2(int index)
    //helper function that calculates the second child of a node
    {
        return (index << 1) + 2;
    }

    /// <summary>
    /// Creates a new instance of an identical binary heap.
    /// </summary>
    /// <returns>A BinaryHeap.</returns>
    public BinaryHeap<T> Copy()
    {
        return new BinaryHeap<T>(this.data, this.count);
    }

    /// <summary>
    /// Gets an enumerator for the binary heap.
    /// </summary>
    /// <returns>An IEnumerator of type T.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        EnsureSort();
        for (int i = 0; i < this.count; i++)
        {
            yield return this.data[i];
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Checks to see if the binary heap contains the specified item.
    /// </summary>
    /// <param name="item">The item to search the binary heap for.</param>
    /// <returns>A boolean, true if binary heap contains item.</returns>
    public bool Contains(T item)
    {
        EnsureSort();
        return Array.BinarySearch<T>(this.data, 0, this.count, item) >= 0;
    }
    /// <summary>
    /// Copies the binary heap to an array at the specified index.
    /// </summary>
    /// <param name="array">One dimensional array that is the destination of the copied elements.</param>
    /// <param name="arrayIndex">The zero-based index at which copying begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        EnsureSort();
        Array.Copy(this.data, array, this.count);
    }
    /// <summary>
    /// Gets whether or not the binary heap is readonly.
    /// </summary>
    public bool IsReadOnly
    {
        get { return false; }
    }
    /// <summary>
    /// Removes an item from the binary heap. This utilizes the type T's Comparer and will not remove duplicates.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns>Boolean true if the item was removed.</returns>
    public bool Remove(T item)
    {
        EnsureSort();
        int i = Array.BinarySearch<T>(this.data, 0, this.count, item);
        if (i < 0) return false;
        Array.Copy(this.data, i + 1, this.data, i, this.count - i);
        this.data[this.count] = default(T);
        this.count--;
        return true;
    }
}
