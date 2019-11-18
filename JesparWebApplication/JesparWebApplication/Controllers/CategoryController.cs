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
    public class CategoryController : Controller
    {
        CategoryViewModel categoryViewModel = new CategoryViewModel();
        CategoryManager _categoryManager = new CategoryManager();
        [HttpGet]
        public ActionResult CategorySave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategorySave(CategoryViewModel categoryViewModel)
        {
            string message = "";
            Category category = new Category();
            category.Code = categoryViewModel.Code;
            category.Name = categoryViewModel.Name;
            if (_categoryManager.Add(category))
            {
                message = "Category Save successfully";
            }
            else
            {
                message = "Category Not Save !!";

            }
            ViewBag.Message = message;

            return View(categoryViewModel);
        }
    }
}