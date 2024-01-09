using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ComputerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ProductionDate { get; set; }
        public int? OrganizationId { get; set; }
        public OrganizationEntity? Organization { get; set; }

        public ICollection<ComputerShippingCountry> ComputerShippingCountries { get; set; }
    }
}
