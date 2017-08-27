<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscVerification.ascx.cs" Debug="false" ClassName="AccessManagementService.Controls.Verification" Inherits="AccessManagementService.Controls.UscVerification" %>
<%@ Register TagPrefix="uc1" Assembly="WebUtilityv2" Namespace="WebUtility.Controls" %>

  <%--<link href="../Resources/customStylesheet.css" rel="stylesheet" />--%>

 
<div>
    <header>
        <%--دریافت کد احراز هویت تلفن همراه--%>
    </header>
</div>

<section>

 	<div class="clock" style="margin:2px 0px 21px 134px;"></div>
	<div class="message label label-danger" style="direction:rtl;float:right;"></div>
</section>


<asp:UpdatePanel runat="server" ID="UpdatePnl1" UpdateMode="Conditional">
    <ContentTemplate>


        <div class="smart-form client-form">


            <fieldset>

                <section>
                    <label class="label">کد احراز هویت</label>
                    <label class="input">
                        <i class="icon-append fa fa-mobile"></i>
                        <asp:TextBox ID="txtverificationCode" CssClass="validate[required,minSize[4],maxSize[4]] form-control" runat="server"></asp:TextBox>
                        <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>لطفا کد احراز هویت خود را وارد نمائید</b></label>
                </section>


            </fieldset>
            <footer>

                <uc1:MoroorgaranButton ID="btnOK" runat="server" ValidateionType="cancel" Width="100%" OnClick="btnOK_Click" CssClass="btn btn-lg btn-warning mt-15" Text="تایید هویت" />

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

    </ContentTemplate>

</asp:UpdatePanel>

 <script type="text/javascript">

     //window.onload = timer();
     function timer()
     {
         var clock;

         $('[class*="validate"]').each(function () {
             var _this = $(this);
             _this.attr("class", _this.attr("class").replace(/validate\[.*]+\s?/, ""));
         });
        //$('form').validationEngine('attach', { autoHidePrompt: true, promptPosition: 'topRight', onFailure: function () { alert('f')} });
         //$(document).ready(function () {
         var clock;

         clock = $('.clock').FlipClock({
             clockFace: 'MinuteCounter',
             autoStart: false,
             callbacks: {
                 stop: function () {
                     $('.message').text('زمان شما به پایان رسید. لطفا مجددا تلاش نمائید.')
                     $('#<%= btnOK.ClientID %>').prop("disabled", true);
                 }
             }
         });

         clock.setTime(180);
         clock.setCountdown(true);
         clock.start();
     }
    //}); 
</script>
