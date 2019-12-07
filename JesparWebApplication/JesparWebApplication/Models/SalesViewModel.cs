using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JesparWebApplication.Models
{
    public class SalesViewModel
    {
       
        public int Id { set; get; }
        public int Code { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public Customer Customer { set; get; }
        public List<SelectListItem> CustomerSelectListItems { set; get; }


        public string Date { set; get; }
        public int LoyaltyPoint { set; get; }

        public List<SalesDetails> SalesDetails { set; get; }


       
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public int MRP { set; get; }
        public int TotalMrp { set; get; }



        public int GrandTotal { set; get; }
        public int Discount { set; get; }
        public int DiscountAmmount { set; get; }
        public int PayableAmmount { set; get; }

        public int SalesId { set; get; }
        public Sales Sales { set; get; }






        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }

    }
}