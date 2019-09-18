using PralnaDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class OrganizationOperations
    {
        PralnaEntities db;
        public OrganizationOperations(PralnaEntities db)
        {
            this.db = db;
        }

        public OrganizationStatistic GetOrganizationStatistic(int id, bool fillSubitems)
        {
            Organization someOrganization = db.Organizations.Find(id);
            OrganizationStatistic someOrgStat = new OrganizationStatistic(db, someOrganization);
            someOrgStat.TotalServices = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Worker.WorkPlace.Division.OrganizationId == someOrganization.Id).Count();

            someOrgStat.SuccessServices = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Value == 1).Where(m => m.Worker.WorkPlace.Division.OrganizationId == someOrganization.Id).Count();

            someOrgStat.FailedServices = db.ServiceToClients.Where(m => m.ValueSet.HasValue).Where(m => m.Value == -1).Where(m => m.Worker.WorkPlace.Division.OrganizationId == someOrganization.Id).Count();

            someOrgStat.SummaryIndex = ((double)100 / (((double)someOrgStat.SuccessServices + (double)someOrgStat.FailedServices) / (double)someOrgStat.FailedServices));

            FillDivisionsStatistic(someOrgStat, fillSubitems);

			someOrgStat.TreeMapData = GetTreeMapData(someOrgStat);

            return someOrgStat;
        }



        public string GetSummaryDivisionsStat(OrganizationStatistic someOrganizationsStat)
        {
            string result = "[ ";

            foreach (DivisionStatistic item in someOrganizationsStat.DivisionStatistic.OrderByDescending(m => m.SummaryIndex))
            {
                result += "{ 'label': '" + item.Division.Name + "',";
                result += " 'value': '" + item.SummaryIndex + "'}, ";
            }
            result = result.TrimEnd(',') + " ]";            
            return result;
        }

		private string GetTreeMapData(OrganizationStatistic someOrgStat)
		{
			// full value of data parameter
			string result = "["; 
			result += "{            \"label\": \"" + someOrgStat.Organization.Name + "\",       \"fillcolor\": \"8c8c8c\",  \"value\": \"" + someOrgStat.TotalServices + "\",      \"data\":       \r\n\t[ ";


			foreach (DivisionStatistic division in someOrgStat.DivisionStatistic)
			{
				result += " \r\n\t{\r\n\t\t\"label\": \"" + division.Division.Name + "\",    \"fillcolor\": \"8c8c8c\",  \"value\": \"" + division.ServicesProvided + "\", \"data\": \r\n\t\t[\r\n";

				DivisionsOperations divisionOp = new DivisionsOperations(db);
				divisionOp.FillWorkplacesStatistic(division);
	
				foreach (WorkplaceStatistic workplaceStatistic in division.WorkplaceStatistics)
				{					
					result += "\r\n\t\t\t{\r\n \t\t\t\t\"label\": \"" + workplaceStatistic.WorkPlace.Name + "\",  \"value\": \"" + workplaceStatistic.ServicesProvided + "\",  \"sValue\": \"" + workplaceStatistic.SummaryIndex.ToString("0.#") + "\" ";
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

        // organization has divisions. It fills their indexes here
        public void FillDivisionsStatistic(OrganizationStatistic someOrgStat, bool fillSubitems)
        {
            someOrgStat.DivisionStatistic.Clear();
            DivisionsOperations divisionOp = new DivisionsOperations(db);
            foreach(Division item in someOrgStat.Organization.Divisions.ToList())
            {
                DivisionStatistic someDivStat = new DivisionStatistic(db, item);
                someDivStat = divisionOp.GetDivisionStatistic(item.Id, fillSubitems);
                someOrgStat.DivisionStatistic.Add(someDivStat);
            }
            
        }
        
        public string GetWorstOrganizationGraph(List<OrganizationStatistic> someOrganizationStatistic)
        {
            string result = " [ ";

            foreach(OrganizationStatistic item in someOrganizationStatistic.OrderByDescending(m=> m.FailedServices))
            {
                result += "{ 'label': '" + item.Organization.Name + "', ";
                result += " 'value': '" + item.FailedServices + "'},";
            }

            result = result.TrimEnd(',') + " ]";
            return result;
        }

        public string GetBestOrganizationGraph(List<OrganizationStatistic> someOrganizationStatistic)
        {
            string result = " [ ";

            foreach (OrganizationStatistic item in someOrganizationStatistic.OrderByDescending(m => m.SuccessServices))
            {
                result += "{ 'label': '" + item.Organization.Name + "', ";
                result += " 'value': '" + item.SuccessServices + "'},";
            }

            result = result.TrimEnd(',') + " ]";
            return result;
        }
                
    }
}