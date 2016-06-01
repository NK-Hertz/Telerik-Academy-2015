namespace SuperSum
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var kn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var result = Solve(kn[0], kn[1]);
            Console.WriteLine(result);
        }

        private static int Solve(int k, int n)
        {
            var superSumResult = new int[k + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                superSumResult[0, i] = i;
            }

            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int p = 1; p <= j; p++)
                    {
                        if (i == 1)
                        {
                            superSumResult[i, j] += superSumResult[0, p];
                        }
                        else
                        {
                            superSumResult[i, j] += superSumResult[i - 1, p];
                        }
                    }
                }
            }

            return superSumResult[k, n];
        }
    }
}
