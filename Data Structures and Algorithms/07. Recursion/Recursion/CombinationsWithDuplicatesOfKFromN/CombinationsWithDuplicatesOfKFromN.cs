namespace CombinationsWithDuplicatesOfKFromN
{
    using System;

    public class CombinationsWithDuplicatesOfKFromN
    {
        public static int[] matrix;
        static void Main()
        {
            int n = 3;
            int k = 2;
            matrix = new int[k];
            CombinationsWithOfKFromN(0, 1, n);
        }

        public static void CombinationsWithOfKFromN(int startIndex, int minStartNumberInclusive, int n)
        {
            if (startIndex >= matrix.Length)
            {
                Console.WriteLine(string.Join(" ", matrix));
                return;
            }

            for (int i = minStartNumberInclusive; i <= n; i++)
            {
                matrix[startIndex] = i;
                CombinationsWithOfKFromN(startIndex + 1, i, n);
            }
        }
    }
}
