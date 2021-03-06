﻿using AccessManagementService.Classes;
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

        public List<Group> Group_Get()
        {
            if (ISLoadGroup)
            {
                AccessManagementService.Model.Group g = new Model.Group();
                return g.ListOfGroup();
            }
            return null;
        }
        private int GroupId
        {
            get
            {
                if (!string.IsNullOrEmpty(cmbRoleGroup.SelectedValue))
                {
                    return cmbRoleGroup.SelectedValue.ToInt32();
                }
                return -1;
            }
        }


        public bool ISLoadGroup
        {
            get; set;
        }

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
        public string OrganizationRole
        {
            get
            {
                return uscVerification.OrganizationRoleName;
            }
            set
            {
                uscVerification.OrganizationRoleName = value;
            }
        }

        public event WebUtility.Helpers.SendSMS.SendSms OnSendVerificationCode;
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
            if (ISLoadGroup == false)
            {
                SectionRoleGroup.Visible = false;
            }
            else
            {
                SectionRoleGroup.Visible = true;
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
            if (!captcha.IsValid)
                return;

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

            if (!string.IsNullOrEmpty(cmbRoleGroup.SelectedValue))
            {
                GroupName = cmbRoleGroup.Text.ToString();
            }

            string email = txtEmail.Text.Trim();

            string roleName = GroupName + "-" + username;

            var result = _user.UserSignUp(username, hashpass, email, roleName);


            if (result != null)
            {
                if (result.Active == false || result.Status == 2)
                {
                    //go to oher page that show verificatino code
                    //role exists and user exists but user not active
                    if (result.Status == 1)
                    {
                        // user exist and not verification yet
                        //MessageBoxSignup1.ShowMessage(btnSignUp, "شما قبلا اقدام به ثبت نام کرده اید ولی هنوز کد  تایید را ارسال ننمودید \n لطفا با اطلاعات قبلی وارد شوید", WebUtility.Controls.MessageBox.MessageType.info);
                        WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert_exist", "alert('شما قبلا اقدام به ثبت نام کرده اید ولی هنوز کد  تایید را ارسال ننمودید \n لطفا با اطلاعات قبلی وارد شوید');", true);
                    }

                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#modal_signUp').modal('hide');", true);
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "alert", "alert('salam');", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "modal", "$('#modal" + uscVerification.ModalId + " ').modal();", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnSignUp, "time", "timer" + uscVerification.ClientID + "();", true);


                    string verificationCode = "1234";

                    if (new tkv.Utility.WebConfigurationHelper().GetAppSettingValue("SendSMS") == "yes")
                    {
                        verificationCode = _user.GenerateRandomNo().ToString();
                        uscVerification.sendSms(username, verificationCode);
                    }

                    uscVerification.VerficationCode = verificationCode;
                    uscVerification.Username = username;
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
        private void UscVerification_OnSend(WebUtility.Helpers.VerificationStatus Status)
        {
            if (OnSendVerificationCode != null)
                OnSendVerificationCode(Status);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}