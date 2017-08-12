<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="Modiriat_Gharardadha.AccessManagementService.LoginControl" %>

<asp:UpdateProgress ID="UpdateProgress1"  AssociatedUpdatePanelID="UpdatePnl1" runat="server">
    <ProgressTemplate>
             <div class="col-sm-4"></div>
       <div   class="col-sm-8"  style="text-align:right;margin-bottom:15px">
             
           <img src="/Design/Images/loadingAnimation.gif" />
            </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel runat="server" ID="UpdatePnl1">
    <ContentTemplate>
      
        <div class="col-sm-12">
            <div style="text-align:right;margin-bottom:15px" class="row" >
                <asp:Label CssClass="  form-control" Visible="false" ID="lblMessage" runat="server" ></asp:Label>
            </div>
        </div>
   <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-4">
                نام کاربری
            </div>
            <div class="col-sm-8">
                <asp:TextBox ID="txtUserName"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4 ">
                کلمه عبور
            </div>
            <div class="col-sm-8">
                <asp:TextBox ID="txtPassword"   TextMode="Password" CssClass="form-control"  runat="server"></asp:TextBox>
            </div>

        </div>
       <div class="row">
           <div class="col-sm-4">
               مرا به یاد آور
           </div>
           <div class="col-sm-8">
               <asp:CheckBox ID="chkRemember" runat="server" CssClass="form-control" />
           </div>
       </div>
        <div class="row">
                <div class="col-sm-4">
                    </div>
            <div class="col-sm-8 ">
                <asp:Button ID="btnLogin"  Width="100%" OnClick="btnLogin_Click" CssClass="btn btn-primary" runat="server" Text="ورود" />
            </div>
      
        </div>
       </div>
    </ContentTemplate>
</asp:UpdatePanel>