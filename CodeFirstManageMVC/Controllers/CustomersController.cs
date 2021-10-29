using EntityFramework_CodeFirst_Example.Model;
using EntityFramework_CodeFirst_Example.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstManageMVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomerService customerService = new CustomerService();
        // GET: Customers
        public ActionResult Index()
        {
            var allCustomers = customerService.GetAll();          
            return View(allCustomers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = customerService.GetById(id.Value);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
    }
}