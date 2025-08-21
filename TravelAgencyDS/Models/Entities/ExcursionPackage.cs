using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class ExcursionPackage : TravelPackage
    {
        public string Destination { get; set; }
        public string TransportType { get; set; }
        public string Guide { get; set; }
        public int DurationDays { get; set; }
    }
}
