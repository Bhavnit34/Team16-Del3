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
    
    public partial class User
    {
        public User()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public short UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    
        public virtual Dept Dept { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
