using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Modiriat_Gharardadha.Model;
namespace Modiriat_Gharardadha.Model
{
    [MetadataType(typeof(MetaData))]
    [Helpers.ShowTable(View = true, WitchMenu = Helpers.ShowTable.ShowInMenu.UsersMenu)]
    [System.ComponentModel.DisplayName("نقشهای کاربری")]
    public partial class Role
    {

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
            public Nullable<int> DepartmentID { get; set; }
            [Display(AutoGenerateField=false)]
            public Nullable<System.DateTime> LastRefreshTime { get; set; }

            public virtual Department Department { get; set; }
            public virtual User User { get; set; }
            [Display(Name="گروه های کاربری")]
            public virtual ICollection<Group> Groups { get; set; }
            [Display(Name="مجوز های دسترسی")]
            public virtual ICollection<Right> Rights { get; set; }

        }
        public List<Role> ListOfRolesOfUser(int userid, bool isactive)
        {
            MPOEntities myen = Helpers.SessionHelpers.GetContext(HttpContext.Current.Session);
            return  myen.ListRolesOfUser(userid, isactive).ToList<Role>();
        }
    }
}