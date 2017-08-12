using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modiriat_Gharardadha.Model;
using Modiriat_Gharardadha.Helpers;
using System.Web.Security;
namespace Modiriat_Gharardadha.AccessManagementService
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string DefaultRedirectPath
        {
            get;
            set;
        }
        public delegate void LoginStatus(int status);
        public event LoginStatus OnLogging;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            MPOEntities myen = Helpers.SessionHelpers.GetContext(Session);
            HashHelpers hash = new HashHelpers();
            StoreProcedureHelpers sph = new StoreProcedureHelpers();
            string username=txtUserName.Text;
            string password=txtPassword.Text;
            string hashpass = hash.Encrypt(password);
            int result = 0;
            string message = string.Empty;

            result = sph.CheckLogin(myen, username, hashpass);
            switch (result)
            {
                case -1:   //user does not exist or his online in another place
                    message = "نام کاربری یا رمزعبور اشتباه است";
                    lblMessage.Text = message;
                    lblMessage.Visible = true;
                    return;
                case 0:
                    message = "اجازه دسترسی وجود ندارد";;
                    lblMessage.Visible = true;
                    lblMessage.Text = message;
                    return;

            }
            //result is user id 

            AccessManagementService.Login newlogin = new AccessManagementService.Login();
            newlogin.LoginUser(result,username,chkRemember.Checked);
                 
        }
    }
}