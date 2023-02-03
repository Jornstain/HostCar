using Host_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_Car.DataAccess.Repository.IRepository
{
    public interface IPreOrderSearchRepository : IRepository<PreOrderSearch>
    {
        void Update(PreOrderSearch preOrderSearch);
        void Save();
    }
}
