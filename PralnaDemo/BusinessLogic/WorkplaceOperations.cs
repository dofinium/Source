using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class WorkplacesOperations
    {
        PralnaEntities db;

        public WorkplacesOperations(PralnaEntities db)
        {
            this.db = db;
        }

        public WorkplaceStatistic GetWorkplacesStatistic(int workplaceId, bool fillSubelements)
        {
            WorkPlace someWorkplace = db.WorkPlaces.Find(workplaceId);
            WorkplaceStatistic result = new WorkplaceStatistic(db, someWorkplace);

            foreach (Worker item in someWorkplace.Workers)
            {
                result.ServicesProvided += db.ServiceToClients.Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count();
                result.SuccessServicesProvided += db.ServiceToClients.Where(m => m.Value == 1).Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count();
                result.FailedServicesProvided += db.ServiceToClients.Where(m => m.Value == -1).Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count();
            }

            result.SummaryIndex = ((double)100 / (((double)result.SuccessServicesProvided + (double)result.FailedServicesProvided) / (double)result.FailedServicesProvided));

            if (fillSubelements)
            {
                FillWorkersStatistic(result);
            }

            return result;

        }

        public void FillWorkersStatistic(WorkplaceStatistic someWorkPlaceStat)
        {
            someWorkPlaceStat.WorkersStatistics.Clear();
            WorkerOperations workerOp = new WorkerOperations(db);
           
            foreach (Worker item in someWorkPlaceStat.WorkPlace.Workers)
            {
                WorkerStatistic someWorkerStat = workerOp.FillWorkerStatistic(item);
                someWorkPlaceStat.WorkersStatistics.Add(someWorkerStat);
            }
        }

        // for charts
        public string RenderWorkersStatistic(WorkplaceStatistic someWorkplaceStat)
        {
            string result = "[ ";

            foreach (WorkerStatistic item in someWorkplaceStat.WorkersStatistics.OrderByDescending(m => m.SummaryIndex))
            {
                result += "{ \"label\": \"" + item.Worker.AspNetUser.Name + "\",";
                result += " \"value\": \"" + item.SummaryIndex + "\"},";
            }
            result = result.TrimEnd(',') + " ]";
            return result;
        }

    }
}