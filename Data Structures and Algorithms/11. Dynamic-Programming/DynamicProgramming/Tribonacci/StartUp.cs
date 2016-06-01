namespace Tribonacci
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var result = Solve(input[0], input[1], input[2], input[3]);
            Console.WriteLine(result);
        }

        private static long Solve(int v1, int v2, int v3, int n)
        {
            var arr = new long[n + 1];
            arr[0] = v1;
            arr[1] = v2;
            arr[2] = v3;

            for (int i = 3; i < n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
            }

            return arr[n - 1];
        }
    }
}
