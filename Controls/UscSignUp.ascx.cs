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
        public event Helpers.SMS.SendSms OnSendVerificationCode;
        public event UscVerification.Verify OnVerificationComplete;
        protected void Page_Load(object sender, EventArgs e)
        {
            uscVerification.OnSend += UscVerification_OnSend;
            uscVerification.OnVerificationComplete += UscVerification_OnVerificationComplete;
            
        }

        private void UscVerification_OnVerificationComplete(Access.UserActiveStatus status)
        {
             if (OnVerificationComplete != null)
            {
                OnVerificationComplete(status);
            }
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
            else
            {
                lblMessage.Visible = false;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string hashpass = hash.Encrypt(password);

            string email = txtEmail.Text.Trim();

            var result = _user.UserSignUp(username, hashpass, email);

            if (result != null)
            {
                if (result.Active == false)
                {
                    //go to oher page that show verificatino code



                    //Session["verificationCode"] = _user.GenerateRandomNo();

                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#modal_signUp').modal('hide');", true);
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert('hide');", true);

                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#myModal').modal();", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "time", "timer();", true);


                    //string verificationCode  = _user.GenerateRandomNo().ToString();
                    string verificationCode = "1234";

                    Session["VerficationCode"] = verificationCode;
                    Session["username"] = username;        

                    //string script = @" $('#" + btnSignUp.ClientID + "').on('click', function (evt) {$('form').validationEngine('detach');});";
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "detach", script, true);
                }
                else
                {
                    //go to login page

                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert(' شما قبلا با موفقیت ثبت نام کرده اید ');", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal_hide", "$('.modal').modal('hide');", true);
                }
            }
        }
        private void UscVerification_OnSend(Helpers.VerificationStatus Status)
        {
            if (OnSendVerificationCode != null)
                OnSendVerificationCode(Status);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}