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
            if (collection.Count <= 1)
            {
                return;
            }

            IList<T> left = new List<T>();
            IList<T> rigth = new List<T>();
            var middle = collection.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle, len = collection.Count; i < len; i++)
            {
                rigth.Add(collection[i]);
            }

            this.Sort(left);
            this.Sort(rigth);

            this.MergeCollection(collection, left, rigth);
        }

        private void MergeCollection(IList<T> collection, IList<T> left, IList<T> rigth)
        {
            var minLength = left.Count > rigth.Count ? rigth.Count : left.Count;

            var leftIndex = 0;
            var rigthIndex = 0;
            var collectionIndex = 0;
            while (leftIndex < minLength || rigthIndex < minLength)
            {
                if (leftIndex == minLength)
                {
                    collection[collectionIndex] = rigth[rigthIndex];
                    break;
                }

                if (rigthIndex == minLength)
                {
                    collection[collectionIndex] = left[leftIndex];
                    break;
                }

                if (left[leftIndex].CompareTo(rigth[rigthIndex]) == 1)
                {
                    collection[collectionIndex] = rigth[rigthIndex];
                    rigthIndex++;
                    collectionIndex++;
                }
                else
                {
                    collection[collectionIndex] = left[leftIndex];
                    leftIndex++;
                    collectionIndex++;
                }
            }

            var biggerCollection = left.Count > rigth.Count ? left : rigth;
            if (left.Count != rigth.Count)
            {
                collection[++collectionIndex] = biggerCollection[biggerCollection.Count - 1];
            }
        }
    }
}
