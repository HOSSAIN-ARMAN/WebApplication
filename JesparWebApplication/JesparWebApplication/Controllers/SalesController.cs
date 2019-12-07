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
    public class SalesController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();

        [HttpGet]
        public ActionResult AddSales()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem
                                                                                        {
                                                                                            Value = c.Id.ToString(),
                                                                                            Text = c.CustomerName
                                                                                        }).ToList();

            ViewBag.Customer = salesViewModel.CustomerSelectListItems;

            salesViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
                                                                                        {
                                                                                            Value = c.Id.ToString(),
                                                                                            Text = c.Name
                                                                                        }).ToList();

            ViewBag.Category = salesViewModel.CategorySelectListItems;


            return View(salesViewModel);
        }

        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = from p in productList select (new { p.Id, p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoyaltyPointByCustomerId(int customerId)
        {
            var customerList = _customerManager.GetAll().Where(c => c.Id == customerId).ToList();
            var loyaltyPoint = from c in customerList select (c.LoyaltyPoint);
            return Json(loyaltyPoint, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductAvailableQuantityAndMrp(int productId)
        {
          
            var productList = _purchaseManager.GetAll().Where(c => c.ProductId == productId).ToList();
            var availavleQty = from p in productList select (new { p.Quantity, p.MRP});
            return Json(availavleQty, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddSales(SalesViewModel salesViewModel)
        {
            salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem
                                                                                        {
                                                                                            Value = c.Id.ToString(),
                                                                                            Text = c.CustomerName
                                                                                        }).ToList();

            ViewBag.Customer = salesViewModel.CustomerSelectListItems;



            salesViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
                                                                                        {
                                                                                            Value = c.Id.ToString(),
                                                                                            Text = c.Name
                                                                                        }).ToList();

            ViewBag.Category = salesViewModel.CategorySelectListItems;

            return View(salesViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}