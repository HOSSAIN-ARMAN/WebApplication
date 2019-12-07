using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jespar.Model.Model;

namespace JesparWebApplication.Models
{
    public class CustomerViewModel
    {
        public int Id { set; get; }
        public string CustomerCode { set; get; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerEmail { set; get; }
        public string Contact { set; get; }
        public int LoyaltyPoint { set; get; }
        public List<Customer> Customers { get; internal set; }
    }
}