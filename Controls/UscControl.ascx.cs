using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
namespace AccessManagementService.Controls
{
    public partial class UscControl : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void frmUser_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                e.Cancel = true;
        }

        protected void HiddenField1_Init(object sender, EventArgs e)
        {
            grdUser.SetMetaTable(AppStart.DynamicDataConfig.GetMetaTable("Users"));
        }
    }
}