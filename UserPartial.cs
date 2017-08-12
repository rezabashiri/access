using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Modiriat_Gharardadha.Helpers;
using System.Data.Entity;
namespace Modiriat_Gharardadha.Model
{
    [MetadataType(typeof(MetaData))]
    [Helpers.ShowTable(View=true,WitchMenu= Helpers.ShowTable.ShowInMenu.UsersMenu)]
    [System.ComponentModel.DisplayName("کاربران")]
    public partial class User
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name="نام")]
            public string FirstName { get; set; }
            [Display(Name = "نام خانوادگی")]

            public string LastName { get; set; }
            [Display(Name = "نام کاربری")]

            public string UserName { get; set; }
            [Display(Name = "کلمه عبور")]
            [UIHint("Password")]
            public string Password { get; set; }
            [Display(Name = "کلمه عبور جدید")]

            public string NewPassword { get; set; }
            [Display(Name = "فعال؟")]

            public bool IsActive { get; set; }
            [Display(AutoGenerateField=false)]
            public bool IsOnline { get; set; }
            [Display(Name = "تایید شده است")]

            public Nullable<bool> IsConfirm { get; set; }
            [UIHint("PersianDate")]
            [Display(Name = "آخرین زمان ورود")]            
            public Nullable<System.DateTime> LastLoginTime { get; set; }
            [Display(Name = "جنسیت")]
            public Nullable<bool> Gender { get; set; }
            [Display(Name = "متاهل")]

            public Nullable<bool> MarriedStatus { get; set; }
            [Display(Name = "تاریخ تولد")]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> BirthDate { get; set; }
            [Display(AutoGenerateField = false)]

            public Nullable<short> CountryNo { get; set; }
            [Display(AutoGenerateField = false)]

            public Nullable<byte> LanguageNo { get; set; }
            [Display(Name="آدرس")]
            public string Address { get; set; }
            [Display(Name="ایمیل آدرس")]
            public string E_Mail { get; set; }
            [Display(Name = "عکس", AutoGenerateField = false)]
         

            public string PhotoPath { get; set; }

            [Display(Name="تاریخ ساخت")]
            [System.ComponentModel.ReadOnly(true)]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> CreationDate { get; set; }

            [System.ComponentModel.ReadOnly(true)]
            [Display(Name="تاریخ تغییر")]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> EditionDate { get; set; }

            [Display(Name="آخرین زمان تازه سازی")]
            [System.ComponentModel.ReadOnly(true)]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> LastRefreshTime { get; set; }
            [Display(Name = "آخرین زمان تغییر رمز عبور")]
            [System.ComponentModel.ReadOnly(true)]
            [UIHint("PersianDate")]
            public Nullable<System.DateTime> LastChangePassDate { get; set; }
            [Display(AutoGenerateField=false)]
            public string NativeID { get; set; }
            [Display(Name="کد پرسنلی")]
            public string PersonnelID { get; set; }
            [Display(AutoGenerateField = false)]
            public string ActiveSessionID { get; set; }
            [Display(AutoGenerateField = false)]
            public string SystemProfile { get; set; }
            [Display(Name="محل دسترسی")]
            public string IPLocation { get; set; }
            [Display(Name="واحد سازمانی")]
            public int DepartmentID { get; set; }
            [Display(Name="تلفن")]
            public string Phone { get; set; }
            [Display(Name="موبایل")]
            public string Mobile { get; set; }

           
            [Display(Name="نقشهای کاربری")]
            public virtual ICollection<Role> Roles { get; set; }
        }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
        public string GetRolesOfUser(int userid,bool IsActive)
        {
            MPOEntities myen = SessionHelpers.GetContext(HttpContext.Current.Session);
            StoreProcedureHelpers sph=new StoreProcedureHelpers();
            return sph.GetRolesOfUser(myen, userid, IsActive);
             
        }
        public User GetUserById(int userid,string [] includes)
        {

            using (var db = Helpers.SessionHelpers.GetContext(HttpContext.Current.Session))
            {
                var query = db.Users.AsQueryable();

                if (includes != null)
                {
                    foreach (string inc in includes)
                    {
                        query = query.Include(inc);
                    }
                }
                return query.Where(x => x.ID == userid).FirstOrDefault() ?? new User { ID=-1};
            }
        }
        
    }
}