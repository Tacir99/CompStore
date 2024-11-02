using CompStore.Context;
using CompStore.Entities;
using CompStore.Services;
using Microsoft.EntityFrameworkCore;

namespace CompStore.Manager
{
    public class ComputerManager : IComputerService
    {
        private readonly AppDbContext  _db;
        public ComputerManager(AppDbContext db)
        {
            _db = db;
        }

        public void Create(Computer computer)
        {
            _db.Computers.Add(computer);
            _db.SaveChanges();
           
        }

        public void Delete(Computer computer)
        {
            _db.Computers.Remove(computer);
            _db.SaveChanges();
        }
        public IEnumerable<Computer> GetActiveComputers()
        {
            return _db.Computers.Include(x=>x.Detail).Where(x => x.InStock !=0).ToList();
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return _db.Computers.Include(x=>x.Detail).ToList();
        }

        public Computer GetById(int Id)
        {
            return _db.Computers.FirstOrDefault(x => x.Id==Id);
        }

        public IEnumerable<Computer> GetDeactiveComputer()
        {
            return _db.Computers.Include(x => x.Detail).Where(x=>x.InStock==0).ToList();
        }

        public void Update(Computer computer)
        {
            _db.Computers.Update(computer);
            _db.SaveChanges();
        }
     
    }
}
