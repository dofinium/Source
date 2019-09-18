using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    public class WorkerStatistic
    {
        public PralnaEntities db;
        public WorkerStatistic(PralnaEntities db, int workerId)
        {
            this.db = db;
            this.Worker = db.Workers.Find(workerId);
            ServiceData = new List<ServicesData>();
        }

        public WorkerStatistic(PralnaEntities db, Worker worker)
        {
            this.db = db;
            this.Worker = worker;
            ServiceData = new List<ServicesData>();
         
        }
       
        public Worker Worker { get; set; }
        public int ServicesProvided { get; set; }
        public int SuccessServicesProvided { get; set; }
        public int FailedServicesProvided { get; set; }
        public double SummaryIndex { get; set; }
		public string TreeMapData { get; set; }

        public List<ServicesData> ServiceData { get; set; } 

    }

    //данные по каждому типу услуг
    public class ServicesData
    {
        public ServiceType ServiceType { get; set; }
        public List<ServiceToClient> ServicesToClients { get; set; } // предоставленные услуги всех типов      

        public ServicesData(ServiceType someServiceType)
        {           
            this.ServiceType = someServiceType;
            ServicesToClients = new List<ServiceToClient>();

        }
    }

}