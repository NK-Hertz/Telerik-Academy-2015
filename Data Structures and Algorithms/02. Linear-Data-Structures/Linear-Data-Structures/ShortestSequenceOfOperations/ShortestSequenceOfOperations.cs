namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequenceOfOperations
    {
        static void Main()
        {
            var sequence = new Queue<int>();
            Console.WriteLine("Enter N: ");
            var start = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M: ");
            var end = int.Parse(Console.ReadLine());

            var numbers = new Queue<int>();

            while (start <= end)
            {
                numbers.Enqueue(end);

                if (end / 2 >= start)
                {
                    if (end % 2 == 0)
                    {
                        end /= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    if (end - 2 >= start)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            Console.WriteLine(string.Join(" -> ", numbers.Reverse()));
        }
    }
}
