using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    public class WorkplaceStatistic
    {
        public WorkplaceStatistic(PralnaEntities db, int workplaceId)
        {
            this.db = db;
            this.WorkPlace = db.WorkPlaces.Find(workplaceId);
            WorkersStatistics = new List<WorkerStatistic>();
        }


        public WorkplaceStatistic(PralnaEntities db, WorkPlace workPlace)
        {
            this.db = db;
            this.WorkPlace = workPlace;
            WorkersStatistics = new List<WorkerStatistic>();
        }

        
        public PralnaEntities db { get; set; }
        public WorkPlace WorkPlace { get; set; }
        public int ServicesProvided { get; set; }
        public int SuccessServicesProvided { get; set; }
        public int FailedServicesProvided { get; set; }
        public double SummaryIndex { get; set; }
		public string TreeMapData { get; set; }
        
        public List<WorkerStatistic> WorkersStatistics { get; set; }


    }
}