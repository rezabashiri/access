using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Model;
using tkv.Utility;
using System.Web.Security;
namespace AccessManagementService.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var img = updateprogress1.FindControl("imgLoad") as Image;
            if (img != null)
                img.ImageUrl = new tkv.Utility.ResourceHelpers().GetWebResourceUrl(this.Page, typeof(AccessManagementService.Controls.LoginControl), "AccessManagementService.Resources.loadingAnimation.gif");
        }
        public Button LoginButton
        {
            get
            {
                return btnLogin;
            }
        }
        public string DefaultRedirectPath
        {
            get;
            set;
        }

        public delegate void Logins(User user);
        public event Logins OnLoggedIn;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            lblMessage.Visible = false;

            HashHelpers hash = new HashHelpers();
            User _user = new User();
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string hashpass = hash.Encrypt(password);
            int result = 0;
            string message = string.Empty;

            result = _user.CheckLogin(username, hashpass);
            switch (result)
            {
                case -1:   //user does not exist or his online in another place
                    message = "نام کاربری یا رمزعبور اشتباه است";
                    lblMessage.Text = message;
                    lblMessage.Visible = true;
                    return;
                case 0:
                    message = "اجازه دسترسی وجود ندارد"; ;
                    lblMessage.Visible = true;
                    lblMessage.Text = message;
                    return;

            }
            //result is user id 

            Access.Login newlogin = new Access.Login();
            User _logedin = newlogin.LoginUser(result, username, chkRemember.Checked);
            Access.AccessControl.SetUser(_logedin);
            OnLoggedIn(_logedin);

        }
    }
}