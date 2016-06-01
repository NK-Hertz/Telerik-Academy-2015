namespace PrintFirst50Members
{
    using System;
    using System.Collections.Generic;

    public class PrintFirst50Members
    {
        static void Main()
        {
            var sequence = new Queue<int>();
            Console.WriteLine("Enter N: ");
            int number = int.Parse(Console.ReadLine());

            var s1 = number;
            sequence.Enqueue(s1);
            Console.WriteLine(s1);
            sequence.Dequeue();
            for (int i = 0, len = 50; i < len; i++)
            {
                var s2 = s1 + 1;
                sequence.Enqueue(s2);
                Console.WriteLine(s2);

                var s3 = 2 * s1 + 1;
                sequence.Enqueue(s3);
                Console.WriteLine(s3);

                var s4 = s1 + 2;
                sequence.Enqueue(s4);
                Console.WriteLine(s4);

                s1 = sequence.Dequeue();
            }
        }
    }
}
