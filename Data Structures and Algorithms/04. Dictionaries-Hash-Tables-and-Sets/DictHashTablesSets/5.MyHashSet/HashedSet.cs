namespace _5.MyHashSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using _4.MyHashTable;

    // the solution is to make the hashtable<int, T>
    // and for every value which is being inserted, it`s key representation to be
    // value.GetHashCode();
    // still doubt that null will pass as value
    public class HashedSet<T> : IEnumerable<T>
    {
        private int count;
        private HashTable<T, T> data;

        public HashedSet()
        {
            this.count = 0;
            this.data = new HashTable<T, T>();
        }

        public void Add(T value)
        {
            var valueAlreadyExists = this.data.Keys.Contains(value);
            if (!valueAlreadyExists)
            {
                this.data.Add(value, value);
                this.count++;
            }
        }

        public T Find(T value)
        {
            var isValueFound = this.data.Find(value);
            return isValueFound;
        }

        public bool Remove(T value)
        {
            var isValueRemoved = this.data.Remove(value);
            this.count--;
            return isValueRemoved;
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Clear()
        {
            this.count = 0;
            this.data = new HashTable<T, T>();
        }

        public void Union(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Union cannot be made with null collection!");
            }

            var keys = this.data.Keys;
            foreach (var item in collection)
            {
                if (!keys.Contains(item))
                {
                    this.Add(item);
                }
            }
        }

        public void Intersect(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Union cannot be made with null collection!");
            }

            var shared = new List<T>();
            var keys = this.data.Keys;
            foreach (var item in collection)
            {
                if (keys.Contains(item))
                {
                    shared.Add(item);
                }
            }

            this.Clear();

            foreach (var item in shared)
            {
                this.Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var key in this.data.Keys)
            {
                yield return key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
