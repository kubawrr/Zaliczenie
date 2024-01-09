using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ComputerShippingCountry
    {
        public int Id { get; set; }
        public int ComputerId { get; set; }
        public ComputerEntity Computer { get; set; }

        public int ShippingId { get; set; }
        public ShippingCountries ShippingCountries { get; set; }
    }
}
