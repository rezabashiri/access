using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AccessManagementService.Model
{
    [System.ComponentModel.DisplayName("نقشهای سازمانی")]
    [ScaffoldTable(true)]
     
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
            
            [Display(AutoGenerateField=false)]
            public virtual ICollection<Role> Roles { get; set; }
            [Display(AutoGenerateField = false)]
            public virtual ICollection<OrganiztionRole> OrganiztionRole1 { get; set; }
            [Display(Name="نقش سازمانی بالادست")]
            public virtual OrganiztionRole OrganiztionRole2 { get; set; }

        }

        public static IQueryable<OrganiztionRole> GetOrganizationRoles( )
        {
            AccessEntities myen = new AccessEntities();
            return myen.OrganiztionRoles;
        }
        public int SetParrentId(int ID, int? ParrentID)
        {
            using (var myen = new AccessEntities())
            {
                int res =myen.SetOrganizationRoleParrentID(ID, ParrentID);
                return res;
            }
        }
    }
}