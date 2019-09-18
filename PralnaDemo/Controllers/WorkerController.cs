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
    public class WorkerController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /Worker/
        public ActionResult Index()
        {
            var workers = db.Workers.Include(w => w.WorkPlace).Include(w => w.AspNetUser);
            return View(workers.ToList());
        }

        // GET: /Worker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: /Worker/Create
        public ActionResult Create()
        {
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name");
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: /Worker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,WorkPlaceId,IsFormer,StartDate,EndDate,AspNetUserId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", worker.WorkPlaceId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName", worker.AspNetUserId);
            return View(worker);
        }

        // GET: /Worker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", worker.WorkPlaceId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName", worker.AspNetUserId);
            return View(worker);
        }

        // POST: /Worker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,WorkPlaceId,IsFormer,StartDate,EndDate,AspNetUserId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", worker.WorkPlaceId);
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "UserName", worker.AspNetUserId);
            return View(worker);
        }

        // GET: /Worker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: /Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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
