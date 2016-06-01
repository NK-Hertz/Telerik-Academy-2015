namespace SortNumbersInIncreasingOrder
{
    using System;
    using System.Collections.Generic;

    public class SortNumbersInIncreasingOrder
    {
        static void Main()
        {
            var sequence = new List<int>();
            Console.WriteLine("Enter a positive integer: ");
            var number = Console.ReadLine();
            while (!string.IsNullOrEmpty(number))
            {
                sequence.Add(int.Parse(number));
                number = Console.ReadLine();
            }

            sequence.Sort();
            Console.WriteLine("Sorted: ");
            for (int i = 0, len = sequence.Count; i < len; i++)
            {
                Console.WriteLine(sequence[i]);
            }
        }
    }
}
