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
    public class ViolationTypeController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /ViolationType/
        public ActionResult Index()
        {
            var violationtypes = db.ViolationTypes.Include(v => v.Organization);
            return View(violationtypes.ToList());
        }

        // GET: /ViolationType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationType violationtype = db.ViolationTypes.Find(id);
            if (violationtype == null)
            {
                return HttpNotFound();
            }
            return View(violationtype);
        }

        // GET: /ViolationType/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: /ViolationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,OrganizationId")] ViolationType violationtype)
        {
            if (ModelState.IsValid)
            {
                db.ViolationTypes.Add(violationtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", violationtype.OrganizationId);
            return View(violationtype);
        }

        // GET: /ViolationType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationType violationtype = db.ViolationTypes.Find(id);
            if (violationtype == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", violationtype.OrganizationId);
            return View(violationtype);
        }

        // POST: /ViolationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,OrganizationId")] ViolationType violationtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(violationtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", violationtype.OrganizationId);
            return View(violationtype);
        }

        // GET: /ViolationType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViolationType violationtype = db.ViolationTypes.Find(id);
            if (violationtype == null)
            {
                return HttpNotFound();
            }
            return View(violationtype);
        }

        // POST: /ViolationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViolationType violationtype = db.ViolationTypes.Find(id);
            db.ViolationTypes.Remove(violationtype);
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
