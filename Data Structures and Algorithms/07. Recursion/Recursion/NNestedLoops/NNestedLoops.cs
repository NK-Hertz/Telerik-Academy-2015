namespace NNestedLoops
{
    using System;

    public class NNestedLoops
    {
        public static int[] matrix;

        static void Main()
        {
            Console.WriteLine("Enter n = number of nested loops: ");
            var n = int.Parse(Console.ReadLine());
            //int n = 3;
            matrix = new int[n];
            SimulateNestedLoops(0, n);
        }

        public static void SimulateNestedLoops(int startIndex, int totalLoops)
        {
            if (startIndex >= matrix.Length)
            {
                PrintMatrix();
                return;
            }

            for (int i = 1; i <= totalLoops; i++)
            {
                matrix[startIndex] = i;
                SimulateNestedLoops(startIndex + 1, totalLoops);
            }
        }

        public static void PrintMatrix()
        {
            var result = string.Join(", ", matrix);
            Console.WriteLine(result);
        }
    }
}
