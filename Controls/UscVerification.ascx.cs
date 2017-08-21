using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessManagementService.Classes;

namespace AccessManagementService.Controls
{
    public partial class UscVerification : System.Web.UI.UserControl
    {
        string verification;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.css");

            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(UscVerification), "AccessManagementService.Resources.flipclock.js");
          
            //WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(Default), "AccessManagementService.Resources.jquery-3.2.1.min.js");


            if (Session["verificationCode"] != null)
            {
                verification = Session["verificationCode"].ToString();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            signUp _user = new signUp();

           // txtverificationCode.Text = verification;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}