using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessManagementService.Controls
{
    public class AccessCheckedHyperLink :System.Web.UI.WebControls.HyperLink
    {
        public string RightName
        {
            get
            {
                return ViewState["RightName"] as string;
            }
            set
            {
                ViewState["RightName"] = value;
            }
        }
        public string EntityName
        {
            get
            {
                return ViewState["EntityName"] as string;
            }
            set
            {
                ViewState["EntityName"] = value;
            }
        }
        public string LinkHref
        {
            get
            {
                return ViewState["LinkHref"] as string;
            }
            set
            {
                ViewState["LinkHref"] = value;
            }
        }
        public string LinkText
        {
            get
            {
                return ViewState["LinkText"] as string;
            }
            set
            {
                ViewState["LinkText"] = value;
            }
        }
        public string Css
        {
            get
            {
                return ViewState["CssClass"] as string;
            }
            set
            {
                ViewState["CssClass"] = value;
            }
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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Visible = ViewCheck();
            this.NavigateUrl = LinkHref;
            this.Text = LinkText;
            this.CssClass = Css;
           
        }
    }
}