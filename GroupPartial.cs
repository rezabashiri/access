using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Modiriat_Gharardadha.Model
{
    [MetadataType(typeof(MetaData))]
    [Helpers.ShowTable(View = true, WitchMenu = Helpers.ShowTable.ShowInMenu.UsersMenu)]

    [System.ComponentModel.DisplayName("گروه های کاربری")]
    public partial class Group
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name="نام گروه")]
            public string GroupName { get; set; }
            [Display(AutoGenerateField=false)]
            public System.DateTime CreationDate { get; set; }
            [Display (Name="از تمام مکانها اجازه دسترسی داشته باشد؟")]
            public bool AllLocationAccess { get; set; }
            [Display (Name="در تمام زمانها اجازه دسترسی داشته باشد")]
            public bool AllTimesAccess { get; set; }
            [Display (Name="تاریخ انقضا")]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> ExpirationDate { get; set; }
            [Display(Name="شنبه")]
            public int Saturday { get; set; }
            [Display(Name = "یک شنبه")]

            public int Sunday { get; set; }
            [Display(Name = "دو شنبه")]

            public int Monday { get; set; }
            [Display(Name = "سه شنبه")]

            public int Tuesday { get; set; }
            [Display(Name = "چهار شنبه")]

            public int Wednesday { get; set; }
            [Display(Name = "پنج شنبه")]

            public int Thursday { get; set; }
            [Display(Name = "جمعه")]

            public int Friday { get; set; }
            [Display(Name = "اولویت")]

            public int Priority { get; set; }
            [Display(Name = "مجوزهای دسترسی")]

            public virtual ICollection<Right> Rights { get; set; }
            [Display(Name = "نقشهای کاربری")]

            public virtual ICollection<Role> Roles { get; set; }
        }
    }
}