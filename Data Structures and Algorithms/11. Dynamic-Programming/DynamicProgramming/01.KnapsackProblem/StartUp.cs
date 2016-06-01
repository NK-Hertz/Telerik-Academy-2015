namespace _01.KnapsackProblem
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            // products
            //int n = int.Parse(Console.ReadLine());
            var weight = new[] { 3, 8, 4, 1, 2, 8 };
            var cost = new[] { 2, 12, 5, 4, 3, 13 };
            var capacity = 10;

            Console.WriteLine("Max sum of weight: {0}", weight.Sum());
            Console.WriteLine("Max sum of value: {0}", cost.Sum());
            Console.WriteLine("Numbers: {0}", string.Join(", ", weight));
            Console.WriteLine("Costs: {0}", string.Join(", ", cost));
            
            Console.WriteLine("Capacity: {0}", capacity);
            Solve(weight, cost, capacity);
        }

        private static void Solve(int[] weights, int[] costs, int capacity)
        {
            var sum = weights.Sum();
            if (capacity > sum)
            {
                capacity = sum;
            }

            var resultMatrix = new int[weights.Length + 1, capacity + 1];
            //for (int i = 0; i < resultMatrix.GetLength(1); i++)
            //{
            //    resultMatrix[0, i] = 0;
            //}

            for (int i = 1, length = resultMatrix.GetLength(0); i < length; i++)
            {
                for (int j = 0, len = resultMatrix.GetLength(1); j < len; j++)
                {
                    if (weights[i - 1] > j)
                    {
                        resultMatrix[i, j] = resultMatrix[i - 1, j];
                    }
                    else
                    {
                        resultMatrix[i, j] = Math.Max(resultMatrix[i - 1, j], resultMatrix[i - 1, j - weights[i - 1]] + costs[i - 1]);
                    }
                }
            }

            var lastI = resultMatrix.GetLength(0) - 1;
            var lastJ = resultMatrix.GetLength(1) - 1;
            Console.WriteLine("Value: {0}", resultMatrix[lastI, lastJ]);
        }
    }
}
