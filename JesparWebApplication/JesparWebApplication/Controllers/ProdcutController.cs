using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.BLL.BLL;
using Jespar.Model.Model;
using JesparWebApplication.Models;

namespace JesparWebApplication.Controllers
{
    public class ProdcutController : Controller
    {

        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
       [HttpGet]
       public ActionResult AddProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.CategorySelectListItems = _categoryManager.GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();


            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel productViewModel)
        {
            string message = "";
            productViewModel.CategorySelectListItems = _categoryManager.GetAll()
                                                      .Select(c => new SelectListItem()
                                                      {
                                                          Value = c.Id.ToString(),
                                                          Text = c.Name
                                                      }).ToList();

            Product product = new Product();
            product.Code = productViewModel.Code;
            product.Name = productViewModel.Name;
            product.ReorderLavel = productViewModel.ReorderLavel;
            product.Description = productViewModel.Description;
            product.CategoryId = productViewModel.CategoryId;

            if (_productManager.Add(product))
            {
                message = "Product add Successfully";
            }
            else
            {
                message = "Product Does Not Added";
            }

            ViewBag.Message = message;

            return View(productViewModel);

        }
    }
}