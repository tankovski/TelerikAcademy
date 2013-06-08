using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OurHashTable<K, T> : IEnumerable<KeyValuePair<K,T>>
{
    //Fields
    private LinkedList<KeyValuePair<K, T>>[] container;
    private int capacity;
    private int count;

    //Properties
    public int Count
    {
        get { return this.count; }
        private set { }
    }

    public int Capacity
    {
        get { return this.capacity; }
        private set { }
    }

    public T this[K key]
    {
        get
        {
            return Find(key);
        }
        set
        {
            int index = key.GetHashCode() % this.container.Length;
            if (this.container[index] == null)
            {
                throw new ArgumentException("There is no element with this key");
            }
            else
            {
                bool isFind = false;
                var next = this.container[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        LinkedListNode<KeyValuePair<K, T>> node =
                            new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value));
                        this.container[index].AddAfter(next, node);
                        this.container[index].Remove(next);
                        isFind = true;
                        break;
                    }
                    next = next.Next;
                }
                if (isFind == false)
                {
                    throw new ArgumentException("There is no element with this key");
                }
            }
        }
    }

    public List<K> Keys
    {
        get
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < this.container.Length; i++)
            {
                if (this.container[i]!=null)
                {
                    var next = this.container[i].First;
                    while (next!=null)
                    {
                        keys.Add(next.Value.Key);
                        next = next.Next;
                    }
                }
            }
            return keys;
        }
        private set { }
    }

    //Constructor
    public OurHashTable()
    {
        this.container = new LinkedList<KeyValuePair<K, T>>[16];
        this.capacity = 0;
    }

    //Methods
    public void Add(K key, T value)
    {
        if (this.Capacity >= this.container.Length*0.75)
        {
            ResizeContainer();
        }

        int index = key.GetHashCode() % this.container.Length;
        if (this.container[index]==null)
        {
            this.capacity += 1;
            this.container[index] = new LinkedList<KeyValuePair<K, T>>();
        }

        var next = this.container[index].First;
        while (next!=null)
        {
            if (next.Value.Key.Equals(key))
            {
                throw new ArgumentException("There is such key already");
            }
            next = next.Next;
        }
        this.container[index].AddLast(new KeyValuePair<K, T>(key, value));
        this.count += 1;
    }

    public T Find(K key)
    {
        int index = key.GetHashCode() % this.container.Length;
        if (this.container[index]==null)
        {
            throw new ArgumentException("There is no element with this key");
        }
        else
        {
            var next = this.container[index].First;
            while (next!=null)
            {
                if (next.Value.Key.Equals(key))
                {
                    return next.Value.Value;
                }
                next = next.Next;
            }
            throw new ArgumentException("There is no element with this key");            
        }
    }

    public void Remove(K key)
    {
        int index = key.GetHashCode() % this.container.Length;
        if (this.container[index] == null)
        {
            throw new ArgumentException("There is no element with this key");
        }
        else
        {
            bool isFind = false;
            var next = this.container[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    this.container[index].Remove(next);
                    isFind = true;
                    this.count -= 1;
                    break;
                }
                next = next.Next;
            }
            if (this.container[index].First==null)
            {
                this.capacity -= 1;
            }
            if (isFind==false)
            {
                throw new ArgumentException("There is no element with this key");
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<KeyValuePair<K,T>> GetEnumerator()
    {
        for (int i = 0; i < this.container.Length; i++)
        {
            if (this.container[i] != null)
            {
                var next = this.container[i].First;
                while (next != null)
                {
                    yield return next.Value;
                    next = next.Next;
                }
            }
        }
    }


    private void ResizeContainer()
    {
        int length = this.container.Length * 2;
        LinkedList<KeyValuePair<K, T>>[] newContainer = new LinkedList<KeyValuePair<K, T>>[length];
        for (int i = 0; i < this.container.Length; i++)
        {
            newContainer[i] = this.container[i];
        }

        this.container = newContainer;
    }

}

