namespace OddOccuringNumbersInSequence
{
    using System;
    using System.Collections.Generic;

    public class OddOccuringNumbersInSequence
    {
        static void Main()
        {
            //var sequence = new List<int>();

            //var number = Console.ReadLine();
            //while (!string.IsNullOrEmpty(number))
            //{
            //    sequence.Add(int.Parse(number));
            //    number = Console.ReadLine();
            //}

            var sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var oddOccuringNumbers = CheckForOddOccuringNumbers(sequence);
            var sequenceOfNonOddOccuringNumbers = RemoveOddOccuringNumbers(sequence, oddOccuringNumbers);

            for (int i = 0, len = sequenceOfNonOddOccuringNumbers.Count; i < len; i++)
            {
                Console.WriteLine("{0} ", sequenceOfNonOddOccuringNumbers[i]);
            }
        }

        public static List<int> RemoveOddOccuringNumbers(List<int> sequence, List<int> oddOccuringNumbers)
        {
            var result = new List<int>();
            for (int i = 0, len = sequence.Count; i < len; i++)
            {
                var currentNumber = sequence[i];
                var isCurrentNumberOddlyMetInSequence = oddOccuringNumbers.Contains(currentNumber);
                if (!isCurrentNumberOddlyMetInSequence)
                {
                    result.Add(currentNumber);
                }
            }

            return result;
        }

        public static List<int> CheckForOddOccuringNumbers(List<int> sequence)
        {
            var numbersChecked = new List<int>();
            var numbersOccuringOddTimes = new List<int>();
            for (int i = 0, len = sequence.Count; i < len; i++)
            {
                var currentNumber = sequence[i];
                if (!numbersChecked.Contains(currentNumber))
                {
                    numbersChecked.Add(currentNumber);

                    var timesNumberIsMet = 1;
                    for (int j = i + 1; j < len; j++)
                    {
                        if (sequence[j] == currentNumber)
                        {
                            timesNumberIsMet++;
                        }
                    }

                    if (timesNumberIsMet % 2 == 1)
                    {
                        numbersOccuringOddTimes.Add(currentNumber);
                    }
                }
            }

            return numbersOccuringOddTimes;
        }
    }
}
