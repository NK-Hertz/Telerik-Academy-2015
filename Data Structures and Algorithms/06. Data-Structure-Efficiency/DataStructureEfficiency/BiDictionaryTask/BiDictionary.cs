namespace BiDictionaryTask
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K, U, T>
    {
        private List<K> allFirstKeys;
        private List<U> allSecondKeys;
        private Dictionary<K, List<T>> firstData;
        private Dictionary<U, List<T>> secondData;

        public BiDictionary()
        {
            this.allFirstKeys = new List<K>();
            this.allSecondKeys = new List<U>();
            this.firstData = new Dictionary<K, List<T>>();
            this.secondData = new Dictionary<U, List<T>>();
        }

        public void Add(K firstKey, U secondKey, T value)
        {
            if (!this.allFirstKeys.Contains(firstKey))
            {
                this.allFirstKeys.Add(firstKey);
                this.firstData[firstKey] = new List<T>();
            
                this.allSecondKeys.Add(secondKey);
                this.secondData[secondKey] = new List<T>();
            }

            var indexOfFirstKey = this.allFirstKeys.IndexOf(firstKey);
            var indexOfSecondKey = this.allSecondKeys.IndexOf(secondKey);

            if (indexOfFirstKey != indexOfSecondKey)
            {
                throw new ArgumentException(
                    string.Format("Keys do not match the ones provided on setup: {0} {1}",
                        firstKey, secondKey)
                    );
            }

            var values = this.firstData[firstKey];
            values.Add(value);

            this.firstData.Remove(firstKey);
            this.firstData.Add(firstKey, values);

            this.secondData.Remove(secondKey);
            this.secondData.Add(secondKey, values);
        }

        public List<T> Find(K key)
        {
            return this.firstData[key];
        }

        public List<T> Find(U key)
        {
            return this.secondData[key];
        }

        public List<T> Find(K firstKey, U secondKey)
        {
            List<T> dataByFirstKey;
            List<T> dataBySecondKey;

            try
            {
                dataByFirstKey = this.firstData[firstKey];
                dataBySecondKey = this.secondData[secondKey];
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException("An error has occured! Make sure the set of keys you are using are for the same data!", ex);
            }

            return dataByFirstKey;
        }

        public List<T> Remove(K firstKey, U secondKey)
        {
            var values = this.firstData[firstKey];

            this.allFirstKeys.Remove(firstKey);
            this.allSecondKeys.Remove(secondKey);

            this.firstData.Remove(firstKey);
            this.secondData.Remove(secondKey);

            return values;
        }
    }
}
