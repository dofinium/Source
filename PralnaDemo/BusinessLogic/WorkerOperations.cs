using PralnaDemo.Models;
using PralnaDemo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class WorkerOperations
    {
        PralnaEntities db;

        public WorkerOperations(PralnaEntities db)
        {
            this.db = db;
        }

        public WorkerStatistic FillWorkerStatistic(Worker someWorker)
        {
            WorkerStatistic result = new WorkerStatistic(db, someWorker);
            result.ServicesProvided = db.ServiceToClients.Where(m => m.WorkerId == someWorker.Id).Where(m => m.ValueSet.HasValue).Count();
            result.SuccessServicesProvided = db.ServiceToClients.Where(m => m.WorkerId == someWorker.Id).Where(m => m.ValueSet.HasValue).Where(m => m.Value == 1).Count();
            result.FailedServicesProvided = db.ServiceToClients.Where(m => m.WorkerId == someWorker.Id).Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Count();

            result.SummaryIndex = ((double)100 / (((double)result.SuccessServicesProvided + (double)result.FailedServicesProvided) / (double)result.FailedServicesProvided));

            FillServicesData(result);

            return result;

        }


        public void FillServicesData(WorkerStatistic someWorkerStatistic)
        {
           // someWorkerStatistic.ServiceData = new List<WorkerStatistic.ServicesData>();
           
            IEnumerable<ServiceType> providedServiceTypes = db.ServiceTypes.Where(m => m.ProvidedServices.Where(n => n.ValueSet.HasValue).Where(n => n.WorkerId == someWorkerStatistic.Worker.Id).Any()).OrderBy(m=> m.Id);

            foreach(ServiceType item in providedServiceTypes)
            {
                ServicesData someServiceData = new ServicesData(item);

                someServiceData.ServicesToClients = item.ProvidedServices.Where(n => n.ValueSet.HasValue).Where(n => n.WorkerId == someWorkerStatistic.Worker.Id).ToList();

                /*
                OneServiceData someOneServiceDate = new OneServiceData();

                someOneServiceDate.PositiveServices = db.ServiceToClients.Where(m => m.WorkerId == someWorkerStatistic.Worker.Id).Where(m => m.ServiceTypeId == item.Id).Where(m => m.Value == 1);
                someOneServiceDate.NegativeServices = db.ServiceToClients.Where(m => m.WorkerId == someWorkerStatistic.Worker.Id).Where(m => m.ServiceTypeId == item.Id).Where(m => m.Value == -1);
                someOneServiceDate.UnknownServices = db.ServiceToClients.Where(m => m.WorkerId == someWorkerStatistic.Worker.Id).Where(m => m.ServiceTypeId == item.Id).Where(m => m.ValueSet == null);

                 */
                someWorkerStatistic.ServiceData.Add(someServiceData);
            } 
        }

     

        public string RenderFeedbacksByServicesTypesStatistic(int workerId)
        {
            string result = "\"categories\": [  { \"category\": [";
            // X points
            IEnumerable<ServiceType> someServiceTypes = db.ServiceTypes.Where(m => m.ProvidedServices.Where(n => n.WorkerId == workerId).Any()).OrderBy(m => m.Id);

            foreach (ServiceType item in someServiceTypes)
            {
                result += "{ \"label\": \"" + item.Name + "\" },";           
            }
            result = result.TrimEnd(',');
            result += "  ] } ],";

            result += "\"dataset\": [ ";
            #region positive
            result += " { \"seriesname\": \"" + "Позитивні відгуки" + "\", ";
            result += " \"data\": [";

            foreach (ServiceType item in someServiceTypes)
            {
                if (item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue).Where(m => m.Value == 1).Any())
                {
                    result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.ValueSet.HasValue).Where(m=> m.Value == 1).Where(m => m.WorkerId == workerId).Count() + "\"  },"; // total services provided
                }
                else
                {
                    result += " { \"value\": \"" +0 + "\"  },"; // total services provided
                }               
            }
            result = result.TrimEnd(',');
            result += "]";

            result += "},"; // seriesname
            #endregion
            #region негативні
            result += " { \"seriesname\": \"" + "Негативні відгуки" + "\", ";
            result += " \"data\": [";

            foreach (ServiceType item in someServiceTypes)
            {
                if (item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Any())
                {
                    result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Where(m => m.WorkerId == workerId).Count() + "\"  },"; // 
                }
                else
                {
                    result += " { \"value\": \"" + 0 + "\"  },"; // 
                }
            }
            result = result.TrimEnd(',');
            result += "]";

            result += "},"; // seriesname
            #endregion

            #region percentage
            /*
             result += " { \"seriesname\": \"" + "Незадоволеність, %" + "\", ";
            result += "  \"parentYAxis\": \"S\",                     \"renderAs\": \"line\",                    \"showValues\": \"0\",";

            result += " \"data\": [";

            foreach (ServiceType item in someServiceTypes)
            {
                int totalProvided = item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue).Count();
                int failedCount = item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Count();

                    result += " { \"value\": \"" +  StringOperations.GetPercent(totalProvided, failedCount) + "\"  },"; // 
               
            }
            result = result.TrimEnd(',');
            result += "]";

            result += "}"; // seriesname
            */
            #endregion

            /*
            #region Разом
            result += " { \"seriesname\": \"" + "Відгуків разом" + "\", ";
            result += " \"data\": [";

            foreach (ServiceType item in someServiceTypes)
            {
                if (item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue).Any())
                {
                    result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.ValueSet.HasValue).Where(m => m.WorkerId == workerId).Count() + "\"  },"; // 
                }
                else
                {
                    result += " { \"value\": \"" + 0 + "\"  },"; // 
                }
            }
            result = result.TrimEnd(',');
            result += "]";

            result += "},"; // seriesname
            #endregion
            #region заплановано
            result += " { \"seriesname\": \"" + "Заплановано послуг" + "\", ";
            result += " \"data\": [";

            foreach (ServiceType item in someServiceTypes)
            {
                if (item.ProvidedServices.Where(m => m.WorkerId == workerId).Where(m => m.ValueSet.HasValue == false).Any())
                {
                    result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.ValueSet.HasValue == false).Where(m => m.WorkerId == workerId).Count() + "\"  },"; // 
                }
                else
                {
                    result += " { \"value\": \"" + 0 + "\"  },"; // 
                }
            }
            result = result.TrimEnd(',');
            result += "]";

            result += "}"; // seriesname
            #endregion
           */

            /*
            foreach (ServiceType item in db.ServiceTypes.Where(m => m.ProvidedServices.Where(n => n.WorkerId == workerId).Any()).OrderBy(m => m.Id))
            {
                result += " { \"seriesname\": \"" + item.Name + "\", ";
                result += " \"data\": [";
                result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.ValueSet.HasValue).Count() + "\"  },"; // total services provided
                result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.Value == 1).Where(m => m.ValueSet.HasValue).Count() + "\"  },"; // succesfully services provided
                result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.Value == -1).Where(m => m.ValueSet.HasValue).Count() + "\"  },"; // succesfully services provided
                result += " { \"value\": \"" + item.ProvidedServices.Where(m => m.Value == 1).Where(m => m.ValueSet.HasValue == false).Count() + "\"  }"; // ordered, but not provided yet

                result += "]";

                result += "},"; // seriesname
            }
             */

            result = result.TrimEnd(',');
            result += "]";

            return result;
        }

        // for charts
        // 3 lines on one graph: total services provided, satisfied, not satisfied. by months, by services
        public string GetSummaryWorkerStatToDel(WorkerStatistic someWorkerStat)
        {
            string result = "[ ";

           
           /*
            foreach (WorkerStatistic item in someWorkerStat.ServicesToClients.OrderByDescending(m => m.))
            {
                result += "{ 'label': '" + item.Worker.AspNetUser.Name + "',";
                result += " 'value': '" + item.SummaryIndex + "'}, ";
            }
             */

            /*
            foreach (WorkerStatistic item in someWorkerStat.WorkersStatistics.OrderByDescending(m => m.SummaryIndex))
            {
                result += "{ 'label': '" + item.Worker.AspNetUser.Name + "',";
                result += " 'value': '" + item.SummaryIndex + "'}, ";
            }
             */
            result = result.TrimEnd(',') + " ]";
            return result;
        }
    }
}