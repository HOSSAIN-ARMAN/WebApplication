using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.BLL.BLL;
using Jespar.Model.Model;
using JesparWebApplication.Models;
using AutoMapper;


namespace JesparWebApplication.Controllers
{
    public class StockController : Controller
    {

        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();

        [HttpGet]
        public ActionResult DisplayStock(/*int productId*/)
        {
            StockViewModel stockViewModel = new StockViewModel();

            stockViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
                                                                            {
                                                                                Value = c.Id.ToString(),
                                                                                Text = c.Name
                                                                            }).ToList();


            ViewBag.Category = stockViewModel.CategorySelectListItems;

            //StockReport

            var categories = _categoryManager.GetAll();
            var products = _productManager.GetAll();
            var purchase = _purchaseManager.GetPurchaseReportAll();
            var purchasedetails = _purchaseManager.GetAll();

            var stockReport = from pDetails in purchasedetails
                              join p in purchase on pDetails.PurchaseId equals p.Id
                              join pro in products on pDetails.ProductId equals pro.Id
                              join c in categories on pro.CategoryId equals c.Id
                              //where pro.Id == productId
                              select (new
                              {
                                  pro = new { pro.Code, pro.Name, pro.ReorderLavel },
                                  c = new { c.Name },
                                  pDetails = new { pDetails.ExpireDateTime }
                              });



            var test = "";
            foreach (var da in stockReport)
            {
                List<string> tests = new List<string>()
                {
                   da.pro.Code, da.pro.Name, da.pro.ReorderLavel.ToString(), da.c.Name, da.pDetails.ExpireDateTime.ToString()
                };

                ViewBag.test2 = tests;

                test = da.pro.ReorderLavel.ToString();
                //var productInfo = da.pro;
                //var categoryInfo = da.c;
                //var productDetails = da.pDetails;
            }

            ViewBag.test = test;
            return View(stockViewModel);
        }
        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = from p in productList select (new { p.Id, p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        //public void GetStokResult(int productId)
        //{
        //    var categories = _categoryManager.GetAll();
        //    var products = _productManager.GetAll();
        //    var purchase = _purchaseManager.GetPurchaseReportAll();
        //    var purchasedetails = _purchaseManager.GetAll();

        //    var stockReport = (from pDetails in purchasedetails
        //                       join p in purchase on pDetails.PurchaseId equals p.Id
        //                       join pro in products on pDetails.ProductId equals pro.Id
        //                       join c in categories on pro.CategoryId equals c.Id
        //                       where pro.Id == productId
        //                       select (new {
        //                                pro = new {pro.Code, pro.Name, pro.ReorderLavel},
        //                                c = new {c.Name},
        //                                pDetails = new {pDetails.ExpireDateTime}
        //                              })
        //                       );

        //}
    }
}