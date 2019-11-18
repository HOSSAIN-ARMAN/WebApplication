using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.Repository.Repository;


namespace Jespar.BLL.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
