using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProInvesta.Models;

namespace ProInvesta.Controllers
{
    public class LoanController : Controller
    {
        //
        // GET: /Loan/
        DB_A34082_proinvestaEntities _db;

         public LoanController()
        {
            _db = new DB_A34082_proinvestaEntities();
        }

        public ActionResult HomeLoan()
        {
           var home = _db.Loans.ToList().Where(obj => obj.LoanType == "Home");
           return View(home);
        }
        public ActionResult CarLoan()
        {
            var car = _db.Loans.ToList().Where(obj => obj.LoanType == "Car");
            return View(car);
        }
        public ActionResult PersonalLoan()
        {
            var personal = _db.Loans.ToList().Where(obj => obj.LoanType == "Personal");
            return View(personal);
        }

        
        //
        // GET: /Loan/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Loan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Loan/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Loan/Edit/

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Loan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Loan/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Loan/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
