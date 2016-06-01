namespace CarsCodeFirst.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(11)]
        public string Model { get; set; }
        
        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
