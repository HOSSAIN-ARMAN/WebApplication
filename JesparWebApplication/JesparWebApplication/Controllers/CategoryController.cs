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
            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    message = "Category Save successfully";
                }
                else
                {
                    message = "Category Not Save !!";

                }
            }
            else
            {
                message = "Failed to Submit";
            }
            
            ViewBag.Message = message;

            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string message = "";
            Category category = Mapper.Map<Category>(categoryViewModel);
            if (_categoryManager.Update(category))
            {
                message = "Category Update Successfully!!";
            }
            else
            {
                message = "Category Not Updated";
            }
            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Dispaly()
        {
            
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories =  _categoryManager.GetAll();
         
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Dispaly(CategoryViewModel categoryViewModel)
        {
            //List<Category> Categories = _categoryManager.GetAll();
            var Categories = _categoryManager.GetAll();
            if (categoryViewModel.Code != null)
            {
                Categories = Categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
            }
            if (categoryViewModel.Name != null)
            {
                Categories = Categories.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
            }
            categoryViewModel.Categories = Categories;
           
            return View(categoryViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            string message = "";
            Category category = _categoryManager.GetById(id);
            if (_categoryManager.Delete(category.Id))
            {
                message = "Delete SuccessFully!!";
            }
            else
            {
                message = "Data Not Delete!!";
            }
            ViewBag.Message = message;
            return RedirectToAction("Dispaly");
        }

        public JsonResult IsCodeExits(string code)
        {
            bool isExits = false;
            var CategoryCodeList = _categoryManager.GetAll().Where(c => c.Code == code).ToList();

            if (CategoryCodeList.Count() > 0)
            {
                isExits = true;
            }
            return Json(isExits, JsonRequestBehavior.AllowGet);
        }
        
    }
}