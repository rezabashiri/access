using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessManagementService.Model;
using System.Data.Entity.Core.Objects;
using System.ComponentModel;
using tkv.Utility;
namespace AccessManagementService.Access
{
    [Serializable]
    public class AccessControl
    {
        public  static string UserSesion
        {
            get
            {
                return "00LoggedInUser";
            }
        }
        //used in usercontrol to retireve current user inoes
        public static string UserIdSession
        {
            get
            {
                return "11LoggedInUser";
            }
        }
        public static User LoggedInUser
        {
            get
            {
                User _user = HttpContext.Current.Session[UserSesion] as User;
                if (_user == null)
                {
                    //new Login().RemoveSessions();
                    new User();
                }
                return _user ;
            }
          
        }
        internal static void SetUser(User _user)
        {
            HttpContext.Current.Session[UserSesion] = _user;
            HttpContext.Current.Session[UserIdSession] = _user.ID;
        }
        public bool IsValidAccessToEntity(int RoleId, string EntityName, string RelatedService)
        {
            using (AccessEntities mympo = new AccessEntities())
            {
                int objectresult = mympo.Right_EntityValidRole(RoleId, RelatedService, EntityName).FirstOrDefault().Value;
                int result = objectresult.ToInt32();

                if (result <= 0)
                    return false;
                return true;
            }
        }
        public static bool IsValidAccessToService(AccessManagementService.Access.RightRelatedService Service)
        {
            return IsValidAccessToService(Service, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToService(AccessManagementService.Access.RightRelatedService Service, string UserRoles)
        {
            string ServiceName=Enum.GetName(typeof( AccessManagementService.Access.RightRelatedService),Service);
            string ASCService = string.Format("{0}_Right_{1}", "ASC",ServiceName );
            if (HttpContext.Current.Session[ASCService] != null)
            {
                return (bool)HttpContext.Current.Session[ASCService];
            }
            else
            {
                using (AccessEntities mympo = new AccessEntities())
                {
                    string roles = UserRoles;
                    if (string.IsNullOrEmpty(roles))
                        return false;
                    int result = mympo.Right_ValidByServiceName(roles, ServiceName).FirstOrDefault().Value.ToInt32();

                    HttpContext.Current.Session[ASCService] = result <= 0 ? false : true;

                    return (bool)HttpContext.Current.Session[ASCService];
                }
            }
        }
        public static bool IsValidAccessToRight(string RightName)
        {
            return IsValidAccessToRight(RightName, LoggedInUser.UserRoles);
        }
        /// <summary>
        /// check the access of all user's roles  
        /// </summary>
        /// <param name="EntityName"></param>
        /// <param name="RelatedSerice"></param>
        /// <returns></returns>
        public static bool IsValidAccessToRight(string RightName,string UserRoles)
        {
            string ASCService = string.Format("{0}_Right_{1}", "ASC", RightName);
            if (HttpContext.Current.Session[ASCService] != null)
            {
                return (bool)HttpContext.Current.Session[ASCService];
            }
            else
            {
                using (AccessEntities mympo = new AccessEntities())
                {
                    string roles = UserRoles;
                    if (string.IsNullOrEmpty(roles))
                        return false;
                    int result = mympo.Right_ValidByName(roles, RightName).FirstOrDefault().Value.ToInt32();
                   
                        HttpContext.Current.Session[ASCService] = result <= 0 ? false : true;
                    
                    return (bool)HttpContext.Current.Session[ASCService];
                }
            }
        }
        public static void CheckRestrictedAccess(string EntityName)
        {
            CheckRestrictedAccess(EntityName, LoggedInUser.UserRoles);
        }
        public static void CheckRestrictedAccess(string EntityName,string UserRoles)
        {
            if (!IsValidAccessToEntity_View(EntityName,UserRoles))
            {
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
        }
        public static bool IsValidAccessToEntity(String EntityName, RightRelatedService ServiceName)
        {
            return IsValidAccessToEntity(EntityName, ServiceName, LoggedInUser.UserRoles);
        }
        public static  bool IsValidAccessToEntity(String EntityName, RightRelatedService ServiceName,string UserRoles)
        {

            string ASCService = string.Format("{0}_{1}_{2}","ASC", EntityName, ServiceName.ToString());    //store session value
                Entity entity = new Entity();
                if (HttpContext.Current.Session[ASCService] != null)
                {
                    return (bool)  HttpContext.Current.Session[ASCService] ;
                }
                else
                {
                    string roles = UserRoles;
                    if (string.IsNullOrEmpty(roles))
                        return false;
                    var t = entity.ValidEntity_Right(roles, ServiceName.GetAttributeOfType<DescriptionAttribute>().Description, EntityName);
                    HttpContext.Current.Session[ASCService] = t;
                    return  t;
                }
           
        }
        public static bool IsValidAccessToEntity_View(string EntityName)
        {
            return IsValidAccessToEntity_View(EntityName, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_View(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.View,UserRoles);
        }
        public static bool IsValidAccessToEntity_Edit(string EntityName)
        {
            return IsValidAccessToEntity_Edit(EntityName, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_Edit(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.Edit,UserRoles);
        }

        public static bool IsValidAccessToEntity_Insert(string EntityName)
        {
            return IsValidAccessToEntity_Insert(EntityName);
        }
        public static bool IsValidAccessToEntity_Insert(string EntityName,string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.Insert,UserRoles);
        }
        public static bool IsValidAccessToEntity_Delete(string EntityName)
        {
            return IsValidAccessToEntity_Delete (EntityName,LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_Delete(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.Delete,UserRoles);
        }
        public static bool IsValidAccessToEntity_Attach(string EntityName)
        {
            return IsValidAccessToEntity_Attach(EntityName, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_Attach(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.Attach, UserRoles);
        }
        public static bool IsValidAccessToEntity_Print(string EntityName)
        {
            return IsValidAccessToEntity_Print(EntityName, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_Print(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.Print, UserRoles);
        }
        public static bool IsValidAccessToEntity_WorkFlow(string EntityName)
        {
            return IsValidAccessToEntity_WorkFlow(EntityName, LoggedInUser.UserRoles);
        }
        public static bool IsValidAccessToEntity_WorkFlow(string EntityName, string UserRoles)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.WorkFlow, UserRoles);
        }
    }
}