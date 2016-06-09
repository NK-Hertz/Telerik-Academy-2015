namespace CarsCodeFirst.ConsoleClient.Models
{
    using CarsCodeFirst.Models;
    using Newtonsoft.Json;

    public class CarJson
    {
        public ushort Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        [JsonProperty("ManufacturerName")]
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJson Dealer { get; set; }
    }
}
