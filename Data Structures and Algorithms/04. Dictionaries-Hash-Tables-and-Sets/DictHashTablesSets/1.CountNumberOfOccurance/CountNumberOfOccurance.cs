namespace _1.CountNumberOfOccurance
{
    using System;
    using System.Collections.Generic;

    public class CountNumberOfOccurance
    {
        static void Main()
        {
            var array = new double[]{ 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var numberOfOccurances = new Dictionary<double, int>();
            foreach (var item in array)
            {
                var valueKeyExists = numberOfOccurances.ContainsKey(item);
                if (!valueKeyExists)
                {
                    numberOfOccurances[item] = 0;
                }

                numberOfOccurances[item]++;
            }

            foreach (var pair in numberOfOccurances)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
