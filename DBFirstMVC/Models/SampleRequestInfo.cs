using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //Model to display the request information on the timetable when the user clicks on a tile
    public class SampleRequestInfo
    {
        public IQueryable<object> Request { get; set; }
        public List<string> RoomNames { get; set; }
        public IQueryable<object> Lecturers { get; set; }
        public IQueryable<object> Courses { get; set; }
    }
}