namespace FindASetOfWordsInBigFile
{
    using Gma.DataStructures.StringSearch;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class FindASetOfWordsInBigFile
    {
        static void Main()
        {
            var hundredMB = 104857600;
            var littlePrincePath = "The_Little_Prince.txt";
            string littlePrince = null;
            var wordsToLookUp = new HashSet<string>();
            using (StreamReader reader = new StreamReader(littlePrincePath))
            {
                littlePrince = reader.ReadToEnd();
                var fileText = littlePrince.Trim();
                fileText = Regex.Replace(fileText, @"[^A-Za-z0-9- ]", string.Empty);
                var words = fileText.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                var index = 0;
                while (wordsToLookUp.Count < 1000)
                {
                    wordsToLookUp.Add(words[index]);
                    index++;
                }
            }

            var hundredMBFilePath = "../../100MBFile.txt";
            using (var fs = File.Create(hundredMBFilePath))
            { }

            Console.WriteLine("Creating 100MB file!");

            var file = new FileInfo(hundredMBFilePath);
            var fileSize = file.Length;
            while (fileSize < hundredMB)
            {
                var w = file.AppendText();
                w.WriteLine(littlePrince);
                w.Close();
                file.Refresh();
                fileSize = file.Length;
            }

            Console.WriteLine("File created!");

            var trie = new Trie<int>();
            BuildUp(hundredMBFilePath, trie);

            Console.WriteLine("Search beginning!");

            foreach (var word in wordsToLookUp)
            {
                LookUp(word, trie);
            }
        }

        private static void BuildUp(string fileName, ITrie<int> trie)
        {
            IEnumerable<WordAndLine> allWordsInFile = GetWordsFromFile(fileName);
            foreach (WordAndLine wordAndLine in allWordsInFile)
            {
                trie.Add(wordAndLine.Word, wordAndLine.Line);
            }
        }

        private static void LookUp(string searchString, ITrie<int> trie)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Look-up for string '{0}'", searchString);
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int[] result = trie.Retrieve(searchString).ToArray();
            stopWatch.Stop();

            string matchesText = String.Join(",", result);
            int matchesCount = result.Count();

            if (matchesCount == 0)
            {
                Console.WriteLine("No matches found.\tTime: {0}", stopWatch.Elapsed);
            }
            else
            {
                Console.WriteLine(" {0} matches found. \tTime: {1}\t",
                              matchesCount,
                              stopWatch.Elapsed);
            }
        }


        private static IEnumerable<WordAndLine> GetWordsFromFile(string file)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                Console.WriteLine("Processing file {0} ...", file);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                int lineNo = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lineNo++;
                    IEnumerable<string> words = GetWordsFromLine(line);
                    foreach (string word in words)
                    {
                        yield return new WordAndLine { Line = lineNo, Word = word };
                    }
                }
                stopWatch.Stop();
                Console.WriteLine("Lines:{0}\tTime:{1}", lineNo, stopWatch.Elapsed);
            }
        }

        private static IEnumerable<string> GetWordsFromLine(string line)
        {
            var word = new StringBuilder();
            foreach (char ch in line)
            {
                if (char.IsLetter(ch))
                {
                    word.Append(ch);
                }
                else
                {
                    if (word.Length == 0) continue;
                    yield return word.ToString();
                    word.Clear();
                }
            }
        }

        private struct WordAndLine
        {
            public int Line;
            public string Word;
        }
    }
}
