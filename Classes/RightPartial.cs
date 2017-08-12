using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AccessManagementService.Model
{
    [MetadataType(typeof(MetaData))]
    [ScaffoldTable(true)]
    [System.ComponentModel.DisplayName("مجوزهای دسترسی")]
    public partial class Right
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name="نام مجوز")]
            public string RightName { get; set; }
            [Display(Name="نام سرویس")]
            [UIHint("RightServiceName")]
            public string RelatedService { get; set; }
            [Display (Name="نوع دسترسی")]
            [UIHint("TypeRight")]
            public short RightType { get; set; }
            [Display(Name="آیا نیاز به تایید دارد؟")]
            public string IsConfirmable { get; set; }
            [Display(Name = "نقش سازمانی")]
 
            public Nullable<int> OrganizationRoleID { get; set; }
            [Display(AutoGenerateField=false)]
            public virtual ICollection<Group> Groups { get; set; }
            [Display(AutoGenerateField = false)]

            public virtual ICollection<Role> Roles { get; set; }
        }
    }
}