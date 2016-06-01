namespace MinimumEditDistance
{
    using System;

    class StartUp
    {
        private static readonly double InsertValue = 0.8;
        private static readonly double RemoveValue = 0.9;
        private static readonly double SubstituteValue = 1.0;

        static void Main()
        {
            //Console.WriteLine("Enter first string: ");
            //var stringOne = Console.ReadLine();
            //Console.WriteLine("Enter second string: ");
            //var stringTwo = Console.ReadLine();

            var developer = "developer"; 
            var enveloped = "enveloped";
            CalculateMED(developer, enveloped);

            var man = "ANTS";
            var can = "GNU";
            CalculateMED(man, can);
        }

        private static void CalculateMED(string n, string m)
        {
            var distance = new double[n.Length + 1, m.Length + 1];
            for (int i = 0; i <= n.Length; i++)
            {
                distance[i, 0] = InsertValue * i;
            }

            for (int i = 0; i <= m.Length; i++)
            {
                distance[0, i] = RemoveValue * i;
            }

            for (int i = 1; i <= n.Length; i++)
            {
                for (int j = 1; j <= m.Length; j++)
                {
                    double valueForSubstitution = 0;
                    if (n[i - 1] != m[j - 1])
                    {
                        valueForSubstitution = SubstituteValue;
                    }

                    distance[i, j] = Math.Min(distance[i - 1, j - 1] + valueForSubstitution, 
                                    Math.Min(distance[i - 1, j] + InsertValue, distance[i, j - 1] + RemoveValue)
                                    );

                    //var currentValue = Math.Min(Math.Min(distance[i - 1, j] + 1,
                    //                distance[i, j - 1] + 1),
                    //                distance[i - 1, j - 1] + valueForSubstitution);
                    //distance[i, j] = currentValue; 
                }
            }

            var MED = distance[n.Length, m.Length];
            Console.WriteLine("x = \"{0}\", y = \"{1}\" -> {2}", n, m, MED);
        }
    }
}
