using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMath
{
    class CompareAdvancedMath
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
            Console.WriteLine("FLOAT: ");
            Console.Write("Sqrt ");
            DisplayExecutionTime(() =>
            {
                float result = (float)Math.Sqrt(2);
            });

            Console.Write("Natural Log ");
            DisplayExecutionTime(() =>
            {
                float result = (float)Math.Log(2);
            });

            Console.Write("Sine ");
            DisplayExecutionTime(() =>
            {
                float result = (float)Math.Sin(2);
            });

            Console.WriteLine("DOUBLE: ");
            Console.Write("Sqrt ");
            DisplayExecutionTime(() =>
            {
                double result = (double)Math.Sqrt(2);
            });

            Console.Write("Natural Log ");
            DisplayExecutionTime(() =>
            {
                double result = (double)Math.Log(2);
            });

            Console.Write("Sine ");
            DisplayExecutionTime(() =>
            {
                double result = (double)Math.Sin(2);
            });

            Console.WriteLine("DECIMAL: ");
            Console.Write("Sqrt ");
            DisplayExecutionTime(() =>
            {
                decimal result = (decimal)Math.Sqrt(2);
            });

            Console.Write("Natural Log ");
            DisplayExecutionTime(() =>
            {
                decimal result = (decimal)Math.Log(2);
            });

            Console.Write("Sine ");
            DisplayExecutionTime(() =>
            {
                decimal result = (decimal)Math.Sin(2);
            });
        }
    }
}
