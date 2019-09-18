using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PralnaDemo.Models
{
    // will store lists of provided services of some worker 
    public class OneServiceDataToDel
    {
       
        public IEnumerable<ServiceToClient> PositiveServices { get; set; }
        public IEnumerable<ServiceToClient> NegativeServices { get; set; }
        public IEnumerable<ServiceToClient> UnknownServices { get; set; }

       
    }

}