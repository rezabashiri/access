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
    
    public partial class Entity
    {
        public Entity()
        {
            this.Rights = new HashSet<Right>();
        }
    
        public int ID { get; set; }
        public string VirtualAddress { get; set; }
        public string EntityName { get; set; }
        public string EntityFarsiName { get; set; }
        public Nullable<int> EntityType { get; set; }
        public string MenuDisplayTitle { get; set; }
    
        public virtual ICollection<Right> Rights { get; set; }
    }
}
