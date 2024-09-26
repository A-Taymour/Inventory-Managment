using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Sevices
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Insert(User User);
        void Update(User User);
        void Delete(int id);
    }
}
