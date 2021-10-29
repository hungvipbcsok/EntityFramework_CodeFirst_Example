using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFramework_CodeFirst_Example.Interface;
using EntityFramework_CodeFirst_Example.Model;
using EntityFramework_CodeFirst_Example.Service;

namespace CodeFirstManageMVC.Controllers
{
    public class ContractsController : Controller
    {
        private ManagePaymentContext db;
        private IService contractService;
        private ContractTypeService contractTypeService;

        public ContractsController()
        {
            db = new ManagePaymentContext();
            contractService = new ContractService();
            contractTypeService = new ContractTypeService();
        }

        public ContractsController(ManagePaymentContext db, IService contractService, ContractTypeService contractTypeService)
        {
            this.db = db;
            this.contractService = contractService;
            this.contractTypeService = contractTypeService;
        }

        // GET: Contracts
        public ActionResult ActiveContract()
        {
            var contracts = contractService.GetActiveContract();
            return View("Index", contracts);
        }

        /*public ActionResult RemainingContract()
        {
            var contracts = contractService.GetRemainingContract();
            return View("Index", contracts);
        }*/

        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.ContractType);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractId,ContractName,ContractTypeId,AttendName,ContractDate,ContractStart,ContractEnd,TotalAmount,TestColumn")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName", contract.ContractTypeId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName", contract.ContractTypeId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractId,ContractName,ContractTypeId,AttendName,ContractDate,ContractStart,ContractEnd,TotalAmount,TestColumn")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName", contract.ContractTypeId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ExpanseDate(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName", contract.ContractTypeId);*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExpanseDate([Bind(Include = "ContractId,ContractName,ContractTypeId,AttendName,ContractDate,ContractStart,ContractEnd,TotalAmount,TestColumn")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "Id", "ContractTypeName", contract.ContractTypeId);
            return View(contract);
        }
    }
}
