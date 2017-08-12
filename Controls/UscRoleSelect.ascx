<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscRoleSelect.ascx.cs" ClassName="AccessManagementService.Controls.RoleSelect"  Inherits="AccessManagementService.Controls.UscRoleSelect" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="row">
    <div class="col-md-2 col-sm-6  text-left">
     نام کاربر
    </div>
    <div class="col-md-2 col-sm-6 text-right">
        <asp:Label ID="lblUserName" runat="server" ></asp:Label>
    </div>
    <div class="col-md-2 col-sm-6  text-left ">
        نقشهای کاربر
    </div>
    <div class="col-md-3 col-sm-6 text-right">
        <telerik:RadComboBox DataTextField="RoleName" Skin="Web20" DataValueField="ID" SelectMethod="Roles_Get" ID="cmbRoles" runat="server"></telerik:RadComboBox>
        
    </div>
</div>