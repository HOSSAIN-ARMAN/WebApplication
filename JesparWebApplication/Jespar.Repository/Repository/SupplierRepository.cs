using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.DatabaseContext.DatabaseContext;

namespace Jespar.Repository.Repository
{
    public class SupplierRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool Save(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            return _dbContext.SaveChanges() > 0;
        }
        public List<Supplier> GetAll()
        {
            return _dbContext.Suppliers.ToList();
        }
    }
}
