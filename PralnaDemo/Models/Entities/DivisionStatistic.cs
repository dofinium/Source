using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    public class DivisionStatistic
    {
        public DivisionStatistic(PralnaEntities db, int divisionId)
        {
            this.db = db;
            this.Division = db.Divisions.Find(divisionId);
            WorkplaceStatistics = new List<WorkplaceStatistic>();
        }


        public DivisionStatistic(PralnaEntities db, Division division)
        {
            this.db = db;
            this.Division = division;
            WorkplaceStatistics = new List<WorkplaceStatistic>();
            ServicesProvided = 0;
            SuccessServicesProvided = 0;
            FailedServicesProvided = 0;
        }

        
        public PralnaEntities db { get; set; }
        public Division Division { get; set; }
        public int ServicesProvided { get; set; }
        public int SuccessServicesProvided { get; set; }
        public int FailedServicesProvided { get; set; }
        public double SummaryIndex { get; set; }
		public string TreeMapData { get; set; }
        
        public List<WorkplaceStatistic> WorkplaceStatistics { get; set; }


    }
}