using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using AccessManagementService.Model;
using tkv.Utility;
namespace AccessManagementService.Controls
{
    public partial class ReciverPosition : System.Web.UI.UserControl
    {
        public User LogedInUser
        {
            get;
            set;
        }
        public int? UserId
        {
            set;
            get;
        }
        private User GetUser()
        {
            if (LogedInUser != null)
                return LogedInUser;
            else if (UserId != null)
            {
                User _user = new User();
                return _user.GetUserById(UserId ?? -1, new [] {"Department"});
            }
            else
                return null;
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            User user = GetUser();
            if (user == null || user.Department == null)
                return;
            Department department = new Department();
            XmlHelper xmlhelper=new XmlHelper();
            trvChart.LoadXml(user.Department.DeparetmentChartXML);
            foreach (var dep in department.GetDepartments(null))
            {

                Panel container = new Panel();
               
                if (dep.ID == user.DepartmentID)
                {

                    continue;
                }
                else
                {
                    if (string.IsNullOrEmpty(dep.DeparetmentChartXML))
                        continue;
                    var xml = xmlhelper.GetElementsByString(dep.DeparetmentChartXML, "Node");
                    if (xml != null && xml.Count > 0)
                    {
                        var rootNode = xml[0];
                        string OrganizationRoleId = rootNode.Attribute("OrganizationRoleId").Value;
                        string name = rootNode.Attribute("Text").Value;
                        IRadTreeNodeContainer target = trvChart;
                        RadTreeNode addedNode = new RadTreeNode(name);
                        //if (trvChart.SelectedNode != null)
                        //{
                        //    trvChart.SelectedNode.Expanded = true;
                        //    target = trvChart.SelectedNode;
                        //}
                        addedNode.Attributes.Add("OrganizationRoleId", OrganizationRoleId);
                  
                        target.Nodes.Add(addedNode);
                    }
                }

                             
                
              
                
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
             
          
            
        }
    }
}