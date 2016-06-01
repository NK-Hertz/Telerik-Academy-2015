namespace _3.CountWordOccurance
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class CountWordOccurance
    {
        static void Main()
        {
            var filePath = "../../../words.txt";
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                var fileText = reader.ReadToEnd().Trim();
                fileText = Regex.Replace(fileText, @"[^A-Za-z0-9- ]", string.Empty);
                var words = fileText.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                var numberOfOccurances = new Dictionary<string, int>();
                for (var i = 0; i < words.Length; i++)
                {
                    var currentWord = words[i].ToLower();
                    var valueKeyExists = numberOfOccurances.ContainsKey(currentWord);
                    if (!valueKeyExists)
                    {
                        numberOfOccurances[currentWord] = 0;
                    }

                    numberOfOccurances[currentWord]++;
                }

                foreach (var pair in numberOfOccurances.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                }
            }

        }
    }
}
