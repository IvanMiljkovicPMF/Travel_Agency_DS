using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AllPackages
{
    public class MountainPackage : TravelPackage
    {
        public string Destination { get; set; }            // Npr. "Kopaonik"
        public string TransportType { get; set; }         // Npr. "Autobus", "Sopstveni prevoz"
        public string AccommodationType { get; set; }     // Npr. "Hotel 3*", "Planinarski dom"
        public string AdditionalActivities { get; set; }  // Npr. "Ski pass, Spa, Hiking tours"
    }
}
