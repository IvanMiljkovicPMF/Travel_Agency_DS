using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class CruisePackage : TravelPackage
    {
        public string Ship { get; set; }
        public string Route { get; set; }
        public DateTime DepartureDate { get; set; }
        public string CabinType { get; set; }
    }
}
