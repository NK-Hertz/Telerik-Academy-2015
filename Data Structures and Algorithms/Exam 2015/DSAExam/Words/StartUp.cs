namespace Words
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            Node root = new Node();

            var word = Console.ReadLine();
            string[] patterns = new string[word.Length * 2];
            var occurences = new Dictionary<string, int>();
            for (int i = 0, strIndex = 0; i < word.Length; i++)
            {
                patterns[i + strIndex] = word.Substring(0, strIndex);
                patterns[i + 1 + strIndex] = word.Substring(strIndex);

                strIndex++;
            }

            for (int i = 1; i < patterns.Length; i++)
            {
                occurences[patterns[i]] = 0;
            }

            // Build tree

            for (int i = 0; i < patterns.Length; i++)
            {
                Node x = root;
                foreach (char c in patterns[i])
                {
                    if (x.Letter[c - 'a'] == null)
                    {
                        x.Letter[c - 'a'] = new Node();
                    }

                    x = x.Letter[c - 'a'];
                }
                x.Index = i;
            }

            // Compute fail links

            Queue<Node> q = new Queue<Node>();

            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node x = q.Dequeue();

                if (x.faillink != null)
                {
                    if (x.faillink.Index >= 0)
                    {
                        x.successlink = x.faillink;
                    }
                    else if (x.faillink.successlink != null)
                    {
                        x.successlink = x.faillink.successlink;
                    }
                }

                for (int i = 0; i < 26; i++)
                {
                    if (x.Letter[i] == null)
                    {
                        continue;
                    }

                    q.Enqueue(x.Letter[i]);

                    Node y = x.faillink;
                    while (y != null && y.Letter[i] == null)
                    {
                        y = y.faillink;
                    }

                    x.Letter[i].faillink = (y == null) ? root : y.Letter[i];
                }
            }

            // Search

            string text = Console.ReadLine();

            int n = text.Length;

            Node matched = root;
            for (int i = 0; i < n; i++)
            {
                while (matched != null && matched.Letter[text[i] - 'a'] == null)
                {
                    matched = matched.faillink;
                }

                matched = (matched == null) ? root : matched.Letter[text[i] - 'a'];

                //w, wo, wor, word
                if (matched.Index >= 0)
                {
                    if (!String.IsNullOrEmpty(patterns[matched.Index]))
                    {
                        occurences[patterns[matched.Index]]++;
                    }
                }

                // ord, rd, d
                for (Node x = matched.successlink; x != null; x = x.successlink)
                {
                    if (!String.IsNullOrEmpty(patterns[x.Index]))
                    {
                        occurences[patterns[x.Index]]++;
                    }
                }
            }

            long numberOfMatches = 0;

            // skiping first two indexes, cuz they are "" and the whole complete pattern word
            for (int i = 1, j = 1; i < word.Length; i++)
            {
                var preffixCount = occurences.ContainsKey(patterns[i + j]) ? occurences[patterns[i + j]] : 0;
                var suffixCount = occurences.ContainsKey(patterns[i + j + 1]) ? occurences[patterns[i + j + 1]] : 0;

                numberOfMatches += (preffixCount * suffixCount);

                j++;
            }

            // adding the complete pattern word
            numberOfMatches += occurences[patterns[1]];

            Console.WriteLine(numberOfMatches);
        }
    }
}
