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
            uscMessage.ShowMessage("ssssB", WebUtility.Controls.MessageBox.MessageType.info);

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

        protected static string ReCaptcha_Key = "6Lfnly4UAAAAAFdF83pIYOk6HlkDqNAiFa_891IK";
        protected static string ReCaptcha_Secret = "6Lfnly4UAAAAAH_UMAI1TrsS0qdk1TKNet2w2cjd";

        [WebMethod]
        public static string VerifyCaptcha(string response)
        {
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + ReCaptcha_Secret + "&response=" + response;
            return (new WebClient()).DownloadString(url);
        }
    }
}