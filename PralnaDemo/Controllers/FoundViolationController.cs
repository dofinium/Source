using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PralnaDemo.Models;

namespace PralnaDemo.Controllers
{
    public class FoundViolationController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /FoundViolation/
        public ActionResult Index()
        {
            var foundviolations = db.FoundViolations.Include(f => f.ServiceToClient).Include(f => f.ViolationType);
            return View(foundviolations.ToList());
        }

        // GET: /FoundViolation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundViolation foundviolation = db.FoundViolations.Find(id);
            if (foundviolation == null)
            {
                return HttpNotFound();
            }
            return View(foundviolation);
        }

        // GET: /FoundViolation/Create
        public ActionResult Create()
        {
            ViewBag.ServiceToClientId = new SelectList(db.ServiceToClients, "Id", "UniqueKey");
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name");
            return View();
        }

        // POST: /FoundViolation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ServiceToClientId,ViolationTypeId")] FoundViolation foundviolation)
        {
            if (ModelState.IsValid)
            {
                db.FoundViolations.Add(foundviolation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceToClientId = new SelectList(db.ServiceToClients, "Id", "UniqueKey", foundviolation.ServiceToClientId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", foundviolation.ViolationTypeId);
            return View(foundviolation);
        }

        // GET: /FoundViolation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundViolation foundviolation = db.FoundViolations.Find(id);
            if (foundviolation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceToClientId = new SelectList(db.ServiceToClients, "Id", "UniqueKey", foundviolation.ServiceToClientId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", foundviolation.ViolationTypeId);
            return View(foundviolation);
        }

        // POST: /FoundViolation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ServiceToClientId,ViolationTypeId")] FoundViolation foundviolation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foundviolation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceToClientId = new SelectList(db.ServiceToClients, "Id", "UniqueKey", foundviolation.ServiceToClientId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", foundviolation.ViolationTypeId);
            return View(foundviolation);
        }

        // GET: /FoundViolation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoundViolation foundviolation = db.FoundViolations.Find(id);
            if (foundviolation == null)
            {
                return HttpNotFound();
            }
            return View(foundviolation);
        }

        // POST: /FoundViolation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FoundViolation foundviolation = db.FoundViolations.Find(id);
            db.FoundViolations.Remove(foundviolation);
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
    }
}
