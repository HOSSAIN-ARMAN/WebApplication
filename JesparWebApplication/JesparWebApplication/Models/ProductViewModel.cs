using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;

namespace JesparWebApplication.Models
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int ReorderLavel { set; get; }
        public string Description { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }
    }
}