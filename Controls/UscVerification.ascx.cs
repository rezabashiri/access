using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

            WebUtility.Helpers.RegisterHelpers.RegisterResourceJS(this, typeof(UscVerification), "AccessManagementService.Resources.jqueryflipTimer.js");
    
            WebUtility.Helpers.RegisterHelpers.RegisterCSS(this, typeof(UscVerification), "AccessManagementService.Resources.flipTimer.css");
 
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