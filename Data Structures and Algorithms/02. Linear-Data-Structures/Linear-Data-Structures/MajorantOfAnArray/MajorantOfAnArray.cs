namespace MajorantOfAnArray
{
    using System;
    using System.Collections.Generic;

    public class MajorantOfAnArray
    {
        static void Main()
        {
            var numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var majorantLength = numbers.Length / 2 + 1;

            int? majorantNumber = null;
            var numbersChecked = new List<int>();
            for (int i = 0, len = numbers.Length - majorantLength + 1; i < len; i++)
            {
                var currentNumber = numbers[i];

                if (!numbersChecked.Contains(currentNumber))
                {
                    var timesCurrentNumberIsMet = 1;
                    numbersChecked.Add(currentNumber);
                    for (int j = i + 1, length = numbers.Length; j < length; j++)
                    {
                        if (numbers[j] == currentNumber)
                        {
                            timesCurrentNumberIsMet++;
                        }

                        if (timesCurrentNumberIsMet >= majorantLength)
                        {
                            majorantNumber = currentNumber;
                        }
                    }
                }
            }

            Console.WriteLine("Majorant number: {0}", majorantNumber);
        }
    }
}
