using Data.Entities;
using PCParts.Models;

namespace PCParts.Mappers
{
    public class ComputerMapper
    {
        public static Computer FromEntity(ComputerEntity entity)
        {
            return new Computer()
            {
                Id = entity.Id,
                Name = entity.Name,
                Cpu = entity.Cpu,
                Gpu = entity.Gpu,
                Manufacturer = entity.Manufacturer,
            };
        }

        public static ComputerEntity ToEntity(Computer model)
        {
            return new ComputerEntity()
            {
                Name = model.Name,
                Cpu = model.Cpu,
                Gpu = model.Gpu,
                Manufacturer = model.Manufacturer,
                OrganizationId = model.OrganizationId,
                ProductionDate = model.ProductionDate
            };
        }
    }
}
