using Models.AllPackages;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        // Veza prema Client
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Veza prema TravelPackage
        [Required]
        public int TravelPackageId { get; set; }
        public TravelPackage TravelPackage { get; set; }

        // Datum kada je rezervacija napravljena
        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        // Broj putnika za ovu rezervaciju
        [Required]
        public int NumberOfPeople { get; set; } = 1;

        // Status rezervacije (npr. Active, Cancelled)
        [Required, MaxLength(20)]
        public string Status { get; set; } = "Active";
    }
}
