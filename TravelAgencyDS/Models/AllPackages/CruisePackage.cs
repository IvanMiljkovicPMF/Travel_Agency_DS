using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AllPackages
{
    public class CruisePackage : TravelPackage
    {
        public string Ship { get; set; }          // Npr. "MSC Fantasia"
        public string Route { get; set; }         // Npr. "Mediteran - Italija, Grčka, Turska"
        public DateTime DepartureDate { get; set; }
        public string CabinType { get; set; }     // Npr. "Balcony Suite", "Inside Cabin"
    }
}
