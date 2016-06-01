namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoveNegativeNumbers
    {
        static void Main()
        {
            var sequence = new List<int>();

            Console.WriteLine("Enter a number: ");
            var number = Console.ReadLine();
            while (!string.IsNullOrEmpty(number))
            {
                sequence.Add(int.Parse(number));
                number = Console.ReadLine();
            }

            var nonNegativeSequence = new List<int>();
            for (int i = 0, len = sequence.Count; i < len; i++)
            {
                var currentNumber = sequence[i];
                if (currentNumber > 0)
                {
                    nonNegativeSequence.Add(currentNumber);
                    Console.WriteLine(currentNumber);
                }
            }
        }
    }
}
