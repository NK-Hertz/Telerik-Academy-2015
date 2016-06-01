using System;

namespace MyQueueTask
{
    public class LinkedQueue<T>
    {
        private LinkedQueueNode head;
        private LinkedQueueNode tail;

        private class LinkedQueueNode
        {
            public LinkedQueueNode()
            {
                this.Next = null;
            }

            public LinkedQueueNode(T value)
                : base()
            {
                this.Value = value;
            }

            public T Value { get; private set; }
            public LinkedQueueNode Next { get; set; }
        }

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        private LinkedQueueNode Enqueue(LinkedQueueNode node , T value)
        {
            if (node == null)
            {
                node = new LinkedQueueNode(value); ;
                this.tail = new LinkedQueueNode(value);
                this.Count++;
                return node;
            }

            node.Next = this.Enqueue(node.Next, value);

            return node;
        }

        public void Enqueue(T value)
        {
            this.head = this.Enqueue(this.head, value);
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Can not remove element when the queue is empty!");
            }

            var elementToRemove = this.head;
            if (this.head.Next != null)
            {
                var node = this.head.Next;
                this.head = node;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return elementToRemove.Value;
        }
    }
}
