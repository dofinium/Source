using PralnaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.BusinessLogic
{
    public class CitiesStatisticOperations
    {
        PralnaEntities db;

        public CitiesStatisticOperations(PralnaEntities db)
        {
            this.db = db;
        }

        public CitiesStatistic GetCitiesStat()
        {
            CitiesStatistic result = new CitiesStatistic(db);
            List<City> someCities = db.Cities.ToList();

            result.GraphData = "[";

            CityOperations cityOp = new CityOperations(db);
            foreach(City item in someCities)
            {
                CityStatistic someCityStat = cityOp.GetCityStatistic(item);

                result.TotalServicesProvided += someCityStat.ServicesProvided;
                result.TotalSuccessServicesCount += someCityStat.SuccessServicesProvided;
                result.TotalFailedServicesCount += someCityStat.FailedServicesProvided;

                result.GraphData += "{ 'label': '" + item.Name + "', 'value': '" + someCityStat.ServicesProvided + "' },";           

                result.CitiesStats.Add(someCityStat);
            }

            result.GraphData = result.GraphData.TrimEnd(',') + "]";
            result.TreeMapData = GetTreeMapData(result);
			result.DetailedTreeMapData = GetDetailedTreeMapData(result);
            return result;
        }

        private string GetTreeMapData(CitiesStatistic someSitiesStat)
        {
            
            // full value of data parameter. Should be quoted in view
            string result = "["; //  "data": [
			result += "{            \"label\": \"Україна\",       \"fillcolor\": \"8c8c8c\",  \"value\": \"" + someSitiesStat.TotalServicesProvided +  "\",      \"data\":       \r\n\t[ ";


            foreach(CityStatistic city in someSitiesStat.CitiesStats)
            {
               
				result += " \r\n\t{\r\n\t\t\"label\": \"" + city.City.Name + "\",    \"fillcolor\": \"8c8c8c\",  \"value\": \"" + city.ServicesProvided + "\", \"data\": \r\n\t\t[\r\n";

                OrganizationOperations orgOp = new OrganizationOperations(db);
               
                foreach(Organization organization in city.City.Organizations)
                {
                  
                    OrganizationStatistic orgStat = orgOp.GetOrganizationStatistic(organization.Id, false);
                    result += "\r\n\t\t\t{\r\n \t\t\t\t\"label\": \"" + organization.Name + "\",  \"value\": \"" + orgStat.TotalServices + "\",  \"sValue\": \"" + orgStat.SummaryIndex.ToString("0.#") + "\" "; 
                    result += "\r\n\t\t\t}\r\n\t\t\t ,";
				   
                }
                result = result.TrimEnd(',');
                result += "\r\n\t\t]\r\n \r\n\t}\r\n\t ,"; // data of city
            }
            result = result.TrimEnd(',');
            result += "\r\n\t]}\r\n]\r\n";

             result +=",\r\n \"colorrange\": {        \"mapbypercent\": \"1\",        \"gradient\": \"1\",        \"minvalue\": \"0\",        \"code\": ";

			 result += "   \"7FFF00\",        \"startlabel\": \"Позитивно\",      \"endlabel\": \"Негативно\",        \"color\": [            {";
			 result += "\"code\": \"EE0000\",                \"maxvalue\": \"100\",                \"label\": \"Static\"            },            {                \"code\": \"7FFF00\",                \"maxvalue\": \"100\",                \"label\": \"AVERAGE\"            }        ]    }  ";
            

            return result;
        }

		private string GetDetailedTreeMapData(CitiesStatistic someSitiesStat)
		{

			// full value of data parameter. Should be quoted in view
			string result = "["; //  "data": [
			result += "{            \"label\": \"Україна\",       \"fillcolor\": \"8c8c8c\",  \"value\": \"" + someSitiesStat.TotalServicesProvided + "\",      \"data\":       \r\n\t[ ";


			foreach (CityStatistic city in someSitiesStat.CitiesStats)
			{

				result += " \r\n\t{\r\n\t\t\"label\": \"" + city.City.Name + "\",    \"fillcolor\": \"8c8c8c\",  \"value\": \"" + city.ServicesProvided + "\", \"data\": \r\n\t\t[\r\n";
				

					IEnumerable<Worker> someWorkers = db.Workers.Where(m => m.WorkPlace.Division.Organization.CityId == city.City.Id).OrderByDescending(m=> m.ServicesToClients.Count());

					foreach (Worker worker in someWorkers)
					{
						WorkerOperations workerOp = new WorkerOperations(db);
						WorkerStatistic someWorkerStat = workerOp.FillWorkerStatistic(worker);

						result += "\r\n\t\t\t{\r\n \t\t\t\t\"label\": \"" + worker.AspNetUser.Name + "\",  \"value\": \"" + worker.ServicesToClients.Where(m => m.ValueSet.HasValue).Count() + "\",  \"sValue\": \"" + someWorkerStat.SummaryIndex.ToString("0.#") + "\" ";
						result += "\r\n\t\t\t}\r\n\t\t\t ,";
					}
					
					/*
					result += "\r\n\t\t\t{\r\n \t\t\t\t\"label\": \"" + organization.Name + "\",  \"value\": \"" + orgStat.TotalServices + "\",  \"sValue\": \"" + orgStat.SummaryIndex.ToString("0.#") + "\" ";
					result += "\r\n\t\t\t}\r\n\t\t\t ,";
					 */

				
				result = result.TrimEnd(',');
				result += "\r\n\t\t]\r\n \r\n\t}\r\n\t ,"; // data of city
			}
			result = result.TrimEnd(',');
			result += "\r\n\t]}\r\n]\r\n";

			result += ",\r\n \"colorrange\": {        \"mapbypercent\": \"1\",        \"gradient\": \"1\",        \"minvalue\": \"0\",        \"code\": ";

			result += "   \"7FFF00\",        \"startlabel\": \"Позитивно\",      \"endlabel\": \"Негативно\",        \"color\": [            {";
			result += "\"code\": \"EE0000\",                \"maxvalue\": \"100\",                \"label\": \"Static\"            },            {                \"code\": \"7FFF00\",                \"maxvalue\": \"100\",                \"label\": \"AVERAGE\"            }        ]    }  ";


			return result;
		}

        public string GetSummaryCitiesStat(CitiesStatistic someCitiesStat)
        {
            string result = "[ {  'category': [";

            foreach( CityStatistic item in someCitiesStat.CitiesStats )
            {
                result += "{ 'label': '" + item.City.Name + "'},";
            }
            result = result.TrimEnd(',') + "] } ],";
            result += " 'dataset': [ ";

            #region Total
            /*
            result += "{ 'seriesname': 'разом' ,";
            result += " 'data': [ ";

            foreach (CitiesStatistic.OneCityStat item in someCitiesStat.CitiesStats)
            {               
                result += "{ 'value': '" + item.ServicesProvidedCount + "'}, ";              
            }            
            result += " ] },";
             */
            #endregion
            #region Successful
            result += "{ 'seriesname': 'успішно' ,";
            result += " 'data': [ ";

            foreach (CityStatistic item in someCitiesStat.CitiesStats)
            {
                result += "{ 'value': '" + item.SuccessServicesProvided + "'}, ";
            }
            result += " ] },";
            #endregion
            #region Failed
            result += "{ 'seriesname': 'неуспішно' ,";
            result += " 'data': [ ";

            foreach (CityStatistic item in someCitiesStat.CitiesStats)
            {
                result += "{ 'value': '" + item.FailedServicesProvided + "'}, ";
            }
            result += " ] } ]";
            #endregion
            return result;
        }
    }
}