﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JesparWebApplication.Models;
using Jespar.BLL.BLL;
using Jespar.Model.Model;

namespace JesparWebApplication.Controllers
{
    public class PurchaseReportController : Controller
    {
        // GET: PurchaseReport
        SalesManager _saleManager = new SalesManager();
        SalesViewModel _saleViewModel = new SalesViewModel();

        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        PurchaseViewModel _purchaseViewModel = new PurchaseViewModel();
        StockController stockController = new StockController();
        // GET: SalesReport
        public ActionResult GetPurchaseReport()
        {

            return View();
        }

        public ActionResult GetPurchaseReportByDate(DateTime startDate, DateTime endDate)
        {
            var Product = _productManager.GetAll().ToList();
            var Category = _categoryManager.GetAll().ToList();
            var SaleProducts = _saleManager.GetAllSalesDetails().ToList();
            var Sale = _saleManager.GetAll().ToList();
            var PurchaseProducts = _purchaseManager.GetAll().ToList();
            var Purchase = _purchaseManager.GetPurchaseReportAll().ToList();

            var q = (from PurPro in PurchaseProducts
                     join pur in Purchase on PurPro.Purchase.Id equals pur.Id
                     join Prod in Product on PurPro.ProductId equals Prod.Id
                     join Cat in Category on Prod.CategoryId equals Cat.Id
                     orderby pur.Date.Date
                     where
                      (pur.Date.Date >= startDate.Date && endDate.Date >= pur.Date.Date)
                     select new PurchaseReport { Id = pur.Id, Code = Prod.Code, Name = Prod.Name, Category = Cat.Name, AvailableQuantity = GetAvailable(Prod.Id, pur.Date), CostPrice = PurPro.UnitPrice, MRP = PurPro.MRP, Profit = PurPro.MRP - PurPro.UnitPrice }).ToList();
            ViewBag.x = q;
            return PartialView("Report/_GetPurchaseReport");

        }

        public class PurchaseReport
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int AvailableQuantity { get; set; }
            public double CostPrice { get; set; }
            public double MRP { get; set; }
            public double Profit { get; set; }
            // public double TotalProfit { get; set; }


        }

        public int GetAvailable(int ProdId, DateTime date)
        {

            var SproductList = _saleManager.GetAllSalesDetails().Where(c => c.ProductId == ProdId).ToList();
            var sumS = (from p in SproductList where p.Sales.Date.Date <= date.Date select p.Quantity).Sum();
            var PproductList = _purchaseManager.GetAll().Where(c => c.ProductId == ProdId).ToList();
            var sumP = (from p in PproductList where p.Purchase.Date.Date <= date.Date select p.Quantity).Sum();
            // var sumP=0;
            // var sumS=0;
            //foreach (var s in SproductList)
            //{
            //    sumS += Convert.ToInt32(s.Quantity);
            //}
            //foreach (var p in PproductList)
            //{
            //    sumP += Convert.ToInt32(p.Quantity);
            //}
            var r = Math.Abs(sumS - sumP);

            return r;
        }
    }
}