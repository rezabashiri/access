<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccessManagementService.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/Controls/ReciverPosition.ascx" TagPrefix="uc1" TagName="ReciverPosition" %>
<%@ Register Src="~/Controls/LoginControl.ascx" TagPrefix="uc1" TagName="LoginControl" %>
<%@ Register Src="~/Controls/UscControl.ascx" TagPrefix="uc1" TagName="UscControl" %>
<%@ Register Src="~/Controls/UscSignUp.ascx" TagPrefix="uc1" TagName="UscSignUp" %>
<%@ Register Src="~/Controls/UscVerification.ascx" TagPrefix="uc1" TagName="UscVerification" %>


<%--<%@ Register Src="~/Controls/UscOrganization.ascx" TagPrefix="uc1" TagName="UscOrganization" %>--%>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-3.2.1.min.js"></script>
   
 
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>

            <%--<uc1:UscControl runat="server" id="UscControl" />--%>
            <%--<uc1:UscOrganization runat="server" ID="UscOrganization" />--%>
            <%--<uc1:LoginControl runat="server" ID="LoginControl" />--%>
            <%--<uc1:UscSignUp runat="server" ID="signupControl" />--%>
            <uc1:UscVerification runat="server" ID="UscSignUp1" />

            <asp:HyperLink ID="hpr" runat="server">test</asp:HyperLink>
        </div>
    </form>
</body>
</html>
