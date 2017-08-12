<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReciverPosition.ascx.cs" Inherits="Modiriat_Gharardadha.AccessManagementService.ReciverPosition" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div class="row">
<asp:Panel ID="pnlDeparments" Direction="RightToLeft" runat="server">
 <telerik:RadTreeView ID="trvChart" AppendDataBoundItems="true" runat="server"></telerik:RadTreeView>
    
</asp:Panel>
</div>