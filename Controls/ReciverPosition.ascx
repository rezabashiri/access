<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReciverPosition.ascx.cs" ClassName="AccessManagementService.Controls.RecivePosition"  Inherits="AccessManagementService.Controls.ReciverPosition" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="row">
<asp:Panel ID="pnlDeparments" Direction="RightToLeft" runat="server">
 <telerik:RadTreeView ID="trvChart" AppendDataBoundItems="true" runat="server"></telerik:RadTreeView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Panel>
</div>