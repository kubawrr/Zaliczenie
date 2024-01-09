using Data.Entities;
using PCParts.Models;

namespace PCParts.Services
{
    public interface IComputerService
    {
        int Add(Computer computer);
        void Delete(int id);
        List<Computer> FindAll();
        Computer? FindById(int id);
        void Update(Computer computer);

        Computer? Details(int id);
        Computer Update(int id);
        List<OrganizationEntity> FindAllOrganizationsForViewModel();
    }
}
