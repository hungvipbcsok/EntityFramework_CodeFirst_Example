using EntityFramework_CodeFirst_Example.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstManageMVC.Controllers
{
    public class MyContractController : Controller
    {
        // GET: MyContract

        CustomerService customerService = new CustomerService();

        public ActionResult MyAction(string name, decimal? money)
        {
            ViewBag.MyData = "This is mess from server";
            ViewBag.Welcome = string.Format("Welcome {0}, your money is {1}", name, money);
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}