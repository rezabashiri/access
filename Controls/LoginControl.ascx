<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Debug="false" ClassName="AccessManagementService.Controls.Login" Inherits="AccessManagementService.Controls.LoginControl" %>
<link href="<%= new global::tkv.Utility.ResourceHelpers().GetWebResourceUrl(this.Page,typeof(LoginControl),"AccessManagementService.Resources.customStylesheet.css") %>" rel="stylesheet" />

<asp:UpdateProgress id="updateprogress1" associatedupdatepanelid="updatepnl1" runat="server">
    <progresstemplate>
        <div class="col-sm-4"></div>
        <div class="col-sm-8 text-center" style="margin-bottom: 15px">

            <asp:image id="imgload" runat="server" />
        </div>
    </progresstemplate>
</asp:UpdateProgress>

<asp:UpdatePanel runat="server" ID="UpdatePnl1" UpdateMode="Conditional" ValidateRequestMode="Enabled">
    <ContentTemplate>


        <div style="text-align: right; margin-bottom: 15px" class="row">
            <div class="col-sm-12">
                <asp:Label CssClass="form-control" Visible="false" ID="lblMessage" runat="server"></asp:Label>
            </div>

        </div>
        <div class="smart-form client-form right">
            <header>
                ورود به سامانه 
            </header>

            <fieldset>

                <section>
                    <label class="label">نام کاربری</label>
                    <label class="input">
                        <i class="icon-append fa fa-user"></i>
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>نام کاریری یا ایمیل خود را وارد نمائید</b></label>
                </section>

                <section>
                    <label class="label">رمز عبور</label>
                    <label class="input">
                        <i class="icon-append fa fa-lock"></i>
                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>رمز عبور خود را وارد نمائید</b>
                    </label>
                    <div class="note">
                        <a href="#">رمز عبور فراموش کردید؟</a>
                    </div>
                </section>
                <section>
                  <telerik:RadCaptcha ID="captcha" runat="server" CssClass="captcha-imag" CaptchaTextBoxLabel="مقادیر روبرو را تایپ نمایید" ErrorMessage="کد کپچا را به صورت صحیح وارد نمایید" ValidationGroup="aut" ProtectionMode="Captcha">
                        <CaptchaImage FontWarp="High" ImageCssClass="captcha-image" TextChars="LettersAndNumbers" />
                        <TextBoxLabelDecoration />
                    </telerik:RadCaptcha>
                    <%--<cc1:GoogleReCaptcha ID="ctrlGoogleReCaptcha" runat="server" PublicKey="6Lfnly4UAAAAAFdF83pIYOk6HlkDqNAiFa_891IK" PrivateKey="6Lfnly4UAAAAAH_UMAI1TrsS0qdk1TKNet2w2cjd" />--%>
                </section>
                <section>
                    <label class="checkbox">
                        <asp:CheckBox ID="chkRemember" runat="server" />
                        <i></i>مرا به یاد آور</label>
                </section>
            </fieldset>
            <footer>
                <asp:Button ID="btnLogin" Width="100%" OnClick="btnLogin_Click" CssClass="btn btn-primary" ValidateRequestMode="Enabled" CausesValidation="true" ValidationGroup="aut" runat="server" Text="ورود" />
                <div class="col-sm-12 text-center">

                    <%--<a target="_blank" name="سیستم های اطلاعاتی | تلفن های هوشمند | وب سایت | نرم افزارهای اندروید" href="http://moroorgaran.com">شرکت مرورگران نوآوری توسعه  </a>--%>

                </div>
            </footer>
        </div>
       <%-- <h5 class="text-center">ما را دنبال نمایید</h5>

        <ul class="list-inline text-center">
            <li>
                <a href="https://www.instagram.com/moroorgaran/" class="btn btn-primary btn-circle"><i class="fa fa-instagram"></i></a>
            </li>

            <li>
                <a href="https://www.linkedin.com/in/moroorgaran/" class="btn btn-warning btn-circle"><i class="fa fa-linkedin"></i></a>
            </li>
        </ul>--%>

    </ContentTemplate>
</asp:UpdatePanel>
