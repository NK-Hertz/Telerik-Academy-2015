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
            for (int i = 0, len = collection.Count - 1; i < len; i++)
            {
                int minElementPosition = i;
                for (int j = i + 1, length = collection.Count; j < length; j++)
                {
                    var smallerElementFound = 
                            collection[j].CompareTo(collection[minElementPosition]) < 0;
                    if (smallerElementFound)
                    {
                        minElementPosition = j;
                    }
                }

                if (minElementPosition != i)
                {
                    var elementToBeSwappedFromI = collection[i];
                    collection[i] = collection[minElementPosition];
                    collection[minElementPosition] = elementToBeSwappedFromI;
                }
            }
        }
    }
}
