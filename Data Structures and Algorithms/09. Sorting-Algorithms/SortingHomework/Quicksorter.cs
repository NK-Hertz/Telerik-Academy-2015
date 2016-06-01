namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            var pivot = this.GetPivot(collection);
            // pivot = (hi-low)/2
            collection.Remove(pivot);

            var less = new List<T>();
            var greater = new List<T>();

            for (int i = 0, len = collection.Count; i < len; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    less.Add(collection[i]);
                }
                else
                {
                    greater.Add(collection[i]);
                }
            }

            this.Sort(less);
            this.Sort(greater);

            this.MergeCollection(collection, less, pivot, greater);
        }

        private void MergeCollection(IList<T> collection, IList<T> less, T pivot, IList<T> greater)
        {
            collection.Clear();
            for (int i = 0, len = less.Count; i < len; i++)
            {
                collection.Add(less[i]);
            }

            collection.Add(pivot);

            for (int i = 0, len = greater.Count; i < len; i++)
            {
                collection.Add(greater[i]);
            }
        }

        private T GetPivot(IList<T> collection)
        {
            var first = collection[0];
            var middleIndex = collection.Count / 2;
            var middle = collection[middleIndex];
            var last = collection[collection.Count - 1];

            if (first.CompareTo(middle) == -1)
            {
                if (middle.CompareTo(last) == -1)
                {
                    return middle;
                }
                else if (middle.CompareTo(last) == 1)
                {
                    if (first.CompareTo(last) == -1)
                    {
                        return last;
                    }
                    else
                    {
                        return first;
                    }
                }
                else
                {
                    return first;
                }
            }
            else if (first.CompareTo(middle) == 1)
            {
                if (first.CompareTo(last) == -1)
                {
                    return first;
                }
                else if (first.CompareTo(last) == 1)
                {
                    if (middle.CompareTo(last) == -1)
                    {
                        return last;
                    }
                    else
                    {
                        return middle;
                    }
                }
                else
                {
                    return middle;
                }
            }
            else
            {
                // all are equal
                return middle;
            }
        }
    }
}
