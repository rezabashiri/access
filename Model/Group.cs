//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessManagementService.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        public Group()
        {
            this.Rights = new HashSet<Right>();
            this.Roles = new HashSet<Role>();
        }
    
        public int ID { get; set; }
        public string GroupName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public bool AllLocationAccess { get; set; }
        public bool AllTimesAccess { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> Saturday { get; set; }
        public Nullable<int> Sunday { get; set; }
        public Nullable<int> Monday { get; set; }
        public Nullable<int> Tuesday { get; set; }
        public Nullable<int> Wednesday { get; set; }
        public Nullable<int> Thursday { get; set; }
        public Nullable<int> Friday { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ICollection<Right> Rights { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}