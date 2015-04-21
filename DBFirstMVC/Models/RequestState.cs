using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //This model will be used to save the request state when the user redirects to another page temporarily
    public class RequestState
    {
        public Request Request { get; set; }
        public List<string> Facilities { get; set; }
        public List<string> Weeks { get; set; }
        public List<string> Rooms { get; set; }
    }
}