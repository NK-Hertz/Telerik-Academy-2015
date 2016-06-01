namespace MyQueueTask
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var myLinkedQueue = new LinkedQueue<string>();
            myLinkedQueue.Enqueue("hlqb");
            myLinkedQueue.Enqueue("banana");
            myLinkedQueue.Enqueue("bob");
            myLinkedQueue.Enqueue("sha umra ot glad, ama kato sum murzeliv...");
            string lastItem;
            for (int i = 0, length = myLinkedQueue.Count; i < length; i++)
            {
                Console.WriteLine(myLinkedQueue.Count);
                lastItem = myLinkedQueue.Dequeue();
                Console.WriteLine(lastItem);
            }
        }
    }
}
