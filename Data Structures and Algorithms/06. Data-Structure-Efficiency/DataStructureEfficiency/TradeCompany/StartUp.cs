namespace TradeCompany
{
    using System;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        static void Main()
        {
            Console.WriteLine("Creating articles...");
            var tradeCompanyArticles = new OrderedMultiDictionary<decimal, Article>(false);
            Random rand = new Random();
            var numberOfArticles = 1500000;
            for (int i = 0; i < numberOfArticles; i++)
            {
                var randomNumber = rand.Next(0, 500000);
                decimal price = (randomNumber * 0.75m + 0.34m) / 0.23m;
                tradeCompanyArticles.Add(price,
                    new Article(i, "ASAP Labs", string.Format("Introduction to {0}", i), price));
            }
            Console.WriteLine("Done!");

            var cheapArticles = tradeCompanyArticles.Range(1, true, 20, true);
            foreach (var pair in cheapArticles)
            {
                Console.WriteLine(pair.Value);
            }
        }
    }
}
