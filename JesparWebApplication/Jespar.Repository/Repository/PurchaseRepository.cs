using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.DatabaseContext.DatabaseContext;

namespace Jespar.Repository.Repository
{
    public class PurchaseRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            return _dbContext.SaveChanges() > 0;
        }
        public List<PurchaseDetails> GetAll()
        {
            return _dbContext.PurchaseDetailses.ToList();
        }

    }
}
