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
    
    public partial class Dept
    {
        public Dept()
        {
            this.Degrees = new HashSet<Degree>();
            this.Lecturers = new HashSet<Lecturer>();
            this.Modules = new HashSet<Module>();
            this.Rooms = new HashSet<Room>();
            this.Users = new HashSet<User>();
        }
    
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
    
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
