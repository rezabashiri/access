using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Modiriat_Gharardadha.Model
{
    [System.ComponentModel.DisplayName("واحدهای مستقل")]
    [Helpers.ShowTable(View=true,WitchMenu= Helpers.ShowTable.ShowInMenu.UsersMenu)]
    [MetadataType(typeof(MetaData))]

    public partial class Department
    {
        private class MetaData
        {
        public int ID { get; set; }
            [Display(Name="نام واحد")]
        public string DepartmentName { get; set; }
            [Display(Name = "تلفن/تلفنها")]
        public byte[] Phones { get; set; }
            [Display(Name = "فکس/فکسها")]
        public byte[] Faxes { get; set; }
            [Display(Name = "آدرس")]            
           [UIHint("LongText")]
        public string Adress { get; set; }
            [Display(Name="پست الکترونیک")]

            [RegularExpression(@"([a-zA-Z0-9_\.])+@([a-zA-Z0-9_\.])+\.((com|ir|org|net))+", ErrorMessage = "آدرس ایمیل معتبر نمیباشد")]
        public string EmailAdress { get; set; }
            [UIHint("DepartmentChart")]
            [Display(Name="چارت واحد")]
        public string DeparetmentChartXML { get; set; }
            [Display(Name="لوگو")]
        public string LogoPath { get; set; }
            [Display(AutoGenerateField=false)]
        public Nullable<bool> IsNeerdToConfirm { get; set; }
            [Display(Name="آیا پسورد باید عوض شود")]
        public Nullable<bool> IsNeedConfirmToChangePassword { get; set; }
            [Display(Name="آیا در چارت سازمانی نمایش داده شود؟")]
            public Nullable<bool> IsVisible { get; set; }

            [Display(AutoGenerateField = false)]    
        public virtual ICollection<OrganiztionRole> OrganiztionRoles { get; set; }
            [Display(AutoGenerateField = false)]    

            public virtual ICollection<Role> Roles { get; set; }
            [Display(AutoGenerateField = false)]    

            public virtual ICollection<User> Users { get; set; }
        }
        public List<Department> GetDepartments(string []includes)
        {
            using (var context = Helpers.SessionHelpers.GetContext(HttpContext.Current.Session))
            {
                IQueryable<Department> department = context.Departments.AsQueryable();
                if (includes != null)
                {
                    foreach (string inc in includes)
                    {
                        department = department.Include(inc);
                        
                    }
                }
                return department.Where(x => x.IsVisible == true).ToList();
            }
        }
    }
}