//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lecturer
    {
        public Lecturer()
        {
            this.ModuleLecturers = new HashSet<ModuleLecturer>();
        }
    
        public int LecturerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeptCode { get; set; }
        public string Email { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
 
    
        public virtual Dept Dept { get; set; }
        public virtual ICollection<ModuleLecturer> ModuleLecturers { get; set; }
    }
}
