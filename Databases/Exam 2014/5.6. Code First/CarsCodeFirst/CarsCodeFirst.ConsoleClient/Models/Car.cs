namespace CarsCodeFirst.ConsoleClient.Models
{
    using CarsCodeFirst.Models;

    public class Car
    {
        public ushort Year { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public Dealer Dealer { get; set; }
    }
}
