using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfStack
{
    class OurStack<T>
    {
        private T[] stackStorage;
        private int count;

        public int Count
        {
            get
            {
                return this.count;
            }
            private set { }
        }

        public OurStack()
        {
            this.stackStorage = new T[1];
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (this.Count==this.stackStorage.Length)
            {
                ResizeStackStorage();   
            }

            this.stackStorage[this.Count] = value;
            this.count += 1;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("OurStack is empty!");
            }
            T value = this.stackStorage[this.Count-1];
            this.count -= 1;

            return value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("OurStack is empty!");
            }
            T value = this.stackStorage[this.Count-1];

            return value;
        }

        public void Clear()
        {
            this.stackStorage = new T[1];
            this.count = 0;
        }

        public bool Contains(T value)
        {
            bool isContaining = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.stackStorage[i].Equals(value))
                {
                    isContaining = true;
                    break;
                }
            }

            return isContaining;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.stackStorage[i];
            }

            return newArray;
        }

        public void TrimExcess()
        {
            T[] newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.stackStorage[i];
            }
           
            this.stackStorage = newArray;
        }

        private void ResizeStackStorage()
        {
            T[] newStorage = new T[this.stackStorage.Length * 2];
            for (int i = 0; i < this.stackStorage.Length; i++)
            {
                newStorage[i] = this.stackStorage[i];
            }

            this.stackStorage = newStorage;
        }
    }
}
