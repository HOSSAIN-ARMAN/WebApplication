using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.DatabaseContext.DatabaseContext;

namespace Jespar.Repository.Repository
{
    public class CategoryRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool Add(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges() > 0;
        }
        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
