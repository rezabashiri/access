using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Helpers;
using AccessManagementService.Classes;

namespace AccessManagementService.Controls
{
    public partial class UscVerification : System.Web.UI.UserControl
    {
        public delegate void Verify(AccessManagementService.Access.UserActiveStatus status);
        public event Verify OnVerificationComplete;
        public string VerficationCode
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.css");
            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.js");

            //WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(Default), "AccessManagementService.Resources.jquery-3.2.1.min.js");


            if (Session["VerficationCode"] != null)
            {
                VerficationCode = Session["VerficationCode"].ToString();
            }

            if (Session["username"] != null)
            {
                Username = Session["username"].ToString();
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (VerficationCode != null)
            {
                if (txtverificationCode.Text == VerficationCode)
                {
                    signUp su = new Classes.signUp();
                    su.activeUsers(Username);


                    if (OnVerificationComplete != null)
                    {
                        OnVerificationComplete(Access.UserActiveStatus.Active);
                    }
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert(' با تشکر از ثبت نام شما ');", true);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "modal_hide", "$('.modal').modal('hide');", true);
                }
                else
                {
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert('متاسفانه کد ارسالی صحیح نمی باشد. لطفا مجددا تلاش فرمائید');", true);
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