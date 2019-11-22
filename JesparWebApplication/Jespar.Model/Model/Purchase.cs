using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jespar.Model.Model
{
    public class Purchase
    {
        public int Id { set; get; }
        public string Date { set; get; }
        public string InvoiceNo { set; get; }
        public string ManufractureDate { set; get; }
        public string ExoireDate { set; get; }
        public string Remarks { set; get; }
        public int Quantity { set; get; }
        public int UnitePrice { set; get; }
        public int TotalPrice { set; get; }
        public int Mrp { set; get; }

        //Associtate Supplier
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; }
       //Associate Category
        //public int CategoryId { set; get; }
        //public Category Category { set; get; }

        //Associate Product
        public int ProductId { set; get; }
        public Product Product { set; get; }
    }
}
