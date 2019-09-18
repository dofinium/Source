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
    public class AllowedViolationController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /AllowedViolation/
        public ActionResult Index()
        {
            var allowedviolations = db.AllowedViolations.Include(a => a.ServiceType).Include(a => a.ViolationType);
            return View(allowedviolations.ToList());
        }

        // GET: /AllowedViolation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowedViolation allowedviolation = db.AllowedViolations.Find(id);
            if (allowedviolation == null)
            {
                return HttpNotFound();
            }
            return View(allowedviolation);
        }

        // GET: /AllowedViolation/Create
        public ActionResult Create()
        {
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name");
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name");
            return View();
        }

        // POST: /AllowedViolation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ServiceTypeId,ViolationTypeId")] AllowedViolation allowedviolation)
        {
            if (ModelState.IsValid)
            {
                db.AllowedViolations.Add(allowedviolation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", allowedviolation.ServiceTypeId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", allowedviolation.ViolationTypeId);
            return View(allowedviolation);
        }

        // GET: /AllowedViolation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowedViolation allowedviolation = db.AllowedViolations.Find(id);
            if (allowedviolation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", allowedviolation.ServiceTypeId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", allowedviolation.ViolationTypeId);
            return View(allowedviolation);
        }

        // POST: /AllowedViolation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ServiceTypeId,ViolationTypeId")] AllowedViolation allowedviolation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allowedviolation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", allowedviolation.ServiceTypeId);
            ViewBag.ViolationTypeId = new SelectList(db.ViolationTypes, "Id", "Name", allowedviolation.ViolationTypeId);
            return View(allowedviolation);
        }

        // GET: /AllowedViolation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowedViolation allowedviolation = db.AllowedViolations.Find(id);
            if (allowedviolation == null)
            {
                return HttpNotFound();
            }
            return View(allowedviolation);
        }

        // POST: /AllowedViolation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllowedViolation allowedviolation = db.AllowedViolations.Find(id);
            db.AllowedViolations.Remove(allowedviolation);
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
