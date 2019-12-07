using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jespar.Model.Model
{
    public class Sales
    {
        public Sales()
        {
            SalesDetails = new List<SalesDetails>();
        }
        public int Id { set; get; }
        public int Code { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public Customer Customer { set; get; }
        public string Date { set; get; }
        public int LoyaltyPoint { set; get; }
       
        public List<SalesDetails> SalesDetails { set; get; }
    }
}
