namespace AverageFromPositiveSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AverageFromPositiveSequence
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

            var average = sequence.Average();
            Console.WriteLine("Average : {0}", average);
            var sum = sequence.Sum();
            Console.WriteLine("Sum : {0}", sum);
        }
    }
}
