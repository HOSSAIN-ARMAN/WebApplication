using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jespar.Model.Model
{
    public class Product
    {
        //{
        //    Purchases = new List<Purchase>();
        //}
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int ReorderLavel { set; get; }
        public string Description { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }

        //public List<Purchase> Purchases { set; get; }
    }
}
