using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AccessManagementService.Model;
using System.Web.Security;
namespace AccessManagementService.Access
{
    [Serializable]
    public class Login
    {

        public static bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }
        public static FormsAuthenticationTicket AuthenticationTicket
        {
            get
            {
                return (HttpContext.Current.User.Identity as FormsIdentity).Ticket;
            }
        }
        public  User LoginUser(int UserId,string UserName,bool Persist)
        {

            Entity ent = new Entity();
    
            User user = new User();

            using (var myen = new AccessEntities())
            {
                myen.DoLogin(UserId, tkv.Utility.WebHelpers.UserIPAddress, tkv.Utility.WebHelpers.UserSessionId);
            }
            string roles=user.GetRolesOfUser( UserId,true); 
            user = user.GetUserById(UserId,new [] {"Department","Roles"});
            user.UserRoles = roles;
            

            FormsAuthentication.RedirectFromLoginPage(UserName, Persist);
            return user;
        }

        public void RemoveSessions()
        {
  
                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
                HttpContext.Current.Response.End();
        }
        public void LogOutUser(User user)
        {
            if (user != null)
            {
                user.LogOut(user.ID);
            }
   
        }
        public void LogOutUser()
        {
            User user = AccessControl.LoggedInUser;
            if (user != null)
            {
                user.LogOut(user.ID);
            }
            RemoveSessions();
        }
        public List<Entity> GetAccessableEntities(string UserRoles)
        {
            Entity _entity = new Entity();
            string roles = UserRoles;
          return  _entity.GetEntities_Right(roles, "سرویس مشاهده اسناد");
        }
    
    }
}