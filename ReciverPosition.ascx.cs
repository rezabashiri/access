using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Modiriat_Gharardadha.Model;
using tkv.Utility;
namespace Modiriat_Gharardadha.AccessManagementService
{
    public partial class ReciverPosition : System.Web.UI.UserControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
             global::AccessManagementService.Model.User user = Helpers.SessionHelpers.GetUser(HttpContext.Current.Session);
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