using Host_Car.DataAccess.Repository.IRepository;
using Host_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_Car.DataAccess.Repository
{
    public class PreOrderSearchRepository : Repository<PreOrderSearch>, IPreOrderSearchRepository
    {
        private ApplicationDbContext _db;
        public PreOrderSearchRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(PreOrderSearch preOrderSearch)
        {
            _db.PreOrderSearchs.Update(preOrderSearch);
        }
    }
}
