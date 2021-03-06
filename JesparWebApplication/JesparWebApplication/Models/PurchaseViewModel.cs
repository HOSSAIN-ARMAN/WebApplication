﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;


namespace JesparWebApplication.Models
{
    public class PurchaseViewModel
    {
        
        public int Id { set; get; }

       
        public DateTime Date { set; get; }
        public string InvoiceNo { set; get; }

        public string SupplierName { set; get; }
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; }

        //for create table 
        public List<Purchase> Purchases { set; get; }

        



        //-------------------------------


        public string Code { set; get; }

        [DataType(DataType.Date)]
        public DateTime ManuFractureDateTime { set; get; }

        [DataType(DataType.Date)]
        public DateTime ExpireDateTime { set; get; }
        public string Remarks { set; get; }
        public int Quantity { set; get; }
        public int UnitPrice { set; get; }
        public int TotalPrice { set; get; }
        public int MRP { set; get; }

        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int PurchaseId { set; get; }
        public Purchase Purchase { set; get; }

        public List<PurchaseDetails> PurchaseDetailses { set; get; }
        //----------------------------------------
        public List<SelectListItem> SupplierSelectListItems { set; get; }
        public List<SelectListItem> ProductSelectListItems { set; get; }

        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }



    }

}