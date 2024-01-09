using Data;
using Data.Entities;
using PCParts.Mappers;
using PCParts.Models;

namespace PCParts.Services
{
    public class ComputerService : IComputerService
    {
        private AppDbContext _context;

        public ComputerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Computer computer)
        {
            var e = _context.Computers.Add(ComputerMapper.ToEntity(computer));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            ComputerEntity? find = _context.Computers.Find(id);
            if (find != null)
            {
                _context.Computers.Remove(find);
            }
        }

        public List<Computer> FindAll()
        {
            return _context.Computers.Select(x => ComputerMapper.FromEntity(x)).ToList(); 
        }

        public Computer? FindById(int id)
        {
            return ComputerMapper.FromEntity(_context.Computers.Find(id));
        }

        public void Update(Computer computer)
        {
            var pc = _context.Computers.FirstOrDefault(x => x.Id == computer.Id);
            pc.Cpu = computer.Cpu;
            pc.Gpu = computer.Gpu;
            pc.Manufacturer = computer.Manufacturer;
            pc.ProductionDate = computer.ProductionDate;
            _context.Computers.Update(pc);
            _context.SaveChanges();
        }
        public Computer? Update(int id)
        {
            var pc = _context.Computers.Find(id);
            if (pc != null) { return ComputerMapper.FromEntity(pc); } else { return null; }
        }
        public Computer? Details(int id)
        {
            var pc = _context.Computers.SingleOrDefault(x => x.Id == id);
            if (pc != null) { return ComputerMapper.FromEntity(pc); } else { return null; }
        }
        public List<OrganizationEntity> FindAllOrganizationsForViewModel()
        {
            return _context.Organizations.ToList();
        }
    }
}
