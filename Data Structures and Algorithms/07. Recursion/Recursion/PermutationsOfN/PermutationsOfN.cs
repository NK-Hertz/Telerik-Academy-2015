namespace PermutationsOfN
{
    using System;
    using System.Collections.Generic;

    public class PermutationsOfN
    {
        static void Main()
        {
            int n = 3;
            var numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            Permute(numbers, 0, n);
        }

        public static void Permute(int[] numbers, int position, int maxNumber)
        {
            if (position >= numbers.Length)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            Permute(numbers, position + 1, maxNumber);
            for (int i = position + 1; i < numbers.Length; i++)
            {
                Swap(ref numbers[position], ref numbers[i]);
                Permute(numbers, position + 1, maxNumber);
                Swap(ref numbers[position], ref numbers[i]);
            }
        }

        public static void Swap(ref int first, ref int second)
        {
            var valueOfFirst = first;
            first = second;
            second = valueOfFirst;
        }
    }
}
