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
    
    public partial class RoomFacility
    {
        public int RoomFacilityID { get; set; }
        public string RoomName { get; set; }
        public int FacilityID { get; set; }
    
        public virtual Facility Facility { get; set; }
        public virtual Room Room { get; set; }
    }
}
