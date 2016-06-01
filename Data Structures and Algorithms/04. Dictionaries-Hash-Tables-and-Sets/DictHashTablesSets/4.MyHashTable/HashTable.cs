namespace _4.MyHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<K, T> : IEnumerable
    {
        private readonly int StartCapacity = 16;
        private int capacity;
        private int count;
        private LinkedList<KeyValuePair<K, T>>[] data;
        private HashSet<K> keys;

        public HashTable()
        {
            this.capacity = StartCapacity;
            this.data = new LinkedList<KeyValuePair<K, T>>[this.StartCapacity];
            this.count = 0;
            this.keys = new HashSet<K>();
        }

        public int Count
        {
            get { return this.count; }
            private set
            {
                this.count = value;
            }
        }

        public HashSet<K> Keys
        {
            get { return this.keys; }
        }

        public LinkedList<KeyValuePair<K, T>> this[int i]
        {
            get { return this.data[i]; }
            set
            {
                if (value != null)
                {
                    this.data[i] = value;
                }
            }
        }

        private void ResizeDataContainer()
        {
            this.capacity = this.capacity * 2;
            var resizedDataContainer = new LinkedList<KeyValuePair<K, T>>[this.capacity];
            for (int i = 0, len = this.data.Length; i < len; i++)
            {
                resizedDataContainer[i] = this.data[i];
            }

            this.data = resizedDataContainer;
        }

        public void Add(K key, T value)
        {
            var shouldResizeContainer = this.capacity * 75 / 100 == this.Count;
            if (shouldResizeContainer)
            {
                ResizeDataContainer();
                // could add rehashing here
            }

            var hashCode = key.GetHashCode();
            var index = Math.Abs((hashCode % this.capacity));
            var currentEntry = new KeyValuePair<K, T>(key, value);
            var currentListNode = new LinkedListNode<KeyValuePair<K, T>>(currentEntry);
            if (this.data[index] == null)
            {
                this.data[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            this.data[index].AddLast(currentListNode);
            this.keys.Add(key);
            this.Count++;
        }

        public T Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can not be null!");
            }

            var hashCode = key.GetHashCode();
            var positionInCollection = Math.Abs((hashCode % this.capacity));
            var searchedValue = default(T);

            if (this.data[positionInCollection] == null || this.data[positionInCollection].Count == 0)
            {
                throw new InvalidOperationException("No entries to search into!");
            }

            foreach (var item in this.data[positionInCollection])
            {
                if (item.Key.Equals(key))
                {
                    searchedValue = item.Value;
                    break;  
                }
            }

            return searchedValue;
        }

        public bool Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can not be null!");
            }

            var hashCode = key.GetHashCode();
            var positionInCollection = Math.Abs((hashCode % this.capacity));
            var itemRemoved = false;

            var item = this.data[positionInCollection].First;
            while (item != null)
            {
                if (item.Value.Key.Equals(key))
                {
                    this.data[positionInCollection].Remove(item);
                    itemRemoved = true;
                    break;
                }

                item = item.Next;
            }

            this.keys.Remove(key);
            return itemRemoved;
        }

        public void Clear()
        {
            this.count = 0;
            this.data = new LinkedList<KeyValuePair<K, T>>[this.StartCapacity];
            this.keys = new HashSet<K>();
        }

        public IEnumerator GetEnumerator()
        {
            if (this.data != null)
            {
                for (int i = 0, len = this.data.Length; i < len; i++)
                {
                    if (this.data[i] != null)
                    {
                        foreach (var item in this.data[i])
                        {
                            yield return item;
                        }
                    }
                }
            }
        }
    }
}
