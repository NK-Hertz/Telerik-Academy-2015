namespace _2.ExtractOddOccuringStr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtractOddOccuringStr
    {
        static void Main()
        {
            var sequence = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var numberOfOccurances = new Dictionary<string, int>();
            foreach (var item in sequence)
            {
                var valueKeyExists = numberOfOccurances.ContainsKey(item);
                if (!valueKeyExists)
                {
                    numberOfOccurances[item] = 0;
                }

                numberOfOccurances[item]++;
            }

            var sequenceWithOddOccuringValues = new List<string>();
            foreach (var item in numberOfOccurances)
            {
                var occursOddTimes = item.Value % 2 != 0;
                if (occursOddTimes)
                {
                    sequenceWithOddOccuringValues.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", sequenceWithOddOccuringValues));
        }
    }
}
