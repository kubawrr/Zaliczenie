using PCParts.Models;

namespace PCParts.Services
{
    public interface IComputerServicMemory
    {
        void Create(Computer Computer);
        void Delete(int id);
        void Edit(Computer id);
        Computer? Edit(int id);
        Computer? Details(int id);
        List<Computer> All();
    }
}
