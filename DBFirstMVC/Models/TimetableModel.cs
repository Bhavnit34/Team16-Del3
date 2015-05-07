using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //Model for displaying the lecturer and degree information on the timetable page
    public class TimetableModel
    {
        public IEnumerable<Lecturer> Lecturer { get; set; }
        public IEnumerable<Degree> Degree { get; set; }
    }
}