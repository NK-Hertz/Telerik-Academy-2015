namespace MyLinkListTask
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var myLinkedList = new LinkedList<int>();
            myLinkedList.FirstElement = new ListItem<int>(5, new ListItem<int>(11));

            var item = myLinkedList.FirstElement;
            Console.WriteLine(item.Value);
            Console.WriteLine(item.NextItem.Value);
        }
    }
}
