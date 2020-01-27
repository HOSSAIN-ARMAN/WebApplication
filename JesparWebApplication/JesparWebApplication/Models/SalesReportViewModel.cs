using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class SalesReportViewModel
    {
        //public string Code { get; set; }
        //public string Name { get; set; }
        //public string Category { get; set; }
        //public int SoldQuantity { get; set; }
        //public double unitPrice { get; set; }
        //public double SalesPrice { get; set; }
        //public double TotalProfit { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime startDate { set; get; }
        //[DataType(DataType.Date)]
        //public DateTime endDate { set; get; }
        //public List<SalesReportViewModel> salesReportList { set; get; }


        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int SoldQuantity { get; set; }
        public double CostPrice { get; set; }
        public double SalesPrice { get; set; }
        public double Profit { get; set; }
        public double TotalProfit { get; set; }
    }
}