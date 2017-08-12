using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modiriat_Gharardadha.Model;
using Modiriat_Gharardadha.Helpers;
namespace Modiriat_Gharardadha.Controls
{
    public partial class UscRoleSelect : System.Web.UI.UserControl
    {
        MPOEntities myen;
        protected void Page_Load(object sender, EventArgs e)
        {


            global::AccessManagementService.Model.User user = Helpers.SessionHelpers.GetUser(HttpContext.Current.Session);
                lblUserName.Text = user != null ? user.FullName : string.Empty;
             
        }
        public List<Role> Roles_Get()
        {
            global::AccessManagementService.Model.User user = SessionHelpers.GetUser(HttpContext.Current.Session);
            if (user == null)
                return null;
            int userid = user.ID;
            myen = SessionHelpers.GetContext(HttpContext.Current.Session);
            return myen.ListRolesOfUser(userid, true).ToList<Role>(); 
        }
        public int RoleId
        {
            get
            {
                if (!string.IsNullOrEmpty( cmbRoles.SelectedValue))
                {
                    return cmbRoles.SelectedValue.ToInt32();
                }
                return -1;
            }
        }
        public int UserId
        {
            get
            {
                if (Helpers.SessionHelpers.GetUser(HttpContext.Current.Session) == null)
                    return -1;
                return Helpers.SessionHelpers.GetUser(HttpContext.Current.Session).ID;
            }
        }
    }
}