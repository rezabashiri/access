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
        public string GroupName
        {
            get
            {
                return uscVerification.GroupName;
            }
            set
            {
                uscVerification.GroupName = value;
            }
        }


        public event Helpers.SMS.SendSms OnSendVerificationCode;
        public event UscVerification.Verify OnVerificationComplete;
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (uscVerification != null)
            {
                uscVerification.OnSend += UscVerification_OnSend;
                uscVerification.OnVerificationComplete += UscVerification_OnVerificationComplete;
            }
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

            //if (!Page.IsValid)
            //    return;

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

            string roleName = GroupName + "-" + username;

            var result = _user.UserSignUp(username, hashpass, email, roleName);


            if (result != null)
            {
                if (result.Active == false || result.Role_Exist == false)
                {
                    //go to oher page that show verificatino code


                    //if (result.Status == 1 && result.Role_Exist == false)
                    //{
                    //    // user exist and not verification yet
                    //    //MessageBoxSignup1.ShowMessage(btnSignUp, "شما قبلا اقدام به ثبت نام کرده اید ولی هنوز کد  تایید را ارسال ننمودید \n لطفا با اطلاعات قبلی وارد شوید", WebUtility.Controls.MessageBox.MessageType.info);
                    //    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert_exist", "alert('شما قبلا اقدام به ثبت نام کرده اید ولی هنوز کد  تایید را ارسال ننمودید \n لطفا با اطلاعات قبلی وارد شوید');", true);
                    //}

                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#modal_signUp').modal('hide');", true);
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert('salam');", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#" + this.ClientID + " ').modal();", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "time", "timer" + uscVerification.ClientID + "();", true);


                    string verificationCode = "1234";

                    if (new tkv.Utility.WebConfigurationHelper().GetAppSettingValue("SendSMS") == "yes")
                    {
                        // verificationCode = _user.GenerateRandomNo().ToString();
                        //uscVerification.sendSms(username, verificationCode);
                    }

                    uscVerification.VerficationCode = verificationCode;
                    uscVerification.Username = username;

                    //Session["VerficationCode"] = verificationCode;
                    //Session["username"] = username;

                    //string script = @" $('#" + btnSignUp.ClientID + "').on('click', function (evt) {$('form').validationEngine('detach');});";
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "detach", script, true);
                }
                else
                {
                    //go to login page

                    //MessageBoxSignup1.ShowMessage(btnSignUp, "لطفا از قسمت ورود استفاده نمائید. شما قبلا با موفقیت ثبت نام کرده اید ", WebUtility.Controls.MessageBox.MessageType.danger);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert('لطفا از قسمت ورود استفاده نمائید. شما قبلا با موفقیت ثبت نام کرده اید ');", true);
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