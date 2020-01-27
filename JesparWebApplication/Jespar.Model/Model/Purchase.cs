using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jespar.Model.Model
{
    public class Purchase
    {
              
        public Purchase()
        {
            PurchaseDetailses = new List<PurchaseDetails>();
            
        }

        public int Id { set; get; }

        public int Code { set; get; }

        public DateTime Date { set; get; }
        public string InvoiceNo { set; get; }

        public string SupplierName { set; get; }
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; }

        public List<PurchaseDetails> PurchaseDetailses { set; get; }
    }
}
