namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExecuteBinarySearch(T item, int min, int max)
        {
            if (max < min)
            {
                return false;
            }
            else
            {
                int mid = min + ((max - min) / 2);

                if (this.Items[mid].CompareTo(item) == 1)
                {
                    return ExecuteBinarySearch(item, min, mid - 1);
                }
                else if (this.Items[mid].CompareTo(item) == -1)
                {
                    return ExecuteBinarySearch(item, mid + 1, max);
                }
                else
                {
                    return true;
                }
            }
        }

        public bool BinarySearch(T item)
        {
            return ExecuteBinarySearch(item, 0, this.items.Count);
        }

        public static class RandomProvider
        {
            private static Random instance = new Random();

            public static Random Instance
            {
                get { return instance; }
            }
        }

        public void Shuffle()
        {
            for (int i = 0, len = this.Items.Count; i < len; i++)
            {
                int randomPosition = i + RandomProvider.Instance.Next(0, len - i);
                var placeholder = this.Items[i];
                this.Items[i] = this.Items[randomPosition];
                this.Items[randomPosition] = placeholder;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
