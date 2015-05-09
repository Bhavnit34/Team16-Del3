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
    
    public partial class RoundAndSemester
    {
        public int RoundAndSemesterID { get; set; }
        [Required]
        public Nullable<byte> RoundID { get; set; }
        [Required]
        public Nullable<byte> Semester { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]

        public Nullable<System.DateTime> EndDate { get; set; }
        [Required]
        public Nullable<bool> CurrentRound { get; set; }
    }
}
