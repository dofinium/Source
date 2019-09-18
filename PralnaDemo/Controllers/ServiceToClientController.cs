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
    public class ServiceToClientController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /ServiceToClient/
        public ActionResult Index()
        {
            var servicetoclients = db.ServiceToClients.Include(s => s.Worker).Include(s => s.ServiceType).Include(s => s.Client);
            return View(servicetoclients.ToList());
        }

        public ActionResult CreateRandomServices()
        {
            MvcApplication mvcApp = new MvcApplication();
            mvcApp.GenerateServices();
            return RedirectToAction("Index");
        }

        // GET: /ServiceToClient/
        public ActionResult ServicesByWorker(int Id)
        {
            var servicetoclients = db.ServiceToClients.Where(m => m.WorkerId == Id).Include(s => s.Worker).Include(s => s.ServiceType).Include(s => s.Client);
            return View("Index", servicetoclients.ToList());
        }

        // GET: /ServiceToClient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceToClient servicetoclient = db.ServiceToClients.Find(id);
            if (servicetoclient == null)
            {
                return HttpNotFound();
            }
            return View(servicetoclient);
        }

        // GET: /ServiceToClient/Create
        public ActionResult Create()
        {
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "AspNetUser.UserName");
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name");
            ViewBag.ClientId = new SelectList(db.AspNetUsers, "Id", "UserName");
            ServiceToClient model = new ServiceToClient { Value = 0 };
            return View(model);
        }

        // POST: /ServiceToClient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,WorkerId,ServiceTypeId,Value,UniqueKey,ValueSet,IsCallbackAllowed,ClientFeedback,Assigned,Started,Finished,ClientId")] ServiceToClient servicetoclient)
        {
            if (ModelState.IsValid)
            {
                db.ServiceToClients.Add(servicetoclient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "AspNetUser.UserName", servicetoclient.WorkerId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", servicetoclient.ServiceTypeId);
            ViewBag.ClientId = new SelectList(db.AspNetUsers, "Id", "UserName", servicetoclient.ClientId);
            return View(servicetoclient);
        }


        [OutputCache(Duration=1, VaryByParam="*")]
        public PartialViewResult GetData(string key)
        {
            return PartialView(db.ServiceToClients.Where(m => m.UniqueKey.ToLower() == key).Take(1).SingleOrDefault());
        }

        // GET: /ServiceToClient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceToClient servicetoclient = db.ServiceToClients.Find(id);
            if (servicetoclient == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "AspNetUser.UserName", servicetoclient.WorkerId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", servicetoclient.ServiceTypeId);
            ViewBag.ClientId = new SelectList(db.AspNetUsers, "Id", "UserName", servicetoclient.ClientId);
            return View(servicetoclient);
        }

        // POST: /ServiceToClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,WorkerId,ServiceTypeId,Value,UniqueKey,ValueSet,IsCallbackAllowed,ClientFeedback,Assigned,Started,Finished,ClientId")] ServiceToClient servicetoclient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicetoclient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "Id", "AspNetUser.UserName", servicetoclient.WorkerId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "Id", "Name", servicetoclient.ServiceTypeId);
            ViewBag.ClientId = new SelectList(db.AspNetUsers, "Id", "UserName", servicetoclient.ClientId);
            return View(servicetoclient);
        }

        // GET: /ServiceToClient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceToClient servicetoclient = db.ServiceToClients.Find(id);
            if (servicetoclient == null)
            {
                return HttpNotFound();
            }
            return View(servicetoclient);
        }

        // POST: /ServiceToClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceToClient servicetoclient = db.ServiceToClients.Find(id);
            db.ServiceToClients.Remove(servicetoclient);
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
