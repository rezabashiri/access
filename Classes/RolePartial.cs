using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Data.Entity;
namespace AccessManagementService.Model
{
    [MetadataType(typeof(MetaData))]
    
    [System.ComponentModel.DisplayName("نقشهای کاربری")]
    public partial class Role
    {
        AccessEntities _myen;
        private class MetaData
        {
            public int ID { get; set; }
            [Display(AutoGenerateField=false)]
            [ScaffoldColumn(false)]
            public int OrganizationRoleID { get; set; }
            [Display(Name="نام نقش")]
            public string RoleName { get; set; }
            public Nullable<int> UserID { get; set; }
            [Display(Name="فعال؟")]
            public Nullable<bool> IsActive { get; set; }
            [Display(AutoGenerateField=false)]
            public Nullable<int> ParentID { get; set; }
    
            [Display(AutoGenerateField=false)]
            public Nullable<System.DateTime> LastRefreshTime { get; set; }

            [Display(Name="واحدهای مستقل",Description="واحدهایی که کاربر میتواند اطلاعات آنها را ببیند")]
            public virtual ICollection<Department> Departments { get; set; }
            public virtual User User { get; set; }
            [Display(Name="گروه های کاربری")]
            public virtual ICollection<Group> Groups { get; set; }
            [Display(Name="مجوز های دسترسی")]
            public virtual ICollection<Right> Rights { get; set; }

        }
        public List<Role> ListOfRolesOfUser(int userid, bool isactive)
        {
            using (AccessEntities myen = new AccessEntities())
            {
                return myen.ListRolesOfUser(userid, isactive).ToList<Role>();
            }
        }
        public List<Role> ListOfAllRoles(string []includes)
        {
            _myen=new AccessEntities();
            lock(_myen)
            {
                IQueryable<Role> _role = _myen.Roles.AsQueryable<Role>();
                if (includes != null)
                {
                    foreach (string inc in includes)
                    {
                        _role = _role.Include(inc);
                    }
                }
                return _role.Where(x=>x.IsActive == true ).ToList<Role>();
            }
        }
        public static IQueryable<Role> GetRoles()
        {
            AccessEntities myen = new AccessEntities();
            return myen.Roles.Where(x=>x.IsActive == true);
        }
    }
}