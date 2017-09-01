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
    <%--<script src="js/jquery-3.2.1.min.js"></script>--%>

    <%--    <link rel="stylesheet" href="Resources/flipclock.css" />
<script src="Resources/flipclock.js"></script>--%>

    <%--   <link rel="stylesheet" href="bootstrap.min.css" /> --%>
    <%--<script src="Resources/jquery-1.11.0.js"></script>--%>



    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>


    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

  

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button2" />

        <button id="btnTest">test</button>
        <button id="btnTest2">test2</button>

        <div>

            <%--<uc1:UscControl runat="server" id="UscControl" />--%>
            <%--<uc1:UscOrganization runat="server" ID="UscOrganization" />--%>

            <%--<uc1:LoginControl runat="server" ID="LoginControl" />--%>
            <%--<uc1:UscSignUp runat="server" GroupName="driver" ID="UscSignUp" />--%>

            ' 

            <%--<uc1:UscSignUp runat="server" ID="signupControl" />--%>
            <%--<uc1:UscVerification runat="server" ID="UscSignUp1" />--%>
        </div>
        <%--<asp:TextBox ID="txtRePassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>--%>
        <%--<uc1:LoadMoroorgaranControls ID="load" runat="server" LoadValidationScripts="true"  LoadValidationStyle="true"></uc1:LoadMoroorgaranControls>--%>

        <%--<uc1:MoroorgaranButton ID="MoroorgaranButton1" OnClick="MoroorgaranButton1_Click" runat="server" ValidateionType="validate" Width="100%" ValidationGroup="aut"  CssClass="btn btn-lg   mt-15" Text="ثبت نام" />--%>


        <button class="btn btn-danger btn-lg" id="btnsignup_driver">
            ثبت نام به عنوان راننده 
        </button>

        <button class="btn btn-primary btn-lg" id="btnsignup_advertiser">
            ثبت نام به عنوان تبلیغ دهنده 
        </button>

        <button class="btn btn-warning btn-lg" id="btnlogin">
            ورود به وایرال می 
        </button>


        <div class="modal fade" id="modal_signUp_advertiser" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document" id="modalDrag_advertiser">
                <div class="modal-content persian">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title" style="text-align: right;">
                            <span class="label label-primary">ثبت نام در وایرال می
                            </span>
                        </h2>

                    </div>
                    <div class="modal-body">
                        <div class="box-body">
                            <uc1:UscSignUp runat="server" GroupName="advertiser" ID="UscSignUpAdvertiser" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">بستن</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" id="modal_signUp_driver" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document" id="modalDrag">
                <div class="modal-content persian">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title" style="text-align: right;">
                            <span class="label label-primary">ثبت نام در وایرال می
                            </span>
                        </h2>

                    </div>
                    <div class="modal-body">
                        <div class="box-body">

                            <uc1:UscSignUp runat="server" GroupName="driver" ID="UscSignUpDriver" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">بستن</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" id="modal_login" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document" id="modalDrag2">
                <div class="modal-content persian">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h2 class="modal-title" style="text-align: right;">
                            <span class="label label-primary">ورود به وایرال می
                            </span>
                        </h2>

                    </div>
                    <div class="modal-body">
                        <div class="box-body">

                            <uc1:LoginControl ID="LoginControl" runat="server" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">بستن</button>
                    </div>
                </div>
            </div>
        </div>
    </form>


    <script type="text/javascript">
        $('#btnsignup_advertiser').on('click', function (e) {
            e.preventDefault();
            $("#modal_signUp_advertiser").modal();
        });

        $('#btnsignup_driver').on('click', function (e) {
            e.preventDefault();
            $("#modal_signUp_driver").modal();
        });

        $('#btnlogin').on('click', function (e) {
            e.preventDefault();
            $("#modal_login").modal();
        });

        //$('#btnTest').click(function () {
        //    $('#divTest').show();
        //    $('#divTest').fadeIn();

        //    //$("#divTest").show();
        //    //setTimeout(function () { $("#divTest").hide(); }, 5000);
        //});

        //$('#btnTest2').click(function () {
        //    //$("#divTest").show();
        //    //$('#divTest').fadeIn();
        //    var win = $(window);
        //    var dialog = $('#uscMessage2');
        //    var top = (win.height()) / 2;

        //    dialog.css('top', top - dialog.height());
        //    dialog.addClass('alert-info');
        //    $('#alertstruscMessage').text('salam');

        //    dialog.show();
        //    dialog.delay('slow');
        //    //setTimeout(function () { dialog.hide(); }, 4000);
        //    dialog.fadeOut('slow', 'linear');
        //});

    </script>

</body>
</html>


