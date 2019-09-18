using PralnaDemo.BusinessLogic;
using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PralnaDemo.Controllers
{
    public class StatisticController : Controller
    {
        PralnaEntities db = new PralnaEntities();

        //
        // GET: /Statistic/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            CitiesStatisticOperations someCitiesStatOp = new CitiesStatisticOperations(db);
            return View(someCitiesStatOp.GetCitiesStat());

        }
        

        public ActionResult City(int id)
        {
            CityOperations cityStatOp = new CityOperations(db);
            OrganizationOperations orgOp = new OrganizationOperations(db);
            ViewBag.OrganizationStatistic = orgOp.GetWorstOrganizationGraph(cityStatOp.GetCityStatistic(id).OrganizationStatistic);
            ViewBag.BestOrganizationStatistic = orgOp.GetBestOrganizationGraph(cityStatOp.GetCityStatistic(id).OrganizationStatistic);            
            return View(cityStatOp.GetCityStatistic(id));
        }

        // shows ordered list of divisions 
        public ActionResult Organization(int id)
        {
            OrganizationStatistic someOrgStat = new OrganizationStatistic(db, db.Organizations.Find(id));
            OrganizationOperations orgOp = new OrganizationOperations(db);
            someOrgStat = orgOp.GetOrganizationStatistic(id, false);
            orgOp.FillDivisionsStatistic(someOrgStat, false);
            return View(someOrgStat);
        }

        // shows ordered list of workplaces
        public ActionResult Division(int id)
        {
            DivisionStatistic someDivisionStat = new DivisionStatistic(db, db.Divisions.Find(id));
            DivisionsOperations divOp = new DivisionsOperations(db);
            someDivisionStat = divOp.GetDivisionStatistic(id, false);
            divOp.FillWorkplacesStatistic(someDivisionStat);
            return View(someDivisionStat);
        }

        // shows ordered list of workers
        public ActionResult Workplace(int id)
        {
            WorkplaceStatistic someWorkplaceStat = new WorkplaceStatistic(db, db.WorkPlaces.Find(id));
            WorkplacesOperations workplaceOp = new WorkplacesOperations(db);
            someWorkplaceStat = workplaceOp.GetWorkplacesStatistic(id, false);
            workplaceOp.FillWorkersStatistic(someWorkplaceStat);
            return View(someWorkplaceStat);
        }

        // shows ordered list of workers
        public ActionResult Worker(int id)
        {
            WorkerStatistic someWorkerStat = new WorkerStatistic(db, db.Workers.Find(id));
            WorkerOperations workerOp = new WorkerOperations(db);          
            someWorkerStat = workerOp.FillWorkerStatistic(db.Workers.Find(id));           

            return View(someWorkerStat);
        }

        public PartialViewResult ServicesList(int workerId, int serviceType, int valueType)
        {
            IEnumerable<ServiceToClient> model = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.WorkerId == workerId).Where(m => m.ServiceTypeId == serviceType).Where(m=> m.Value == valueType);
            if(valueType == 1)
            {
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsSuccess = false;
            }

            return PartialView(model);
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