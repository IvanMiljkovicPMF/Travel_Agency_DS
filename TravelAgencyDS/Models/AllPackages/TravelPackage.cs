using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.AllPackages
{
    public abstract class TravelPackage
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerPerson { get; set; }

        [Required]
        public int DurationDays { get; set; }

        // Navigacija prema rezervacijama
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
