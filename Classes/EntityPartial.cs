using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AccessManagementService.Model;
using tkv.Utility;
namespace AccessManagementService.Model
{
    [MetadataType(typeof(MetaData))]
    [System.ComponentModel.DisplayName("موجودیت ها")]
    
    [System.ComponentModel.DataAnnotations.DisplayColumn("EntityFarsiName")]
    public partial class Entity
    {
        private class MetaData
        {
            public int ID { get; set; }
            [Display(Name="آدرس مجازی")]
            public string VirtualAddress { get; set; }
            [Display(Name="نام موجودیت")]
            public string EntityName { get; set; }
            [Display(Name="نام فارسی موجودیت")]
            public string EntityFarsiName { get; set; }
            [Display(Name="نوع موجودیت")]
            public Nullable<int> EntityType { get; set; }
            [Display(Name = "عنوان نمایش منو")]
            public string MenuDisplayTitle { get; set; }
         
            [Display(AutoGenerateField=false)]
            public virtual ICollection<Right> Rights { get; set; }
        }
        public  List<Entity> GetEntities_Right(int RoleId, string ServiceName)
        {
            using (var myen = new AccessEntities())
            {
               
                List<Entity> getright = myen.Right_EntityGet(RoleId, ServiceName).ToList<Entity>();
                return getright;
            }
        }
        public  List<Entity> GetEntities_Right(string  roles, string ServiceName)
        {
            List<Entity> list = new List<Entity>();
            string[] separated = roles.Split(',');
            foreach (string role in separated)
            {
                List<Entity> nlist = new List<Entity>();
                nlist = GetEntities_Right(role.ToInt32(), ServiceName);
                list.AddRange(nlist);
            }
            return list.Distinct().ToList<Entity>();
        }
        public bool ValidEntity_Right(string roles, string ServiceName, string EntityName)
        {
            using (var myen = new AccessEntities())
            {
                int result = myen.Right_EntityValidRoles(roles, ServiceName, EntityName).FirstOrDefault().Value;
                return result == 1 ? true : false;
            }
        }
    }
}