namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            
            T temp;
            for (int i = 0; i < collection.Count-1; i++)
            {
               
                for (int l = i+1; l < collection.Count; l++)
                {
                    if (collection[i].CompareTo(collection[l])>0)
                    {
                        temp = collection[i];
                        collection[i] = collection[l];
                        collection[l] = temp;
                    }
                }
            }
        }
    }
}
