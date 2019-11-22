using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.DatabaseContext.DatabaseContext;
using Jespar.Model.Model;

namespace Jespar.Repository.Repository
{
    public class ProductRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool Add(Product product)
        {
            _dbContext.Products.Add(product);
            return _dbContext.SaveChanges() > 0;
        }
        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }
    }
}
