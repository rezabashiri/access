<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccessManagementService.Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="uc1" Assembly="WebUtilityv2" Namespace="WebUtility.Controls" %>
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

    <%--    <link rel="stylesheet" href="Resources/flipclock.css" />
<script src="Resources/flipclock.js"></script>--%>

    <%--   <link rel="stylesheet" href="bootstrap.min.css" />
    <%--<script src="Resources/jquery-1.11.0.js"></script>
    --%>


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>

            <%--<uc1:UscControl runat="server" id="UscControl" />--%>
            <%--<uc1:UscOrganization runat="server" ID="UscOrganization" />--%>
            <%--<uc1:LoginControl runat="server" ID="LoginControl" />--%> 

            <%--<uc1:UscSignUp runat="server" ID="signupControl" />--%>
            <%--<uc1:UscVerification runat="server" ID="UscSignUp1" />--%>
        </div>
        <%--<asp:TextBox ID="txtRePassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>--%>
        <%--<uc1:LoadMoroorgaranControls ID="load" runat="server" LoadValidationScripts="true"  LoadValidationStyle="true"></uc1:LoadMoroorgaranControls>--%>

        <%--<uc1:MoroorgaranButton ID="MoroorgaranButton1" OnClick="MoroorgaranButton1_Click" runat="server" ValidateionType="validate" Width="100%" ValidationGroup="aut"  CssClass="btn btn-lg   mt-15" Text="ثبت نام" />--%>

        <%--<uc1:UscSignUp runat="server" ID="UscSignUp" />--%>


        <button class="btn btn-primary btn-lg" id="btnsignup">
            ثبت نام 
        </button>



        <div class="modal fade" id="modal_signUp" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document" id="modalDrag">
                <div class="modal-content persian">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title" style="text-align: right;">
                            <span class="label label-primary">ثبت نام در سامانه
                            </span>
                        </h2>

                    </div>
                    <div class="modal-body">
                        <div class="box-body">
                            <uc1:UscSignUp runat="server" ID="UscSignUp" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">بستن</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.modal -->
        <script type="text/javascript">
            $('#btnsignup').on('click', function (e) {
                e.preventDefault();
                $("#modal_signUp").modal();
            });

        </script>


    </form>

</body>
</html>


