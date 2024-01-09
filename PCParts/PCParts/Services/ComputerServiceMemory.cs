using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PCParts.Models;

namespace PCParts.Services
{
    public class ComputerServiceMemory : IComputerServicMemory
    {
        static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();

        public List<Computer> All()
        {
            return _computers.Values.ToList();
        }

        public void Create(Computer Computer)
        {
            int id = _computers.Keys.Count == 0 ? 0 : _computers.Keys.Max();
            id += 1;
            Computer.Id = id;
            _computers.Add(id, Computer);
        }

        public void Delete(int id)
        {
            _computers.Remove(id);
        }
        public Computer? Edit(int id)
        {
            return _computers[id];
        }

        public Computer? Details(int id)
        {
            return _computers[id];
        }

        public void Edit(Computer Computer)
        {
            _computers[Computer.Id] = Computer;
        }
    }
}
