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
    public class UserManagerController : Controller
    {
        private PralnaEntities db = new PralnaEntities();

        // GET: /UserManager/
        public ActionResult Index()
        {
            var aspnetusers = db.AspNetUsers.Include(a => a.PublicImage);
            return View(aspnetusers.ToList());
        }

        // GET: /UserManager/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuser);
        }

        // GET: /UserManager/Create
        public ActionResult Create()
        {
            ViewBag.PhotoId = new SelectList(db.PublicImages, "Id", "FileName");
            return View();
        }

        // POST: /UserManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserName,PasswordHash,SecurityStamp,Name,PhotoId,PhoneNumber,Skype,Viber,Website,About,FacebookProfile,VkontakteProfile,RequiresModeration,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,IsDeleted,UserId,TaxNumber,Index,Photo,Discriminator")] AspNetUser aspnetuser)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(aspnetuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhotoId = new SelectList(db.PublicImages, "Id", "FileName", aspnetuser.PhotoId);
            return View(aspnetuser);
        }

        // GET: /UserManager/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoId = new SelectList(db.PublicImages, "Id", "FileName", aspnetuser.PhotoId);
            return View(aspnetuser);
        }

        // POST: /UserManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserName,PasswordHash,SecurityStamp,Name,PhotoId,PhoneNumber,Skype,Viber,Website,About,FacebookProfile,VkontakteProfile,RequiresModeration,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,IsDeleted,UserId,TaxNumber,Index,Photo,Discriminator")] AspNetUser aspnetuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspnetuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhotoId = new SelectList(db.PublicImages, "Id", "FileName", aspnetuser.PhotoId);
            return View(aspnetuser);
        }

        // GET: /UserManager/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuser);
        }

        // POST: /UserManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspnetuser);
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
