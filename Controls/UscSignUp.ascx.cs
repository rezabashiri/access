using AccessManagementService.Classes;
using AccessManagementService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tkv.Utility;

namespace AccessManagementService.Controls
{
    public partial class UscSignUp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            lblMessage.Visible = false;

            HashHelpers hash = new HashHelpers();
            signUp _user = new signUp();


            string message = string.Empty;

            if (txtPassword.Text != txtRePassword.Text)
            {
                message = "رمز عبورها با هم تطابق ندارند";
                lblMessage.Text = message;
                lblMessage.Visible = true;
                return;
            }

            string username = txtUsername.Text;

            int result = _user.select(username);

            if (result == -2)// user is not exist & can insert into user table
            {
                string password = txtPassword.Text;
                string hashpass = hash.Encrypt(password);

                string email = txtEmail.Text.Trim();

                _user.user_insert(username, hashpass, email);

                //go to oher page that show verificatino code

            }

            if (result == -1) // user is exist but is not confirm verification code
            {
                //go to oher page that show verificatino code
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}