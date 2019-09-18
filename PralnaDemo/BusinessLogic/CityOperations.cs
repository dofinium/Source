using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class CityOperations
    {
        PralnaEntities db;

        public CityOperations (PralnaEntities db)
        {
            this.db = db;
        }

        public CityStatistic GetCityStatistic(City someCity)
        {
            CityStatistic result = new CityStatistic(db, someCity);
            result.ServicesProvided = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Worker.WorkPlace.Division.Organization.CityId == someCity.Id).Count();
            result.FailedServicesProvided = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Where(m => m.Worker.WorkPlace.Division.Organization.CityId == someCity.Id).Count();

            result.SuccessServicesProvided = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Value == 1).Where(m => m.Worker.WorkPlace.Division.Organization.CityId == someCity.Id).Count();

            result.SummaryIndex = ((double)100 / (((double)result.SuccessServicesProvided + (double)result.FailedServicesProvided) / (double)result.FailedServicesProvided));
            
            OrganizationOperations orgOp = new OrganizationOperations(db);

            foreach (Organization item in someCity.Organizations)
            {
                OrganizationStatistic someOrgStat = orgOp.GetOrganizationStatistic(item.Id, false);
                result.OrganizationStatistic.Add(someOrgStat);
            }

			result.TreeMapData = GetTreeMapData(result);

           
            return result;
        }

        // returns total counters and list of organizations
        public CityStatistic GetCityStatistic(int id)
        {
            return GetCityStatistic(db.Cities.Find(id));
        }

		private string GetTreeMapData(CityStatistic someCityStat)
		{
			// full value of data parameter
			string result = "[";
			result += "{            \"label\": \"" + someCityStat.City.Name + "\",       \"fillcolor\": \"8c8c8c\",  \"value\": \"" + someCityStat.ServicesProvided + "\",      \"data\":       \r\n\t[ ";


			foreach (OrganizationStatistic organization in someCityStat.OrganizationStatistic)
			{

				result += " \r\n\t{\r\n\t\t\"label\": \"" + organization.Organization.Name + "\",    \"fillcolor\": \"8c8c8c\",  \"value\": \"" + organization.TotalServices + "\", \"data\": \r\n\t\t[\r\n";

				DivisionsOperations divOp = new DivisionsOperations(db);
				
				foreach (DivisionStatistic division in organization.DivisionStatistic)
				{
					DivisionStatistic divisionStat = divOp.GetDivisionStatistic(division.Division.Id, false);
					result += "\r\n\t\t\t{\r\n \t\t\t\t\"label\": \"" + division.Division.Name + "\",  \"value\": \"" + divisionStat.ServicesProvided + "\",  \"sValue\": \"" + divisionStat.SummaryIndex.ToString("0.#") + "\" ";
					result += "\r\n\t\t\t}\r\n\t\t\t ,";

				}
				result = result.TrimEnd(',');
				result += "\r\n\t\t]\r\n \r\n\t}\r\n\t ,";
			}
			result = result.TrimEnd(',');
			result += "\r\n\t]}\r\n]\r\n";

			result += ",\r\n \"colorrange\": {        \"mapbypercent\": \"1\",        \"gradient\": \"1\",        \"minvalue\": \"0\",        \"code\": ";

			result += "   \"7FFF00\",        \"startlabel\": \"Позитивно\",      \"endlabel\": \"Негативно\",        \"color\": [            {";
			result += "\"code\": \"EE0000\",                \"maxvalue\": \"100\",                \"label\": \"Static\"            },            {                \"code\": \"7FFF00\",                \"maxvalue\": \"100\",                \"label\": \"AVERAGE\"            }        ]    }  ";


			return result;
		}


    }
}