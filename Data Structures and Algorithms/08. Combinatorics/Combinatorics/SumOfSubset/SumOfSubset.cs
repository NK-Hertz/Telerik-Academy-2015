namespace SumOfSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfSubset
    {
        public static void Main()
        {
            int testExamplesCount = int.Parse(Console.ReadLine());
            for (int i = 0, len = testExamplesCount; i < len; i++)
            {
                var nk = Console.ReadLine().Split(' ').ToList();
                var currentN = int.Parse(nk[0]);
                var currentK = int.Parse(nk[1]);
                var elements = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToList();
                var sum = CalculateCombinations(elements, currentN - 1, currentK, 0, 0);
                Console.WriteLine(sum);
            }
        }

        private static long CalculateCombinations(List<int> numbers, int n, int k, int index, int start)
        {
            long nominator = 1;
            for (int i = n; i >= (n - k + 1); i--)
            {
                nominator *= i;
            }

            long denominator = 1;
            for (int i = k; i >= 1; i--)
            {
                denominator *= i;
            }

            long binomResult = (nominator / denominator);

            long sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return binomResult * sum;
        }
    }
}
