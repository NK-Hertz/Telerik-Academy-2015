namespace Brackets
{
    using System;

    class StartUp
    {
        enum Brackets { OpeningBracket = '(', ClosingBracket = ')', FreeSlot = '?' };
        private static long PossibleSolutionsCount = 0;
        private static int ClosingBracketCount = 0;

        static void Main()
        {
            var input = Console.ReadLine();
            //SolveRecursively(input.ToCharArray(), 0);
            //Console.WriteLine(PossibleSolutionsCount);

            SolveDynamically(input.ToCharArray());
            Console.WriteLine(PossibleSolutionsCount);
        }

        private static void SolveRecursively(char[] input, int currentIndex)
        {
            if (currentIndex >= input.Length || ClosingBracketCount > 0)
            {
                //Console.WriteLine(ClosingBracketCount);
                //Console.WriteLine(input);

                if (ClosingBracketCount == 0)
                {
                    PossibleSolutionsCount++;
                    //Console.WriteLine(input);
                }

                return;
            }

            if (input[currentIndex] == (char)Brackets.OpeningBracket)
            {
                ClosingBracketCount--;
                SolveRecursively(input, currentIndex + 1);
                ClosingBracketCount++;
            }
            else if (input[currentIndex] == (char)Brackets.ClosingBracket)
            {
                ClosingBracketCount++;
                SolveRecursively(input, currentIndex + 1);
                ClosingBracketCount--;
            }

            if (input[currentIndex] == (char)Brackets.FreeSlot)
            {
                input[currentIndex] = (char)Brackets.OpeningBracket;
                SolveRecursively(input, currentIndex);

                input[currentIndex] = (char)Brackets.ClosingBracket;
                SolveRecursively(input, currentIndex);

                input[currentIndex] = (char)Brackets.FreeSlot;
            }
        }

        private static void SolveDynamically(char[] input)
        {
            var bracketToUse = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == (char)Brackets.ClosingBracket)
                {
                    ClosingBracketCount++;
                }
                else if (input[i] == (char)Brackets.OpeningBracket)
                {
                    ClosingBracketCount--;
                }

                if (ClosingBracketCount == 0 && i == input.Length - 1)
                {
                    PossibleSolutionsCount++;
                    Console.WriteLine(input);
                }

                if (input[i] == (char)Brackets.FreeSlot)
                {
                    bracketToUse++;
                }

                //if (bracketToUse == 1)
                //{
                //    input[i] = (char)Brackets.OpeningBracket;
                //    bracketToUse++;
                //    i--;
                //}
                //else if (bracketToUse == 2)
                //{
                //    ClosingBracketCount++;
                //    input[i] = (char)Brackets.ClosingBracket;
                //    bracketToUse++;
                //    i--;
                //}
                //else if (bracketToUse == 3)
                //{
                //    input[i] = (char)Brackets.FreeSlot;
                //    bracketToUse = 0;
                //}
            }
        }
    }
}
