using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JesparWebApplication.Models;
using Jespar.BLL.BLL;
using Jespar.Model.Model;

namespace JesparWebApplication.Controllers
{
    public class SalesReportController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        SalesManager _salesManager = new SalesManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        public ActionResult GetSalesReport()
        {
            return View();
        }
        //public ActionResult GetSalesReport(DateTime startDate, DateTime endDate)
        //{
        //    SalesReportViewModel salesReportViewModel = new SalesReportViewModel();

        //    var product = _productManager.GetAll().ToList();
        //    var category = _categoryManager.GetAll().ToList();
        //    var salesProduct = _salesManager.GetAllSalesDetails().ToList();
        //    var sale = _salesManager.GetAll().ToList();
        //    var purchaseProducts = _purchaseManager.GetAll();
        //    var purchase = _purchaseManager.GetPurchaseReportAll();

        //    var salesReport = (from saleDetails in salesProduct
        //                       join sales in sale on saleDetails.Sales.Id equals sales.Id
        //                       join purchaseData in purchase on sales.Date.Date equals purchaseData.Date.Date
        //                       join pDetails in purchaseProducts on new
        //                       {
        //                           purchaseData.Id,
        //                           saleDetails.ProductId
        //                       } equals new
        //                       {
        //                           pDetails.Purchase.Id,
        //                           pDetails.ProductId
        //                       }
        //                       join products in product on saleDetails.ProductId equals products.Id
        //                       join categories in category on products.CategoryId equals categories.Id
        //                       orderby sales.Date.Date
        //                       where (sales.Date.Date >= startDate.Date && endDate.Date >= sales.Date.Date)

        //                       select new SalesReportViewModel()
        //                       {
        //                           Code = products.Code,
        //                           Name = products.Name,
        //                           Category = categories.Name,
        //                           SoldQuantity = saleDetails.Quantity,
        //                           unitPrice = pDetails.UnitPrice,
        //                           SalesPrice = saleDetails.MRP,
        //                           TotalProfit = saleDetails.Quantity * (saleDetails.MRP - pDetails.UnitPrice)

        //                       }).ToList();


        //    return View(salesReportViewModel);
        //}

        public ActionResult GetSalesReportByDate(DateTime startDate, DateTime endDate)
        {
            var Product = _productManager.GetAll().ToList();
            var Category = _categoryManager.GetAll().ToList();
            var SaleProducts = _salesManager.GetAllSalesDetails().ToList();
            var Sale = _salesManager.GetAll().ToList();
            var PurchaseProducts = _purchaseManager.GetAll().ToList();
            var Purchase = _purchaseManager.GetPurchaseReportAll().ToList();

            var q = (from salPro in SaleProducts
                     join sal in Sale on salPro.Sales.Id equals sal.Id
                     join pur in Purchase on sal.Date.Date equals pur.Date.Date
                     join purpro in PurchaseProducts on new { pur.Id, salPro.ProductId } equals new { purpro.Purchase.Id, purpro.ProductId }
                     join Prod in Product on salPro.ProductId equals Prod.Id
                     join Cat in Category on Prod.CategoryId equals Cat.Id
                     orderby sal.Date.Date
                     where
                      (sal.Date.Date >= startDate.Date && endDate.Date >= sal.Date.Date)
                     select new SalesReportViewModel {  Code = Prod.Code, Name = Prod.Name, Category = Cat.Name, SoldQuantity = salPro.Quantity, CostPrice = purpro.UnitPrice, SalesPrice = salPro.MRP, Profit = salPro.MRP - purpro.UnitPrice, TotalProfit = salPro.Quantity * (salPro.MRP - purpro.UnitPrice) }).ToList();
            ViewBag.x = q;
            return PartialView("Report/_salesReport");

        }
    }
}