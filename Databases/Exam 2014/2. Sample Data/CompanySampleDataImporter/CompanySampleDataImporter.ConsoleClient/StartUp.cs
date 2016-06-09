namespace CompanySampleDataImporter.ConsoleClient
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
