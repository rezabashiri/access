﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Classes;
using System.Web.UI.HtmlControls;

namespace AccessManagementService.Controls
{
    public partial class UscVerification : System.Web.UI.UserControl
    {
        public delegate void Verify(AccessManagementService.Access.UserActiveStatus status);
        public event Verify OnVerificationComplete;
        public string ModalId
        {
            get
            {
                return "modal" + this.ClientID;
            }
        }
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
        public string OrganizationRoleName
        {
            get
            {
                if (ViewState["__OrganizationRoleName"] != null)
                {
                    return ViewState["__OrganizationRoleName"].ToString();
                }
                return string.Empty;
            }
            set
            {
                ViewState["__OrganizationRoleName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.css");
            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.js");
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.customStylesheet.css");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(VerficationCode))
            {
                if (txtverificationCode.Text == VerficationCode)
                {
                    signUp su = new Classes.signUp();
                    su.activeUsers(Username, GroupName, OrganizationRoleName);
                    if (OnVerificationComplete != null)
                    {
                        OnVerificationComplete(Access.UserActiveStatus.Active);
                    }

                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert(' با تشکر از ثبت نام شما ');", true);
                    //messageVerifiaction1.ShowMessage(btnOK,"با تشکر از ثبت نام شما", WebUtility.Controls.MessageBox.MessageType.success);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "modal_hide", "$('.modal').modal('hide');", true);
                }
                else
                {
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "alert", "alert('متاسفانه کد ارسالی صحیح نمی باشد. لطفا مجددا تلاش فرمائید');", true);
                    //messageVerifiaction1.ShowMessage(btnOK,"متاسفانه کد ارسالی صحیح نمی باشد. لطفا مجددا تلاش فرمائید", WebUtility.Controls.MessageBox.MessageType.danger);
                    WebUtility.Helpers.RegisterHelpers.RegisterScript(btnOK, "modal_hide", "$('#" + ModalId + "').modal('hide');", true);

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

        //public event Helpers.SMS.SendSms OnSend;

        public event WebUtility.Helpers.SendSMS.SendSms OnSend;

        public void sendSms(string receptorTell, string verificationCode)
        {
            WebUtility.Helpers.VerificationStatus vs;

            WebUtility.Helpers.SendSMS sms = new WebUtility.Helpers.SendSMS("10000400044000", "517A737A6D465A692F3569484E6C53545033426975513D3D");

            vs = sms.SendToANumber(receptorTell, "verify", verificationCode);
            OnSend(vs);
        }
    }
}
