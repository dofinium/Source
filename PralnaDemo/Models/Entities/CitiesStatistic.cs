using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    // this model can be passed to view and graph should be built on it
    public class CitiesStatistic
    {
        // загальна кількість впровадженних послуг по усіх городах
        public int TotalServicesProvided { get; set; }
        public int TotalSuccessServicesCount { get; set; }
        public int TotalFailedServicesCount { get; set; }
        public string GraphData { get; set; }
        public double SummaryIndex { get; set; }     
        public List<CityStatistic> CitiesStats { get; set; }
        public string TreeMapData { get; set; }
		public string DetailedTreeMapData { get; set; }
        public PralnaEntities db { get; set; }

       
        public CitiesStatistic(PralnaEntities db)
        {
            this.db = db;
            TotalServicesProvided = 0;
            CitiesStats = new List<CityStatistic>();
            GraphData = "";
        }

    }
}