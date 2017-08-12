<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscRoleSelect.ascx.cs" Inherits="Modiriat_Gharardadha.Controls.UscRoleSelect" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="row text-right">
    <h2>
        انتخاب سمت ارسال کننده
    </h2>
</div>
<div class="row">
    <div class="col-sm-2 Text-left">
     نام کاربر
    </div>
    <div class="col-sm-4 text-right">
        <asp:Label ID="lblUserName" runat="server" ></asp:Label>
    </div>
    <div class="col-sm-2 text-right ">
        نقشهای کاربر
    </div>
    <div class="col-sm-4 text-right">
        <telerik:RadComboBox DataTextField="RoleName" Skin="Web20" DataValueField="ID" SelectMethod="Roles_Get" ID="cmbRoles" runat="server"></telerik:RadComboBox>
      
    </div>
</div>