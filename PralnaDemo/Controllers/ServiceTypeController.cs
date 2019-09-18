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
    public class ServiceTypeController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /ServiceType/
        public ActionResult Index()
        {
            var servicetypes = db.ServiceTypes.Include(s => s.WorkPlace);
            return View(servicetypes.ToList());
        }

        // GET: /ServiceType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType servicetype = db.ServiceTypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            return View(servicetype);
        }

        // GET: /ServiceType/Create
        public ActionResult Create()
        {
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name");
            return View();
        }

        // POST: /ServiceType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,TimeLimit,UseTimeLimit,WorkPlaceId")] ServiceType servicetype, FormCollection form)
        {
            if(servicetype.UseTimeLimit.HasValue && servicetype.UseTimeLimit.Value == true)
            {
                servicetype.TimeLimit = new TimeSpan(0, Convert.ToInt32(form["TimeLimit"]), 0);
            }
            else
            {
                servicetype.TimeLimit = new TimeSpan(0, 0, 0);
            }
            
            if (ModelState.IsValid)
            {
                db.ServiceTypes.Add(servicetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", servicetype.WorkPlaceId);
            return View(servicetype);
        }

        // GET: /ServiceType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType servicetype = db.ServiceTypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", servicetype.WorkPlaceId);
            return View(servicetype);
        }

        // POST: /ServiceType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,TimeLimit,UseTimeLimit,WorkPlaceId")] ServiceType servicetype, FormCollection form)
        {
            if (servicetype.UseTimeLimit.HasValue && servicetype.UseTimeLimit.Value == true)
            {
                servicetype.TimeLimit = new TimeSpan(0, Convert.ToInt32(form["TimeLimit"]), 0);
            }
            else
            {
                servicetype.TimeLimit = new TimeSpan(0, 0, 0);
            }

            if (ModelState.IsValid)
            {
                db.Entry(servicetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "Id", "Name", servicetype.WorkPlaceId);
            return View(servicetype);
        }

        // GET: /ServiceType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceType servicetype = db.ServiceTypes.Find(id);
            if (servicetype == null)
            {
                return HttpNotFound();
            }
            return View(servicetype);
        }

        // POST: /ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceType servicetype = db.ServiceTypes.Find(id);
            db.ServiceTypes.Remove(servicetype);
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
