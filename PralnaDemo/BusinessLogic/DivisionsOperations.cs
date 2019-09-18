using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class DivisionsOperations
    {
         PralnaEntities db;

         public DivisionsOperations(PralnaEntities db)
        {
            this.db = db;
        }


         public string RenderWorkplacesStatistic(DivisionStatistic someDivisionStat)
         {
             string result = "[ ";

             foreach (WorkplaceStatistic item in someDivisionStat.WorkplaceStatistics.OrderByDescending(m => m.SummaryIndex))
             {
                 result += "{ 'label': '" + item.WorkPlace.Name + "',";
                 result += " 'value': '" + item.SummaryIndex + "'}, ";
             }
             result = result.TrimEnd(',') + " ]";
             return result;
         }

        public DivisionStatistic GetDivisionStatistic(int divisionId, bool fillSubelements)
         {
             Division someDivision = db.Divisions.Find(divisionId);
			

             DivisionStatistic result = new DivisionStatistic(db, someDivision);

            foreach(WorkPlace item in someDivision.WorkPlaces)
            {
                result.ServicesProvided += db.ServiceToClients.Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count();
                result.SuccessServicesProvided += db.ServiceToClients.Where(m=> m.Value == 1).Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count();
                result.FailedServicesProvided += db.ServiceToClients.Where(m => m.Value == -1).Where(m => m.Worker.WorkPlaceId == item.Id).Where(m => m.ValueSet.HasValue).Count(); 
            }

            result.SummaryIndex = ((double)100 / (((double)result.SuccessServicesProvided + (double)result.FailedServicesProvided) / (double)result.FailedServicesProvided));

            if (fillSubelements)
            {
                FillWorkplacesStatistic(result);
            }

            return result;

         }

        public void FillWorkplacesStatistic(DivisionStatistic someDivisionStatistic)
        {
            WorkplacesOperations workplaceOp = new WorkplacesOperations(db);
            someDivisionStatistic.WorkplaceStatistics.Clear();

            foreach (WorkPlace item in someDivisionStatistic.Division.WorkPlaces)
            {
                WorkplaceStatistic someWorkplaceStat = workplaceOp.GetWorkplacesStatistic(item.Id, false);
                someDivisionStatistic.WorkplaceStatistics.Add(someWorkplaceStat);
            }
        }
    }
}