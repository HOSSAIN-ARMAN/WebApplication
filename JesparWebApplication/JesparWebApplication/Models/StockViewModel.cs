using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Product { get; set; }
        public string CategoryName { get; set; }
        public int ReorderLevel { get; set; }
        public DateTime Expdate { get; set; }
        public int OpeningBalance { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int ClosingBalance { get; set; }

        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }
    }
}