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
    
    public partial class Park
    {
        public Park()
        {
            this.Buildings = new HashSet<Building>();
        }
    
        public string ParkID { get; set; }
        public string ParkName { get; set; }
    
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
