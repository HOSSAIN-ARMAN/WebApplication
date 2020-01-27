using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MaxLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        [MinLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        public int ReorderLavel { set; get; }
        public string Description { set; get; }
        [Required(ErrorMessage = "Select Category")]
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }

        public List<Product> Products { set; get; }
    }
}