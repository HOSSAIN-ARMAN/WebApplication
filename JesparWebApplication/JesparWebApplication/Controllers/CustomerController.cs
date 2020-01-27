using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Jespar.BLL.BLL;
//using Jespar.DatabaseContext.DatabaseContext;
using Jespar.Model.Model;
using JesparWebApplication.Models;

namespace JesparWebApplication.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();

        //public JesparDbContext _projectDbContext = new JesparDbContext();
      
        // GET: Customer


        [HttpGet]
        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            string message = "";
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            if (ModelState.IsValid)
            {
                if (_customerManager.Add(customer))
                {
                    message = "saved";
                }
                else
                {
                    message = "not saved";
                }
            }
            else
            {
                message = "Faield To Submit";
            }
            

            ViewBag.message = message;

            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }
        [HttpGet]
        public ActionResult DisplayCustomer()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult DisplayCustomer(CustomerViewModel customerViewModel)
        {
            var Customers = _customerManager.GetAll();
            if (customerViewModel.CustomerName != null)
            {
                Customers = Customers.Where(c => c.CustomerName.ToLower().Contains(customerViewModel.CustomerName.ToLower())).ToList();
            }
            customerViewModel.Customers = Customers;
            return View(customerViewModel);
        }
        
        //public ViewResult GetAll()
        //{
        //    return View(_projectDbContext.Customers.ToList());
        //}

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Customer customer = _customerManager.GetById(Id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);


            customerViewModel.Customers = _customerManager.GetAll();


            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            string message = "";
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            if (_customerManager.Update(customer))
            {
                message = "Updated";
            }
            else
            {
                message = "Not Updated";
            }

            ViewBag.Message = message;

            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }


        [HttpGet]
        
        public ActionResult Delete(int id)
        {
            Customer customer = _customerManager.GetById(id);
            string message = "";
            if (_customerManager.Delete(id))
            {
                message = "Delete Succsessfully!!";
            }
            else
            {
                message = "Not delete ";
            }
            ViewBag.Message = message;

            return RedirectToAction("DisplayCustomer");
        }

    }
}