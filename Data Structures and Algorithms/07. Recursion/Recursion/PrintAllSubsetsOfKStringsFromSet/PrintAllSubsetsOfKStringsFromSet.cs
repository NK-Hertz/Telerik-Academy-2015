namespace PrintAllSubsetsOfKStringsFromSet
{
    using System;

    public class PrintAllSubsetsOfKStringsFromSet
    {
        public static string[] matrix;

        static void Main()
        {
            var k = 2;
            matrix = new string[k];
            var set = new string[] { "test", "rock", "fun" }; // , "slice"
            GenerateAllSubsets(set, 0, 0);
        }

        public static void GenerateAllSubsets(string[] set, int matrixIndex, int startIndex)
        {
            if (matrixIndex >= matrix.Length)
            {
                var result = string.Join(" ", matrix);
                Console.WriteLine(result);
                return;
            }

            for (int i = startIndex, len = set.Length; i < len; i++)
            {
                matrix[matrixIndex] = set[i];
                GenerateAllSubsets(set, matrixIndex + 1, i + 1);
            }
        }
    }
}
