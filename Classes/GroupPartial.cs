using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AccessManagementService.Model
{
    [MetadataType(typeof(MetaData))]


    [System.ComponentModel.DisplayName("گروه های کاربری")]
    public partial class Group
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name = "نام گروه")]
            public string GroupName { get; set; }
            [Display(AutoGenerateField = false)]
            [System.ComponentModel.DefaultValue(null)]


            public Nullable<System.DateTime> CreationDate { get; set; }
            [Display(Name = "از تمام مکانها اجازه دسترسی داشته باشد؟")]
            public bool AllLocationAccess { get; set; }
            [Display(Name = "در تمام زمانها اجازه دسترسی داشته باشد")]
            public bool AllTimesAccess { get; set; }
            [Display(Name = "تاریخ انقضا")]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> ExpirationDate { get; set; }
            [Display(Name = "شنبه")]
            public Nullable<int> Saturday { get; set; }
            [Display(Name = "یک شنبه")]
            public Nullable<int> Sunday { get; set; }
            [Display(Name = "دو شنبه")]
            public Nullable<int> Monday { get; set; }
            [Display(Name = "سه شنبه")]
            public Nullable<int> Tuesday { get; set; }
            [Display(Name = "چهار شنبه")]
            public Nullable<int> Wednesday { get; set; }
            [Display(Name = "پنج شنبه")]
            public Nullable<int> Thursday { get; set; }
            [Display(Name = "جمعه")]
            public Nullable<int> Friday { get; set; }
            [Display(Name = "اولویت")]
            public Nullable<int> Priority { get; set; }
            [Display(Name = "مجوزهای دسترسی")]

            public virtual ICollection<Right> Rights { get; set; }
            [Display(Name = "نقشهای کاربری")]

            public virtual ICollection<Role> Roles { get; set; }
        }

        public List<Group> ListOfGroup()
        {
            using (AccessEntities myen = new AccessEntities())
            {
                var query = myen.Database.SqlQuery<Group>("select * from [asc].[Group]");
                return query.ToList();
            }
        }

    }
}