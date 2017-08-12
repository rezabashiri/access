using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modiriat_Gharardadha.Helpers;
using Modiriat_Gharardadha.Model;
using System.Web.Security;
namespace Modiriat_Gharardadha.AccessManagementService
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
        public  void LoginUser(int UserId,string UserName,bool Persist)
        {
            Entity ent = new Entity();
            MPOEntities myen=SessionHelpers.GetContext(HttpContext.Current.Session);
            User user = new User();
          //  myen.DoLogin(UserId, TCPIPHelpers.UserIPAddress, TCPIPHelpers.UserSessionId);
            string roles=user.GetRolesOfUser( UserId,true);
            user = user.GetUserById(UserId,new [] {"Department"});
            
            SetSessions(roles,user);

            FormsAuthentication.RedirectFromLoginPage(UserName, Persist);
            
        }
        public void LogOutUser()
        {
            using (var myen = SessionHelpers.GetContext(HttpContext.Current.Session))
            {
                User user=Helpers.SessionHelpers.GetUser(HttpContext.Current.Session);
                if (user != null)
                {
                    myen.DoLogout(user.ID);
                    HttpContext.Current.Session.RemoveAll();
                   
                }
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        public List<Entity> GetAccessableEntities()
        {
            Entity _entity = new Entity();
            string roles = SessionHelpers.GetRoles(HttpContext.Current.Session);
          return  _entity.GetEntities_Right(roles, "سرویس مشاهده اسناد");
        }
        private void SetSessions(string roles,User user)
        {
            SessionHelpers.SetUser(HttpContext.Current.Session, user);
            SessionHelpers.SetRoeles(HttpContext.Current.Session,roles);
          
        }
    }
}