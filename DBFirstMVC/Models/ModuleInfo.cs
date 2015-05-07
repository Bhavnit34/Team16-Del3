using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //Model to display the infomation about a module
    public class ModuleInfo

    {
        public Module Module{ get; set; }
        //public ModuleLecturer ModuleLecturer { get; set; }
        public IEnumerable<ModuleLecturer> ModuleLecturers { get; set; }
        public IEnumerable<ModuleDegree> ModuleDegrees { get; set; }
       // public IEnumerable<Degree> Degrees { get; set; }
    }
}