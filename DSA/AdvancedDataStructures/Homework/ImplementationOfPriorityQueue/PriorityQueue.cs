using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PriorityQueue<T>  where T : IComparable<T>
{
    private BinaryHeap<T> container;

    public int Count
    {
        get { return this.container.Count; }
        private set { }
    }

    public PriorityQueue()
    {
        this.container = new BinaryHeap<T>();
    }

    public void Enqueue(T element)
    {
        this.container.Add(element);
    }

    public T Dequeue()
    {
        T element = this.container.Remove();

        return element;
    }
}
