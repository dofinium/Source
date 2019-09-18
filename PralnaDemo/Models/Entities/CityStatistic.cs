using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    public class CityStatistic
    {
        public CityStatistic(PralnaEntities db, int cityId)
        {
            this.db = db;
            this.City = db.Cities.Find(cityId);
            OrganizationStatistic = new List<OrganizationStatistic>();
        }


        public CityStatistic(PralnaEntities db, City city)
        {
            this.db = db;
            this.City = city;
            OrganizationStatistic = new List<OrganizationStatistic>();
        }

        
        public PralnaEntities db { get; set; }
        public City City { get; set; }
        public int ServicesProvided { get; set; }
        public int SuccessServicesProvided { get; set; }
        public int FailedServicesProvided { get; set; }
        public double SummaryIndex { get; set; }
		public string TreeMapData { get; set; }
        
        public List<OrganizationStatistic> OrganizationStatistic { get; set; }


    }
}