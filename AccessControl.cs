using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modiriat_Gharardadha.Model;
using Modiriat_Gharardadha.Helpers;
using System.Data.Entity.Core.Objects;
using System.ComponentModel;
using AccessManagementService.Model;
namespace Modiriat_Gharardadha.AccessManagementService
{
    [Serializable]
    public class AccessControl
    {
        global::AccessManagementService.Access.AccessControl _ac;
        public bool IsValidAccessToEntity(int RoleId, string EntityName, string RelatedService)
        {
            _ac = new global::AccessManagementService.Access.AccessControl();
            return _ac.IsValidAccessToEntity(RoleId, EntityName, RelatedService);

        }
        public static bool IsValidAccessToService(global::AccessManagementService.Access.RightRelatedService Servce)
        {
            string roles = Helpers.SessionHelpers.GetRoles(HttpContext.Current.Session);
            if (string.IsNullOrEmpty(roles))
                return false;
            return global::AccessManagementService.Access.AccessControl.IsValidAccessToService(Servce, roles);
        }
        /// <summary>
        /// check the access of all user's roles , fetch from session 
        /// </summary>
        /// <param name="EntityName"></param>
        /// <param name="RelatedSerice"></param>
        /// <returns></returns>
        public static bool IsValidAccessToRight(string RightName)
        {


            string roles = Helpers.SessionHelpers.GetRoles(HttpContext.Current.Session);
            if (string.IsNullOrEmpty(roles))
                return false;
            return global::AccessManagementService.Access.AccessControl.IsValidAccessToRight(RightName, roles);

        }
        public static void CheckRestrictedAccess(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (!IsValidAccessToEntity_ASC_WF_View(EntityName, WfSearchPage))
            {
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
                HttpContext.Current.Response.End();
            }
        }
        public static bool IsValidAccessToEntity(String EntityName, RightRelatedService ServiceName)
        {

            string roles = Helpers.SessionHelpers.GetRoles(HttpContext.Current.Session);
            if (string.IsNullOrEmpty(roles)) //to avoid check all access and then redirect to login page we check it in frist step
            {
                new global::AccessManagementService.Access.Login().LogOutUser();
                return false;
            }
            else
            {
                return global::AccessManagementService.Access.AccessControl.IsValidAccessToEntity(EntityName, (global::AccessManagementService.Access.RightRelatedService)ServiceName, roles);
            }
        }
        /// <summary>
        /// in menu views we just use Access Authentication , it's just for menus visibilty control
        /// </summary>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static bool IsValidAccessToEntity_View(string EntityName)
        {
            return IsValidAccessToEntity(EntityName, RightRelatedService.View);
        }

        //in edit,insert,delete we check access through workflow and AccessService , because primary users can visit each page with wf engine or direct access

        public static bool IsValidAccessToEntity_ASC_WF_View(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_View(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.View);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_Edit(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_Edit(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.Edit);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_Insert(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_Insert(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.Insert);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_Delete(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_Delete(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.Delete);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_Attach(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_Attach(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.Attach);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_Print(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_Print(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.Print);
            }
            return true;
        }
        public static bool IsValidAccessToEntity_WorkFlow(string EntityName, System.Web.UI.Page WfSearchPage)
        {
            if (WorkFlowHelpers.WorkFlowEngineHelpers.IsValidAccessByWorkFlow_WorkFlow(WfSearchPage) == false)
            {
                return IsValidAccessToEntity(EntityName, RightRelatedService.WorkFlow);
            }
            return true;
        }

        public  List<Department> GetDepartmentOfUser()
        {
            global::AccessManagementService.Model.User User=  Helpers.SessionHelpers.GetUser();
            return new global::AccessManagementService.Model.Department().GetUserDepartments(User.ID);
        }
   
    }
}
