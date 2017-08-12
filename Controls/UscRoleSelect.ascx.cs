using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Model;
using tkv.Utility;
namespace AccessManagementService.Controls
{
    public partial class UscRoleSelect : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

 
             
        }
        public List<Role> Roles_Get()
        {


            using (var myen = new AccessEntities())
            {
                if (LogedInUser != null)
                {
                    lblUserName.Text = LogedInUser.FullName;
                    return myen.ListRolesOfUser(LogedInUser.ID, true).ToList<Role>();
                }
                return null;
            }
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
                return LogedInUser != null ? LogedInUser.ID : -1;
            }
        }
        public User LogedInUser
        {
            get
            {
                return Access.AccessControl.LoggedInUser;
            }
        
        }
    }
}