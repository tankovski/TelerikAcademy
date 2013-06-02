using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfQueue
{
    class OurQueue<T>
    {
        private LinkedList<T> container;

        public int Count
        {
            get
            {
                return this.container.Count;
            }
            private set
            {
            }
        }

        public OurQueue()
        {
            this.container = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            this.container.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.container.First==null)
            {
                throw new ArgumentNullException("OurQueue is empty!");
            }
            T value = this.container.First.Value;
            this.container.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (this.container.First == null)
            {
                throw new ArgumentNullException("OurQueue is empty!");
            }
            T value = this.container.First.Value;
            
            return value;
        }

        public bool Contains(T value)
        {
            bool isContainig = this.container.Contains(value); ;

            return isContainig;
        }

        public T[] ToArray()
        {
           return this.container.ToArray();
        }
    }
}
