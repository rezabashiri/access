<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscControl.ascx.cs" ClassName="AccessManagementService.Controls.UserControl"  Inherits="AccessManagementService.Controls.UscControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
 <ef:EntityDataSource ID="GridDataSource" AutoGenerateWhereClause="false" Where="it.ID=@ID"   ConnectionString="name=AccessEntities"  DefaultContainerName="AccessEntities" EntitySetName="Users"  EnableInsert="true" runat="server" EnableDelete="true" EnableUpdate="true">
 <WhereParameters>
     <asp:SessionParameter Name="ID" Type="Int32" SessionField="11LoggedInUser" />
 </WhereParameters>
      
 </ef:EntityDataSource>
 <div dir="rtl">
     <asp:HiddenField OnInit="HiddenField1_Init" ID="HiddenField1" runat="server" />
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                HeaderText="لطفا به اخطار ها توجه فرمایید" CssClass="text-right" Font-Bold="true" />
            <asp:DynamicValidator runat="server" ID="DetailsViewValidator" ControlToValidate="grdUser" Display="None" CssClass="DDValidator" />
    <asp:ScriptManagerProxy runat="server" ID="ScriptManagerProxy1" />
     <dynamic:DynamicRadGrid ID="grdUser" runat="server" DataSourceID="GridDataSource" Skin="Web20" >
            <MasterTableView  AutoGenerateColumns="false"   >
                  <EditFormSettings  EditColumn-InsertText="افزودن" >
                    <EditColumn UpdateText="ویرایش" CancelText="انصراف"></EditColumn>
                </EditFormSettings>
          
                <Columns >

                    <telerik:GridEditCommandColumn CancelText="انصراف" EditText="ویرایش" ButtonType="ImageButton" UpdateText="بروز رسانی" />
                    <telerik:GridButtonColumn CommandName="Delete" Text="حذف" ButtonType="ImageButton" ConfirmTitle="حذف" ConfirmText="آیا از حذف اطمینان دارید؟" />


                </Columns>
            </MasterTableView>
     </dynamic:DynamicRadGrid>
  
     </div>