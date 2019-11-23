using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;

namespace JesparWebApplication.Models
{
    public class PurchaseViewModel
    {
        public int Id { set; get; }
        public string Date { set; get; }
        public string InvoiceNo { set; get; }
        public string ProductCode { set; get; }
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
        public List<SelectListItem> SupplierSelectListItems { set; get; }

        //Associate category
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }
        //Associate Product
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public List<SelectListItem> ProductSelectListItems { set; get; }
        
        public List<Product> Products { set; get; }
        //list 

       

    }
   
}