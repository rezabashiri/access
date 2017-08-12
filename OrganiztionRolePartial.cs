using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Modiriat_Gharardadha.Model
{
    [System.ComponentModel.DisplayName("نقشهای سازمانی")]
    [Helpers.ShowTable(View=true,WitchMenu=Helpers.ShowTable.ShowInMenu.UsersMenu)]
    [MetadataType(typeof(MetaData))]
    public partial class OrganiztionRole
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name="نام نقش سازمانی")]
            public string OrganizationRoleName { get; set; }
            [Display(Name="نقش پدر")]
            public Nullable<int> ParentID { get; set; }
            public Nullable<int> IDDepartment { get; set; }
            
            public virtual Department Department { get; set; }
            [Display(AutoGenerateField=false)]
            public virtual ICollection<Role> Roles { get; set; }
        }

        public static IQueryable<OrganiztionRole> GetOrganizationRoles(MPOEntities myen)
        {
            return myen.OrganiztionRoles;
        }
    }
}