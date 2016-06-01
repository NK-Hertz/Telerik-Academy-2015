namespace MyStackTask
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var myStack = new Stack<int>();
            myStack.Push(5);
            Console.WriteLine(myStack.Count);
            myStack.Push(11);
            Console.WriteLine(myStack.Count);

            Console.WriteLine(myStack.Peek());
        }
    }
}
