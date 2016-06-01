namespace PrintAllOrderedVariationsOfKFromN
{
    using System;

    public class PrintAllOrderedVariationsOfKFromN
    {
        public static string[] matrix;
            
        static void Main()
        {
            int n = 3;
            int k = 2;
            matrix = new string[k];
            var set = new string[] { "hi", "a", "b" }; 
            GenerateOrderedSubsets(n, set, 0, 0);
        }

        public static void GenerateOrderedSubsets(int n, string[] set, int startIndex, int minStartIndex)
        {
            if (startIndex >= matrix.Length)
            {
                var result = string.Join(" ", matrix);
                Console.WriteLine(result);
                return;
            }

            for (int i = minStartIndex; i < n; i++)
            {
                matrix[startIndex] = set[i];
                GenerateOrderedSubsets(n, set, startIndex + 1, minStartIndex);
            }
        }
    }
}
