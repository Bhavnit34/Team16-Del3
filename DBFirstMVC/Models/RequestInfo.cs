using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //Class to output a view with a request and the list of facilties it requested
    public class RequestInfo
    {
        public Request Request { get; set; }
        public IEnumerable<FacilityRequest> FacilityRequests{get;set;} //IEnumerable as there may be multple facility requests
        public IEnumerable<RequestToRoom> RequestToRooms { get; set; }
        public Room room { get; set; }
        public IEnumerable<Park> Parks { get; set; }
        public Week Week { get; set; }

    }
}