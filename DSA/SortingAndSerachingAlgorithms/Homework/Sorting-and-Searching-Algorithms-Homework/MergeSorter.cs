namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count > 1)
            {
                List<T> left = new List<T>();
                List<T> right = new List<T>();

                for (int i = 0; i < collection.Count / 2; i++)
                {
                    left.Add(collection[i]);
                }

                for (int i = collection.Count / 2; i < collection.Count; i++)
                {
                    right.Add(collection[i]);
                }

                Sort(left);
                Sort(right);
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    if (left.Count==0)
                    {
                        collection[i] = right.Last();
                        right.Remove(right.Last());
                    }
                    else if (right.Count==0)
                    {
                        collection[i] = left.Last();
                        left.Remove(left.Last());
                    }
                    else if (left.Last().CompareTo(right.Last())>0)
                    {
                        collection[i] = left.Last();
                        left.Remove(left.Last());
                    }
                    else
                    {
                        collection[i] = right.Last();
                        right.Remove(right.Last());
                    }
                }
            }
        }
    }
}
