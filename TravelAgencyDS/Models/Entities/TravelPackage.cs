using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public abstract class TravelPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PackageType { get; set; }
        public string Details { get; set; }

    
        public ICollection<Client> Clients { get; set; }
    }
}
