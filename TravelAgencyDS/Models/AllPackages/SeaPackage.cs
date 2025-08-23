using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AllPackages
{
    public class SeaPackage : TravelPackage
    {
        public string Destination { get; set; }          // Npr. "Grčka – Halkidiki"
        public string TransportType { get; set; }       // Npr. "Avion", "Autobus"
        public string AccommodationType { get; set; }   // Npr. "Hotel 4*", "Apartman"
    }
}
