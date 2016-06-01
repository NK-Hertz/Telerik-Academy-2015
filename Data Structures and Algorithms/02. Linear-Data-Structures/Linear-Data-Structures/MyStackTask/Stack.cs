namespace MyStackTask
{
    using System;

    public class Stack<T>
    {
        private T[] values;
        private int lastIndex;

        public Stack()
        {
            this.values = new T[1];
            this.lastIndex = 0;
        }

        private T[] ResizeContainer()
        {
            var length = (lastIndex + 1) * 2;
            var resultContainer = new T[length];
            for (int i = 0, len = lastIndex; i < len; i++)
            {
                resultContainer[i] = this.values[i];
            }

            return resultContainer;
        }

        public int Count
        {
            get { return this.lastIndex; }
        }

        public T Peek()
        {
            return this.values[lastIndex - 1];
        }

        public void Push(T value)
        {
            var isEndOfContainerReached = this.values.Length < Count + 1;
            if (isEndOfContainerReached)
            {
                this.values = ResizeContainer();
            }

            this.values[this.lastIndex] = value;
            this.lastIndex++;
        }

        public T Pop(T value)
        {
            if (this.lastIndex - 1 < 0)
            {
                throw new InvalidOperationException("Sequence contains no elements!");
            }

            var removedValue = this.values[this.lastIndex];
            this.lastIndex--;

            return removedValue;
        }
    }
}
