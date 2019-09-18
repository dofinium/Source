using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PralnaDemo.Controllers
{
    public class FeedbackController : Controller
    {
        PralnaEntities db = new PralnaEntities();

        //
        // GET: /Feedback/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Feedback/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [OutputCache(Duration=1, VaryByParam="*")]
        public PartialViewResult ShowFeedbackForm(string key)
        {
            ServiceToClient someServiceToClient = db.ServiceToClients.Where(m => m.UniqueKey.ToLower() == key).Take(1).SingleOrDefault();
            IEnumerable<AllowedViolation> someAllowedViolations = someServiceToClient.ServiceType.AllowedViolations;
            ViewBag.ServiceToClient = someServiceToClient;
            return PartialView(someAllowedViolations);
        }


         [HttpPost]
        public JsonResult Submit(FormCollection form)
        {
            ServiceToClient someServiceToClient = db.ServiceToClients.Find(Convert.ToInt32(form["ServiceToClientId"]));
             if(someServiceToClient != null)
             {
                 someServiceToClient.Value = Convert.ToInt16(form["ClientValue"]);
                 someServiceToClient.ValueSet = DateTime.Now;
                 someServiceToClient.ClientFeedback = form["CommentForViolation"];

                 for (int i = 0; i < form.AllKeys.Count(); i++)
                 {
                     if(form.AllKeys[i].IndexOf("violationType_") < 0)
                     {
                         continue;
                     }

                     int violationType = Convert.ToInt32(form.AllKeys[i].ToString().Replace("violationType_", "")); 
                     if(db.FoundViolations.Where(m=> m.ServiceToClientId == someServiceToClient.Id).Where( m=> m.ViolationTypeId == violationType).Any() == false)
                     {
                         FoundViolation someFoundViolation = new FoundViolation { ServiceToClientId = someServiceToClient.Id, ViolationTypeId = violationType };
                         db.FoundViolations.Add(someFoundViolation);
                         db.SaveChanges();
                     }
                 }

                 db.SaveChanges();
                 return Json("1", JsonRequestBehavior.DenyGet);
             }

            return Json("0", JsonRequestBehavior.DenyGet);
        }

        public ActionResult ThankyouForm()
         {
             return View();
         }

        [OutputCache(Duration=1)]
        public ActionResult TicketsList()
         {
             IEnumerable<ServiceToClient> someServicesToClient = db.ServiceToClients.Where(m => m.ValueSet == null).Take(5);
             return PartialView(someServicesToClient);
         }

         [HttpPost]
         public JsonResult SetValue(string ticketNumber, Int16 value)
         {
             ServiceToClient someServiceToClient = db.ServiceToClients.Where(m => m.UniqueKey == ticketNumber).Take(1).SingleOrDefault();
             if(someServiceToClient == null)
             {
                 return Json(false, JsonRequestBehavior.DenyGet);
             }
             someServiceToClient.Value = value;
             someServiceToClient.ValueSet = DateTime.Now;
             db.Entry(someServiceToClient).State = System.Data.Entity.EntityState.Modified;
             db.SaveChanges();
             return Json(true, JsonRequestBehavior.DenyGet);
         }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            ServiceToClient someServiceToClient = db.ServiceToClients.Find(id);
            someServiceToClient.Value = 0;
            someServiceToClient.ValueSet = null;

            List<FoundViolation> someFoundViolations = someServiceToClient.FoundViolations.ToList();
            foreach(FoundViolation item in someFoundViolations)
            {
                db.Entry(someFoundViolations).State = System.Data.Entity.EntityState.Deleted;
            }
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.DenyGet);
        }

        //
        // GET: /Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Feedback/Create
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
        // GET: /Feedback/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Feedback/Edit/5
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

       
    }
}
