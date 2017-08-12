using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Data.Metadata;
namespace AccessManagementService.Controls
{
    public partial class UscOrganization : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //ff.SetMetaTable( AppStart.DynamicDataConfig.GetMetaTable("Departments"));
            var t=AppStart.DynamicDataConfig.GetMetaTable("Departments");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}