using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Service.Sevices.SupplierService
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Insert(Supplier Supplier);
        void Update(Supplier Supplier);
        void Delete(int id);
    }
}
