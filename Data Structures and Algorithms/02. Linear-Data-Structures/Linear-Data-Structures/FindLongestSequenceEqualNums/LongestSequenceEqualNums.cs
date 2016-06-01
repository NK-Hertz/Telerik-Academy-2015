namespace FindLongestSequenceEqualNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSequenceEqualNums
    {
        static void Main()
        {
            var sequence = new List<int>();
            var number = Console.ReadLine();
            while (!string.IsNullOrEmpty(number))
            {
                sequence.Add(int.Parse(number));
                number = Console.ReadLine();
            }

            var longestSequence = FindLongestSequenceOfEqualNums(sequence);
            var longestRepeatedNumber = longestSequence[0];
            var result = string.Join(", ", Enumerable.Repeat(
                    longestRepeatedNumber.ToString(),
                    longestSequence.Count));

            Console.WriteLine(result);
        }

        public static List<int> FindLongestSequenceOfEqualNums(List<int> sequence)
        {
            var numbersChecked = new List<int>();

            var maxRepeatedNumber = sequence[0];
            var maxNumberCount = 1;
            for (int i = 0, len = sequence.Count; i < len; i++)
            {
                var currentNumber = sequence[i];
                var currentNumberCount = 1;

                var currentNumberWasChecked = numbersChecked.Contains(currentNumber);
                if (!currentNumberWasChecked)
                {
                    numbersChecked.Add(currentNumber);

                    for (int j = i + 1; j < len; j++)
                    {
                        if (currentNumber == sequence[j])
                        {
                            currentNumberCount++;
                        }
                    }

                    if (currentNumberCount > maxNumberCount)
                    {
                        maxNumberCount = currentNumberCount;
                        maxRepeatedNumber = currentNumber;
                    }
                }
            }

            var longestSequenceOfEqualNums = new List<int>();
            for (int i = 0, len = maxNumberCount; i < len; i++)
            {
                longestSequenceOfEqualNums.Add(maxRepeatedNumber);
            }

            return longestSequenceOfEqualNums;
        }
    }
}
