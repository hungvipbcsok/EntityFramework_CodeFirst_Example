using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFramework_CodeFirst_Example.Model;
using EntityFramework_CodeFirst_Example.Service;

namespace CodeFirstManageMVC.Controllers
{
    public class ContractTypesController : Controller
    {
        /*private ManagePaymentContext db = new ManagePaymentContext();*/

        private ContractTypeService contractTypeService = new ContractTypeService();

        [ChildActionOnly]
        public ActionResult GetAllContractTypeForLeftMenu()
        {
            var allContractType = contractTypeService.GetAll();
            return PartialView("_LeftMenu" ,allContractType);
        }

        // GET: ContractTypes
        public ActionResult Index()
        {
            var allContractType = contractTypeService.GetAll();
            ViewBag.SuccessMessage = TempData["success"];
            ViewBag.Count = allContractType.Count;
            return View(allContractType);
        }

        // GET: ContractTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractType contractType = contractTypeService.GetById(id.Value);
            if (contractType == null)
            {
                return HttpNotFound();
            }
            return View(contractType);
        }

        // GET: ContractTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContractTypeName,MinValue,MaxValue")] ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                contractTypeService.Create(contractType);
                TempData["success"] = "Create success";
                return RedirectToAction("Index");
            }

            return View(contractType);
        }

        // GET: ContractTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractType contractType = contractTypeService.GetById(id.Value);
            if (contractType == null)
            {
                return HttpNotFound();
            }
            return View(contractType);
        }

        // POST: ContractTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContractTypeName,MinValue,MaxValue")] ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                contractTypeService.Update(contractType);
                return RedirectToAction("Index");
            }
            return View(contractType);
        }

        // GET: ContractTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractType contractType = contractTypeService.GetById(id.Value);
            if (contractType == null)
            {
                return HttpNotFound();
            }
            return View(contractType);
        }

        // POST: ContractTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contractTypeService.Remove(id);           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contractTypeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
