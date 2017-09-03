using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccessManagementService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //UscSignUp.OnSendVerificationCode += UscSignUp_OnSendVerificationCode;
            //UscSignUp.OnVerificationComplete += UscSignUp_OnVerificationComplete;
        }

        private void UscSignUp_OnVerificationComplete(AccessManagementService.Access.UserActiveStatus status)
        {
            switch (status)
            {
                case Access.UserActiveStatus.Active:
                    // Server.TransferRequest("~/Controls/LoginControl.ascx");
                    break;
                case Access.UserActiveStatus.NotActive:
                    break;

            }
        }

        private void UscSignUp_OnSendVerificationCode(AccessManagementService.Helpers.VerificationStatus Status)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          //  MessageBox1.ShowMessage("ssssB", WebUtility.Controls.MessageBox.MessageType.info);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          //  uscMessage3.ShowMessage("ssssB3", WebUtility.Controls.MessageBox.MessageType.danger);

        }
    }
}