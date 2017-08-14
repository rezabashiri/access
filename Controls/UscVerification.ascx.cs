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
        protected void Page_Load(object sender, EventArgs e)
        {
            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, "AccessManagementService.Resources.calendar.js");
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, "AccessManagementService.Resources.flipTimer.css", false);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            lblMessage.Visible = false;


            signUp _user = new signUp();



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}