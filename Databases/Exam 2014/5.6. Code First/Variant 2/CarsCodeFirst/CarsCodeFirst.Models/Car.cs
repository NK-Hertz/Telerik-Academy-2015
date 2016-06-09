namespace CarsCodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        // 11
        [MaxLength(20)]
        public string Model { get; set; }
        
        public TransmissionType Transmission { get; set; }

        public ushort Year { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
