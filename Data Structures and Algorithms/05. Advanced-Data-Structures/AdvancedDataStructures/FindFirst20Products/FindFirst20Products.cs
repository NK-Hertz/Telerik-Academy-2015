namespace FindFirst20Products
{
    using System;
    using Wintellect.PowerCollections;

    public class FindFirst20Products
    {
        static void Main()
        {
            var bag = new OrderedBag<decimal>();
            Random rand = new Random();
            Console.WriteLine("Creating elements");
            for (int i = 0, len = 500000; i < len; i++)
            {
                var randomNumber = rand.Next(0, 500000);
                decimal price = (randomNumber * 0.75m + 0.34m) / 0.23m;
                bag.Add(price);
            }

            Console.WriteLine("Bag.Range - 10000 Searches");

            for (int i = 0, numberOfItems = 10000; i < numberOfItems; i++)
            {
                decimal minPrice = i;
                decimal maxPrice = ((i * 0.75m + 0.34m) / 0.23m) + (2 * 2 * 0.75m + 0.34m) / 0.23m;
                //var now = DateTime.Now;
                var resultBag = bag.Range(minPrice, true, maxPrice, true);
                //var finished = DateTime.Now - now;
                //Console.WriteLine(finished);
                //Console.WriteLine("{0} {1}", minPrice, maxPrice);
                //Console.WriteLine(resultBag.Count);
            }

            Console.WriteLine("Done!");

            //Console.WriteLine();
            //Console.WriteLine("LINQ - 20");
            //Console.WriteLine();
            //for (int i = 0, numberOfItems = 20; i < numberOfItems; i++)
            //{
            //    decimal minPrice = i;
            //    decimal maxPrice = ((i * 0.75m + 0.34m) / 0.23m) + (2 * 2 * 0.75m + 0.34m) / 0.23m;
            //    var now = DateTime.Now;
            //    var result = bag.Where(p => p >= minPrice && p <= maxPrice).Select(p => p).ToList();
            //    var finished = DateTime.Now - now;
            //    Console.WriteLine(finished);
            //    //Console.WriteLine("{0} {1}", minPrice, maxPrice);
            //    //Console.WriteLine(result.Count);
            //}

            //Console.WriteLine("Done!");
        }
    }
}
