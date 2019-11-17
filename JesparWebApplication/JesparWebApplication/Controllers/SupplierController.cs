using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;
using Jespar.BLL.BLL;
using JesparWebApplication.Models;
using AutoMapper;

namespace JesparWebApplication.Controllers
{
    public class SupplierController : Controller
    {

        SupplierManager _supplierManager = new SupplierManager();

        [HttpGet]
        public ActionResult Save()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
           
            return View(supplierViewModel);
        }
        [HttpPost]
        public ActionResult Save(SupplierViewModel supplierViewModel)
        {
            string message = "";

            //Supplier supplier = new Supplier();
            //supplier.Code = supplierViewModel.Code;
            //supplier.Name = supplierViewModel.Name;
            //supplier.Address = supplierViewModel.Address;
            //supplier.Email = supplierViewModel.Email;
            //supplier.Contact = supplierViewModel.Contact;
            //supplier.LoyaltyPoint = supplierViewModel.LoyaltyPoint;

            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
            if (ModelState.IsValid)
            {
                if (_supplierManager.Save(supplier))
                {
                    message = "Supplier Data Save Successfully";
                }
                else
                {
                    message = "Data Not Save ";
                }
            }
            else
            {
                message = "ModelState failed";
            }
           
            ViewBag.message = message;

            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }
        [HttpGet]
        public ActionResult Search()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }
        [HttpPost]
        public ActionResult Search(SupplierViewModel supplierViewModel)
        {
            List<Supplier> suppliers = _supplierManager.GetAll();
            if(supplierViewModel.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.Contains(supplierViewModel.Code)).ToList();
            }
            supplierViewModel.Suppliers = suppliers;
            return View(supplierViewModel);

        }
        ////[HttpGet]
        //public ActionResult Show()
        //{
        //    List<Supplier> aSuppliers = _supplierManager.GetAll();
        //    ViewBag.a = aSuppliers;
        //    return View();
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.GetById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
                       
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }
        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Update(supplier))
                {
                    message = "Update SuccessFuly!!";
                }
                else
                {
                    message = "Not Updated";
                }

            }
            else
            {
                message = "Modelstate failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
        }
        





    }
}