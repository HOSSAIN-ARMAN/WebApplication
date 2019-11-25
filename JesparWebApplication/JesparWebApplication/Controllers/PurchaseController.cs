using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JesparWebApplication.Models;
using Jespar.BLL.BLL;
using Jespar.Model.Model;
using AutoMapper;

namespace JesparWebApplication.Controllers
{

    public class PurchaseController : Controller
    {

        SupplierManager _supplierManager = new SupplierManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseManager _purchaseManager = new PurchaseManager();

        [HttpGet]
        public ActionResult AddPurchase()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();


            purchaseViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();


            purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();

            //if(purchaseViewModel.ProductSelectListItems)


            return View(purchaseViewModel);
        }
        [HttpPost]
        public ActionResult AddPurchase(PurchaseViewModel purchaseViewModel)
        {
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();

            purchaseViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();

            purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem
                                                                                    {
                                                                                        Value = c.Id.ToString(),
                                                                                        Text = c.Name
                                                                                    }).ToList();




            string message = "";
            Purchase purchase = Mapper.Map<Purchase>(purchaseViewModel);
            if (_purchaseManager.Add(purchase))
            {
                message = "Data Save Successfully";
            }
            else
            {
                message = "not save";
            }

            ViewBag.Message = message;

            return View(purchaseViewModel);
        }
    }
}