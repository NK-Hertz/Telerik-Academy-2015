using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareSimpleMath
{
    class CompareSimpleMath
    {
        static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Warning! Multiplies all values 28 times! After that stack overflow exception is thrown for decimal!");
            Console.WriteLine();

            Console.WriteLine("INT: ");
            Console.Write("Addition ");
            DisplayExecutionTime(() =>
            {
                int result = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    result += i;
                }
            });

            Console.Write("Subtraction ");
            DisplayExecutionTime(() =>
            {
                int result = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= i;
                }
            });

            Console.Write("Increment ");
            DisplayExecutionTime(() =>
            {
                int sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum++;
                }
            });

            Console.Write("Multiplication ");
            DisplayExecutionTime(() =>
            {
                int result = 1;
                // after 34 multiplication returns 0 as a result cuz overflow and shit
                for (int i = 1; i < 28; i++)
                {
                    result *= i;
                }
            });

            Console.Write("Devision ");
            DisplayExecutionTime(() =>
            {
                int result = int.MaxValue;
                for (int i = 1; i < 1000000; i++)
                {
                    result /= i;
                }
            });

            Console.WriteLine();
            Console.WriteLine("LONG: ");
            Console.Write("Addition ");
            DisplayExecutionTime(() =>
            {
                long result = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    result += i;
                }
            });

            Console.Write("Subtraction ");
            DisplayExecutionTime(() =>
            {
                long result = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    result -= i;
                }
            });

            Console.Write("Increment ");
            DisplayExecutionTime(() =>
            {
                long sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    sum++;
                }
            });

            Console.Write("Multiplication ");
            DisplayExecutionTime(() =>
            {
                long result = 1;
                for (int i = 1; i < 28; i++)
                {
                    result *= i;
                }
            });

            Console.Write("Devision ");
            DisplayExecutionTime(() =>
            {
                long result = long.MaxValue;
                for (int i = 1; i < 1000000; i++)
                {
                    result /= i;
                }
            });

            Console.WriteLine();
            Console.WriteLine("FLOAT: ");
            Console.Write("Addition ");
            DisplayExecutionTime(() =>
            {
                float result = 0;
                for (float i = 0; i < 1000000; i++)
                {
                    result += i;
                }
            });

            Console.Write("Subtraction ");
            DisplayExecutionTime(() =>
            {
                float result = 0;
                for (float i = 0; i < 1000000; i++)
                {
                    result -= i;
                }
            });

            Console.Write("Increment ");
            DisplayExecutionTime(() =>
            {
                float sum = 0;
                for (float i = 0; i < 1000000; i++)
                {
                    sum++;
                }
            });

            Console.Write("Multiplication ");
            DisplayExecutionTime(() =>
            {
                float result = 1;
                for (float i = 1; i < 28; i++)
                {
                    result *= i;
                }
            });

            Console.Write("Devision ");
            DisplayExecutionTime(() =>
            {
                float result = float.MaxValue;
                for (float i = 1; i < 1000000; i++)
                {
                    result /= i;
                }
            });

            Console.WriteLine();
            Console.WriteLine("DOUBLE: ");
            Console.Write("Addition ");
            DisplayExecutionTime(() =>
            {
                double result = 0;
                for (double i = 0; i < 1000000; i++)
                {
                    result += i;
                }
            });

            Console.Write("Subtraction ");
            DisplayExecutionTime(() =>
            {
                double result = 0;
                for (double i = 0; i < 1000000; i++)
                {
                    result -= i;
                }
            });

            Console.Write("Increment ");
            DisplayExecutionTime(() =>
            {
                double sum = 0;
                for (double i = 0; i < 1000000; i++)
                {
                    sum++;
                }
            });

            Console.Write("Multiplication ");
            DisplayExecutionTime(() =>
            {
                double result = 1;
                for (double i = 1; i < 28; i++)
                {
                    result *= i;
                }
            });

            Console.Write("Devision ");
            DisplayExecutionTime(() =>
            {
                double result = double.MaxValue;
                for (double i = 1; i < 1000000; i++)
                {
                    result /= i;
                }
            });

            Console.WriteLine();
            Console.WriteLine("DECIMAL: ");
            Console.Write("Addition ");
            DisplayExecutionTime(() =>
            {
                decimal result = 0;
                for (decimal i = 0; i < 1000000; i++)
                {
                    result += i;
                }
            });

            Console.Write("Subtraction ");
            DisplayExecutionTime(() =>
            {
                decimal result = 0;
                for (decimal i = 0; i < 1000000; i++)
                {
                    result -= i;
                }
            });

            Console.Write("Increment ");
            DisplayExecutionTime(() =>
            {
                decimal sum = 0;
                for (decimal i = 0; i < 1000000; i++)
                {
                    sum++;
                }
            });

            
            Console.Write("Multiplication ");
            DisplayExecutionTime(() =>
            {
                decimal result = 1;

                for (decimal i = 1; i < 28; i++)
                {
                    result *= i;
                }
            });

            Console.Write("Devision ");
            DisplayExecutionTime(() =>
            {
                decimal result = decimal.MaxValue;
                for (decimal i = 1; i < 1000000; i++)
                {
                    result /= i;
                }
            });
        }
    }
}
