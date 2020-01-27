using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class CustomerViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MaxLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        [MinLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        public string CustomerCode { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]       
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmail { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MinLength(11, ErrorMessage = "Contact must be in 11 numbers")]
        [MaxLength(11, ErrorMessage = "Contact must be in 11 numbers")]
        public string Contact { set; get; }
        public int LoyaltyPoint { set; get; }
        public List<Customer> Customers { get; internal set; }
    }
}