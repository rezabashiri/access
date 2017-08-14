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
    
    public partial class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<bool> MarriedStatus { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<short> CountryNo { get; set; }
        public Nullable<byte> LanguageNo { get; set; }
        public string Address { get; set; }
        public string E_Mail { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> EditionDate { get; set; }
        public Nullable<System.DateTime> LastRefreshTime { get; set; }
        public Nullable<System.DateTime> LastChangePassDate { get; set; }
        public string NativeID { get; set; }
        public string PersonnelID { get; set; }
        public string ActiveSessionID { get; set; }
        public string SystemProfile { get; set; }
        public string IPLocation { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
