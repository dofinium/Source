using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    public class OrganizationStatistic
    {
       
        public PralnaEntities db { get; set; }
        public int TotalServices { get; set; }
        public int SuccessServices { get; set; }
        public int FailedServices { get; set; }
        public Organization Organization { get; set; }
        public List<DivisionStatistic> DivisionStatistic { get; set; }
        public double SummaryIndex { get; set; } // summary percent of satisfaction 
		public string TreeMapData { get; set; }

        public OrganizationStatistic(PralnaEntities db, Organization someOrganization)
        {
            this.db = db;
            this.Organization = someOrganization;
            DivisionStatistic = new List<DivisionStatistic>();
        }

    }
}