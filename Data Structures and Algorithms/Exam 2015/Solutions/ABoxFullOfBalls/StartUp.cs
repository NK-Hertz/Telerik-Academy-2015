namespace ABoxFullOfBalls
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] turns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(turns);
            var ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            // this should be changed
            int[] dp = new int[ab[1] + 15];
            
            dp[ab[0]] = 0;
            for (int i = ab[0] + 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            var turnsCount = new int[ab[1] + 15];
            var roundsWonByMishi = 0;
            for (int i = ab[0], length = ab[1] - ab[0] + 1; i <= length; i++)
            {
                int x = 0;
                turnsCount[x] = 0;
                
                for (int j = 0; j < turns.Length; j++)
                {
                    while (x < i)
                    {
                        x += turns[j];
                        turnsCount[x] += (turnsCount[x - turns[j]] + 1);

                        if (x == i)
                        {
                            if (turnsCount[x] % 2 == 0)
                            {
                                roundsWonByMishi++;
                            }

                            break;
                        }
                    }
                }
            }

            Console.WriteLine(roundsWonByMishi);
        }
    }
}
