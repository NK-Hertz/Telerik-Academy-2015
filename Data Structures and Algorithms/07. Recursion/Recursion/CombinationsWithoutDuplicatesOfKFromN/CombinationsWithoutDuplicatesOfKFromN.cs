namespace CombinationsWithoutDuplicatesOfKFromN
{
    using System;

    public class CombinationsWithoutDuplicatesOfKFromN
    {
        public static int[] matrix;
        static void Main()
        {
            int n = 4;
            int k = 2;
            matrix = new int[k];
            CombinationsWithoutOfKFromN(0, 0, n);
        }

        public static void CombinationsWithoutOfKFromN(int startIndex, int minStartNumber, int n)
        {
            if (startIndex >= matrix.Length)
            {
                Console.WriteLine(string.Join(" ", matrix));
                return;
            }

            for (int i = 0; i <= n; i++)
            {
                if (i > minStartNumber)
                {
                    matrix[startIndex] = i;
                    CombinationsWithoutOfKFromN(startIndex + 1, i, n);
                }
            }
        }
    }
}
