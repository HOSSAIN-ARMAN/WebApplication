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

            if (ModelState.IsValid)
            {
                if (_productManager.Add(product))
                {
                    message = "Product add Successfully";
                }
                else
                {
                    message = "Product Does Not Added";
                }
            }
            else
            {
                message = "Failed to Submit";
            }

            ViewBag.Message = message;

            return View(productViewModel);

        }
        //[HttpGet]
        //public ActionResult Edit(int Id)
        //{
        //    Product product = _productManager.GetById(Id);
        //    ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);


        //    productViewModel.Products = _productManager.GetAll();


        //    return View(productViewModel);
        //}

        //[HttpPost]
        //public ActionResult Edit(ProductViewModel productViewModel)
        //{
        //    string message = "";
        //    Product product = Mapper.Map<Product>(productViewModel);
        //    if (_productManager.Update(product))
        //    {
        //        message = "Updated";
        //    }
        //    else
        //    {
        //        message = "Not Updated";
        //    }

        //    ViewBag.Message = message;

        //    productViewModel.Products = _productManager.GetAll();
        //    return View(productViewModel);
        //}

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    Product product = _productManager.GetById(id);
        //    string message = "";
        //    if (_productManager.Delete(id))
        //    {
        //        message = "Delete Succsessfully!!";
        //    }
        //    else
        //    {
        //        message = "Not delete ";
        //    }
        //    ViewBag.Message = message;

        //    return RedirectToAction("Search");
        //}
    }
}