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
    public class WorkPlaceController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /WorkPlace/
        public ActionResult Index()
        {
            var workplaces = db.WorkPlaces.Include(w => w.Division);
            return View(workplaces.ToList());
        }

        // GET: /WorkPlace/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlace workplace = db.WorkPlaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // GET: /WorkPlace/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name");
            return View();
        }

        // POST: /WorkPlace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DivisionId,Name,Description")] WorkPlace workplace)
        {
            if (ModelState.IsValid)
            {
                db.WorkPlaces.Add(workplace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", workplace.DivisionId);
            return View(workplace);
        }

        // GET: /WorkPlace/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlace workplace = db.WorkPlaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", workplace.DivisionId);
            return View(workplace);
        }

        // POST: /WorkPlace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DivisionId,Name,Description")] WorkPlace workplace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workplace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "Id", "Name", workplace.DivisionId);
            return View(workplace);
        }

        // GET: /WorkPlace/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlace workplace = db.WorkPlaces.Find(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: /WorkPlace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkPlace workplace = db.WorkPlaces.Find(id);
            db.WorkPlaces.Remove(workplace);
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
