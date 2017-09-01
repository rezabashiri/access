using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Helpers;
using AccessManagementService.Classes;
using System.Web.UI.HtmlControls;

namespace AccessManagementService.Controls
{
    public partial class UscVerification : System.Web.UI.UserControl
    {
        public delegate void Verify(AccessManagementService.Access.UserActiveStatus status);
        public event Verify OnVerificationComplete;
        public string VerficationCode
        {
            get
            {
                if (ViewState["__VerficationCode"] != null)
                {
                    return ViewState["__VerficationCode"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState["__VerficationCode"] = value;
            }
        }

        public string Username
        {
            get
            {
                if (ViewState["__Username"] != null)
                {
                    return ViewState["__Username"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState["__Username"] = value;
            }
        }

        public string GroupName
        {
            get
            {
                if (ViewState["__GroupName"] != null)
                {
                    return ViewState["__GroupName"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState["__GroupName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.css");
            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.js");
            //WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(Default), "AccessManagementService.Resources.jquery-3.2.1.min.js");

            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.customStylesheet.css");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (VerficationCode != null)
            {
                if (txtverificationCode.Text == VerficationCode)
                {
                    signUp su = new Classes.signUp();
                    su.activeUsers(Username, GroupName);


                    if (OnVerificationComplete != null)
                    {
                        OnVerificationComplete(Access.UserActiveStatus.Active);
                    }
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert(' با تشکر از ثبت نام شما ');", true);
                    messageVerifiaction1.ShowMessage(btnOK,"با تشکر از ثبت نام شما", WebUtility.Controls.MessageBox.MessageType.success);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "modal_hide", "$('.modal').modal('hide');", true);
                }
                else
                {
                    //WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert('متاسفانه کد ارسالی صحیح نمی باشد. لطفا مجددا تلاش فرمائید');", true);
                    messageVerifiaction1.ShowMessage(btnOK,"متاسفانه کد ارسالی صحیح نمی باشد. لطفا مجددا تلاش فرمائید", WebUtility.Controls.MessageBox.MessageType.danger);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "modal_hide", "$('.modal').modal('hide');", true);

                    if (OnVerificationComplete != null)
                    {
                        OnVerificationComplete(Access.UserActiveStatus.NotActive);
                    }
                }
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        public event Helpers.SMS.SendSms OnSend;
        public void sendSms(string receptorTell, string verificationCode)
        {
            SMS s = new SMS();

            VerificationStatus vs;

            //if (receptorTell != null && verificationCode != null)
            vs = s.SendToANumber(receptorTell, verificationCode);
            OnSend(vs);
        }
    }
}
