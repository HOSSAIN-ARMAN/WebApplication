using Jespar.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class SupplierViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MaxLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        [MinLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        [Display(Name = "Code: ")]

        public string Code { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [Display(Name = "Name: ")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [Display(Name = "Address: ")]
        public string Address { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [Display(Name = "Email: ")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MinLength(11, ErrorMessage = "Contact must be in 11 numbers")]
        [MaxLength(11, ErrorMessage = "Contact must be in 11 numbers")]
        [Display(Name = "Contact: ")]
        public string Contact { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MinLength(1, ErrorMessage = "Loyalti Point Can not Be Nagative")]
        [Display(Name = "Loyalty Point: ")]
        public string LoyaltyPoint { set; get; }
        public List<Supplier> Suppliers { set; get; }
    }
}