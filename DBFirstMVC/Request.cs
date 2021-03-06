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
    
    public partial class Request
    {
        public Request()
        {
            this.AllocatedRooms = new HashSet<AllocatedRoom>();
            this.FacilityRequests = new HashSet<FacilityRequest>();
            this.RequestToRooms = new HashSet<RequestToRoom>();
        }

        public int RequestID { get; set; }
        public Nullable<short> UserID { get; set; }
        [Required]
        public string ModCode { get; set; }
        [Required]
        public string SessionType { get; set; }
        [Required]
        public Nullable<byte> SessionLength { get; set; }
        [Required]
        public Nullable<byte> DayID { get; set; }
        [Required]
        public Nullable<byte> PeriodID { get; set; }
        public Nullable<byte> PriorityRequest { get; set; }
        public Nullable<byte> AdhocRequest { get; set; }
        public string SpecialRequirements { get; set; }
        [Required]
        public Nullable<byte> Semester { get; set; }
        public Nullable<int> WeekID { get; set; }
        public Nullable<byte> RoundID { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
    
        public virtual ICollection<AllocatedRoom> AllocatedRooms { get; set; }
        public virtual ICollection<FacilityRequest> FacilityRequests { get; set; }
        public virtual Module Module { get; set; }
        public virtual User User { get; set; }
        public virtual Week Week { get; set; }
        public virtual ICollection<RequestToRoom> RequestToRooms { get; set; }
    }
}
