using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jespar.Model.Model;
using Jespar.BLL.BLL;


namespace JesparWebApplication.Controllers
{
    public class SupplierController : Controller
    {
      
        //// GET: Supplier
        //public ActionResult Index()
        //{
        //    return View();
        //}

        SupplierManager _supplierManager = new SupplierManager();
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Supplier supplier)
        {
            string message = "";
            if (_supplierManager.Save(supplier))
            {
                message = "Supplier Data Save Successfully";
            }
            else
            {
                message = "Data Not Save ";
            }
            ViewBag.message = message;


            return View();
        }
        //[HttpGet]
        public ActionResult Show()
        {
            List<Supplier> aSuppliers = _supplierManager.GetAll();
            ViewBag.a = aSuppliers;
            return View();
        }

    }
}