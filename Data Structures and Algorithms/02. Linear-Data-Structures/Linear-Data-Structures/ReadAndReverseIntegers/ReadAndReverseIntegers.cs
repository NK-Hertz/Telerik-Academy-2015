namespace ReadAndReverseIntegers
{
    using System;
    using System.Collections.Generic;

    public class ReadAndReverseIntegers
    {
        static void Main()
        {
            Console.WriteLine("Enter number of integers: ");
            var numberCount = int.Parse(Console.ReadLine());
            var myStack = new Stack<int>();
            while (numberCount > 0)
            {
                var number = int.Parse(Console.ReadLine());
                myStack.Push(number);
                numberCount--;
            }

            Console.WriteLine("Reversed");
            for (int i = 0, len = myStack.Count; i < len; i++)
            {
                var numberToPrint = myStack.Peek();
                Console.WriteLine(numberToPrint);
                myStack.Pop();
            }
        }
    }
}
