using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PCParts.Models
{
    public class Computer
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        [HiddenInput]
        public int OrganizationId { get; set; }
        [ValidateNever]
        public List<SelectListItem> Organizations { get; set; }
    }
}
