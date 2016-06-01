namespace CountOfNumbersInCollection
{
    using System;
    using System.Collections.Generic;

    public class CountOfNumbersInCollection
    {
        static void Main()
        {
            var numbers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var numbersChecked = new List<int>();
            for (int i = 0, len = numbers.Length; i < len; i++)
            {
                var currentNumber = numbers[i];
                if (!numbersChecked.Contains(currentNumber))
                {
                    numbersChecked.Add(currentNumber);

                    var timesCurrentNumberMet = 1;
                    for (int j = i + 1; j < len; j++)
                    {
                        if (numbers[j] == currentNumber)
                        {
                            timesCurrentNumberMet++;
                        }
                    }

                    Console.WriteLine("{0} -> {1} times", currentNumber, timesCurrentNumberMet);
                }
            }
        }
    }
}
