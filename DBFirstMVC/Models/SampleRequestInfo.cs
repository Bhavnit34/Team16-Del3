using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    public class SampleRequestInfo
    {
        public IQueryable<object> Request { get; set; }
        public List<string> RoomNames { get; set; }
    }
}