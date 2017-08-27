<%@ Control Language="C#" ValidateRequestMode="Enabled" AutoEventWireup="true" CodeBehind="UscSignUp.ascx.cs" Debug="false" ClassName="AccessManagementService.Controls.SignUp" Inherits="AccessManagementService.Controls.UscSignUp" %>
<%@ Register TagPrefix="uc1" Assembly="WebUtilityv2" Namespace="WebUtility.Controls" %>
<%@ Register Src="~/Controls/UscVerification.ascx" TagPrefix="uc1" TagName="UscVerification" %>

<link href="../Resources/customStylesheet.css" rel="stylesheet" />

<%--<uc1:LoadMoroorgaranControls ID="load" runat="server" LoadValidationScripts="true" LoadValidationStyle="true"></uc1:LoadMoroorgaranControls>--%>
<asp:UpdatePanel runat="server" ID="UpdatePnl_signUp" UpdateMode="Always" ValidateRequestMode="Enabled">
    <ContentTemplate>

        <asp:Panel ID="pnlsignUp" Visible="true" runat="server">

            <div style="text-align: right; margin-bottom: 15px" class="row">
                <div class="col-sm-12">
                    <asp:Label CssClass="label label-danger form-control" Visible="false" ID="lblMessage" runat="server"></asp:Label>
                </div>

            </div>
            <div class="smart-form client-form">
                <%--<header>--%>
                <%--ثبت نام در سامانه--%>
                <%--</header>--%>

                <fieldset>

                    <section>
                        <label class="label">تلفن همراه</label>
                        <label class="input">
                            <i class="icon-append fa fa-mobile"></i>
                            <asp:TextBox ID="txtUsername" CssClass="validate[required,custom[phone],minSize[11],maxSize[11]] form-control" runat="server"></asp:TextBox>
                            <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>لطفا تلفن همراه خود را وارد نمائید</b></label>
                    </section>

                    <section>
                        <label class="label">رمز عبور</label>
                        <label class="input">
                            <i class="icon-append fa fa-lock"></i>
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>
                            <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>لطفا رمز عبور خود را وارد نمائید</b>
                        </label>
                    </section>
                    <section>
                        <label class="label">تکرار رمز عبور</label>
                        <label class="input">
                            <i class="icon-append fa fa-lock"></i>
                            <asp:TextBox ID="txtRePassword" TextMode="Password" CssClass="validate[required] form-control" runat="server"></asp:TextBox>
                            <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>لطفا رمز عبور خود را تکرار نمائید</b>
                        </label>
                    </section>

                    <section>
                        <label class="label">ایمیل</label>
                        <label class="input">
                            <i class="icon-append fa fa-user"></i>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>لطفا نام کاربری یا ایمیل خود را وارد نمائید</b></label>
                    </section>

                    <section>
                        <telerik:RadCaptcha CssClass="right" ID="captcha" runat="server" CaptchaTextBoxLabel="مقادیر روبرو را تایپ نمایید" ErrorMessage="کد کپچا را به صورت صحیح وارد نمایید" ValidationGroup="aut" ProtectionMode="Captcha">
                            <CaptchaImage FontWarp="High" ImageCssClass="captcha-image" TextChars="LettersAndNumbers" />
                            <TextBoxLabelDecoration />
                        </telerik:RadCaptcha>
                    </section>
                </fieldset>
                <footer>

                    <%--<uc1:MoroorgaranButton ID="btnSignUp" runat="server" ValidateionType="validate" Width="100%" OnClick="btnSignUp_Click" ValidationGroup="aut" CssClass="btn btn-lg btn-primary mt-15" Text="ثبت نام" />--%>

                    <div class="col-sm-12 text-center">

                        <!--  <a target="_blank" name="سیستم های اطلاعاتی | تلفن های هوشمند | وب سایت | نرم افزارهای اندروید" href="http://moroorgaran.com">شرکت مرورگران نوآوری توسعه  </a>
                     -->
                    </div>
                </footer>
            </div>
            <!-- <h5 class="text-center">ما را دنبال نمایید</h5>

        <ul class="list-inline text-center">
            <li>
                <a href="https://www.instagram.com/moroorgaran/" class="btn btn-primary btn-circle"><i class="fa fa-instagram"></i></a>
            </li>

            <li>
                <a href="https://www.linkedin.com/in/moroorgaran/" class="btn btn-warning btn-circle"><i class="fa fa-linkedin"></i></a>
            </li>
        </ul>
           -->
        </asp:Panel>



        <!-- /.modal -->
    </ContentTemplate>
  <%--  <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSignUp" />
    </Triggers>--%>
</asp:UpdatePanel>



<div class="modal fade" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">

                <h2 class="modal-title" style="text-align: right;">
                    <span class="label label-primary">دریافت کد احراز هویت تلفن همراه</span></h2>
            </div>
            <div class="modal-body">
                <asp:Panel ID="pnlValidation" runat="server">
                    <uc1:UscVerification runat="server" ID="uscVerification" />

                </asp:Panel>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">بستن</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
