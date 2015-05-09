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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Module
    {
        public Module()
        {
            this.ModuleDegrees = new HashSet<ModuleDegree>();
            this.ModuleLecturers = new HashSet<ModuleLecturer>();
            this.Requests = new HashSet<Request>();
        }

        [Required]
        public string ModCode { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Part { get; set; }
        [Required]
        public Nullable<short> Students { get; set; }
         [Required]
        public Nullable<byte> Hours { get; set; }
         [Required]
        public Nullable<byte> Weight { get; set; }
         [Required]
        public string DeptCode { get; set; }
        public string FullModule { get { return ModCode + " - " + Title; } }
    
        public virtual Dept Dept { get; set; }
        public virtual ICollection<ModuleDegree> ModuleDegrees { get; set; }
        public virtual ICollection<ModuleLecturer> ModuleLecturers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
