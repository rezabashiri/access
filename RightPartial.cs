using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Modiriat_Gharardadha.Model
{
    [MetadataType(typeof(MetaData))]
    [Helpers.ShowTable(View = true, WitchMenu = Helpers.ShowTable.ShowInMenu.UsersMenu)]
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