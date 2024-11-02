using CompStore.Entities;

namespace CompStore.Services
{
    public interface IComputerService
    {
      public IEnumerable<Computer> GetActiveComputers();

        public IEnumerable<Computer> GetDeactiveComputer();

        public IEnumerable<Computer> GetAllComputers();

        public void Create(Computer computer);

        public void Update(Computer computer);

        public void Delete(Computer computer); 

        public  Computer GetById(int Id);

    }
}
