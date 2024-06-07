using System.Data.Entity;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InsuranceApp.Models;

namespace InsuranceApp.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,HasDUI,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);  // We call the CalculateQuote method
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // Quote calculation
        private decimal CalculateQuote(Insuree insuree)  // Separate method
        {
            decimal quote = 50;  // basis of calculation

            int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < insuree.DateOfBirth.DayOfYear)
                age--;

            // Calculate based on age
            if (age <= 18)
                quote += 100;
            else if (age >= 19 && age <= 25)
                quote += 50;
            else
                quote += 25;

            // Calculate based on car year
            if (insuree.CarYear < 2000)
                quote += 25;
            else if (insuree.CarYear > 2015)
                quote += 25;

            // Calculate based on car make and model
            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25;
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25;
            }

            // Calculate based on number of speeding tickets
            quote += insuree.SpeedingTickets * 10;

            // Calculate based on DUI
            if (insuree.HasDUI)
                quote *= 1.25m;

            // Calculate based on coverage type
            if (insuree.CoverageType)
                quote *= 1.50m;

            return quote;
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,HasDUI,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);  // We call the CalculateQuote method
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Adding the Admin action
        public ActionResult Admin()
        {
            return View(db.Insurees.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
