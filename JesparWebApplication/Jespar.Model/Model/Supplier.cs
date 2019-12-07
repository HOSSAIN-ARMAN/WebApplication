using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jespar.Model.Model
{
    public class Supplier
    {
        public Supplier()
        {
            Purchases = new List<Purchase>();
        }
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string Contact { set; get; }
        public string PersonContact { set; get; }

        public List<Purchase> Purchases { set; get; }
    }
}
