using CompStore.Context;
using CompStore.Entities;
using CompStore.Services;

namespace CompStore.Manager
{
    public class DetailManager:IDetailService
    {
        private readonly AppDbContext _db;
        public DetailManager(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Detail> SizeList()
        {
            return _db.Details.ToList();
        }
    }
}
