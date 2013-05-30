using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfLinkedList
{
    class OurLinkedList<T>
    {
        private ListItem<T> firstElement;

        public int Count
        {
            get
            {
                int count = CalculateCount();
                return count;
            }
            private set { }
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }
            set
            {
                this.firstElement = value;
            }
        }

        public OurLinkedList()
        {
            this.FirstElement = null;
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement==null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newListItem = new ListItem<T>(value);
                newListItem.NextItem = this.FirstElement;
                this.FirstElement = newListItem;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstElement==null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> next = this.FirstElement;

                while (next.NextItem!=null)
                {
                    next = next.NextItem;
                }

                next.NextItem = new ListItem<T>(value);
            }
        }

        //AddAfter and AddBefore dont work very good becouse they taka every ListItem thah you give like parameter
        public void AddAfter(ListItem<T> item,T value)
        {
            ListItem<T> next = this.FirstElement;
            while (next != item && next != null)
            {
                next = next.NextItem;
                if (next == null)
                {
                    throw new ArgumentException("The ListItem do not belong to OurLinkedList!");
                }
            }
            ListItem<T> newItem = new ListItem<T>(value);
            newItem.NextItem = next.NextItem;
            next.NextItem = newItem;
        }

        public void AddBefore(ListItem<T> item,T value)
        {
            if (item==this.FirstElement)
            {
                ListItem<T> newList = new ListItem<T>(value);
                newList.NextItem = this.FirstElement;
                this.FirstElement = newList;
            }
            else
            {
                ListItem<T> next = this.FirstElement;

                while (next.NextItem!=item)
                {
                    next = next.NextItem;
                    if (next==null)
                    {
                         throw new ArgumentException("The ListItem do not belong to OurLinkedList!");
                    }
                }
                
                    ListItem<T> newList = new ListItem<T>(value);
                    newList.NextItem = next.NextItem;
                    next.NextItem = newList;
                
               
            }
        }

        public void RemoveFirst()
        {
            this.FirstElement = this.FirstElement.NextItem;
        }

        public void RemoveLast()
        {
            ListItem<T> next = this.FirstElement;

            while (next.NextItem !=  null)
            {
                next = next.NextItem;
            }
            ListItem<T> again = this.FirstElement;
            while (again.NextItem!=next)
            {
                again = again.NextItem;
            }
            again.NextItem = null;
        }

        private int CalculateCount()
        {
            int count = 1;
            ListItem<T> next = this.FirstElement;

            while (next.NextItem != null)
            {
                next = next.NextItem;
                count += 1;
            }

            return count;
        }
    }
}
