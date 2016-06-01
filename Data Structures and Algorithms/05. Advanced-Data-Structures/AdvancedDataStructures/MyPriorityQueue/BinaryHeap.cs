namespace MyPriorityQueue
{
    public class BinaryHeap<T>
    {
        private readonly int Capacity = 16;
        private T[] data;
        private int count;

        public BinaryHeap()
        {
            this.count = 0;
            this.data = new T[this.Capacity];
        }

        private void Resize()
        {

        }
    }
}
