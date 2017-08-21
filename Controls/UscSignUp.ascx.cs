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
            string password = txtPassword.Text;
            string hashpass = hash.Encrypt(password);

            string email = txtEmail.Text.Trim();

            var result = _user.UserSignUp(username, hashpass, email);

            if (result != null)
            {
                if (result.Active == false)
                {
                    //go to oher page that show verificatino code

                    Session["verificationCode"] = _user.GenerateRandomNo();

                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#modal_signUp').modal('hide');", true);
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert('hide');", true);

                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#myModal').modal();", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "time", "timer();", true);





                    //System.Web.UI.ScriptManager.RegisterStartupScript(btnSignUp,this.GetType(), "modal", "alert('hide');", true);
                }
                else
                {
                    //go to login page
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}