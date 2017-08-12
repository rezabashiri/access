using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccessManagementService.Controls
{
    public partial class UscMenuLink : System.Web.UI.UserControl
    {
        public string RightName
        {
            get;
            set;
        }
        public string EntityName
        {
            get;
            set;
        }
        public string LinkHref
        {
            get;
            set;
        }
        public string LinkText
        {
            get;
            set;
        }
        public bool ViewCheck()
        {
            if (!string.IsNullOrEmpty(EntityName))
            {
                return Access.AccessControl.IsValidAccessToEntity_View(EntityName);
            }
            else if (!string.IsNullOrEmpty(RightName))
            {
                return Access.AccessControl.IsValidAccessToRight(RightName);
            }
            else
                return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}