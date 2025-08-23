using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AllPackages
{
    public class ExcursionPackage : TravelPackage
    {
        public string Destination { get; set; }      // Npr. "Beč i Bratislava"
        public string TransportType { get; set; }   // Npr. "Autobus", "Avion"
        public string Guide { get; set; }           // Npr. "Lokalni vodič"
        public int DurationDays { get; set; }       // Npr. 3 dana
    }
}
