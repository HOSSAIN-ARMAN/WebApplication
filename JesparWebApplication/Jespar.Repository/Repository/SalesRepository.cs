using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.DatabaseContext.DatabaseContext;

namespace Jespar.Repository.Repository
{
    public class SalesRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool AddSales( Sales sales)
        {
            _dbContext.Sales.Add(sales);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
