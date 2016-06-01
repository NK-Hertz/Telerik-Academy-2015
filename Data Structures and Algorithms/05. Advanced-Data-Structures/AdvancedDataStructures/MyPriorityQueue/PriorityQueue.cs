namespace MyPriorityQueue
{
    public class PriorityQueue<T>
    {
        private BinaryHeap<T> data;

        public PriorityQueue()
        {
            this.data = new BinaryHeap<T>();
        }
        // binary heap
        // insert with priority
        // pull element with highest priority and return it // pull - delete
        // peek - return heap[0]
    }
}
