using Kavenegar.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessManagementService.Helpers
{
    public struct VerificationStatus
    {
        public string Message
        {
            get; set;
        }
        public string StatusCode
        {
            get; set;
        }
        public long MessageID
        {
            get; set;
        }
        public bool IsDelivered
        {
            get; set;
        }

    }
    public class SMS
    {
        public delegate void SendSms(VerificationStatus Status);

        private string apikey = "517A737A6D465A692F3569484E6C53545033426975513D3D";

        public string ApiKey
        {
            get
            {
                if (HttpContext.Current.Session["__APIKEY"] != null)
                    return HttpContext.Current.Session["__APIKEY"] as string;
                else
                    return apikey;
            }
            set
            {
                HttpContext.Current.Session["__APIKEY"] = value;
            }
        }
        const String SenderLine = "10000400044000";

        public VerificationStatus SendToANumber(string receptor, string code)
        {
            string text = string.Format("خوش آمدید:جهت تکمیل فرآیند،کد {0} را وارد نمائید", code);

            VerificationStatus sm = new Helpers.VerificationStatus();

            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(ApiKey);

                var result = api.Send(SenderLine, receptor, text);

                if (result.Status != 200)
                {
                    WebUtility.Helpers.LogHelpers.TakeALogWithTime(String.Format("Returned [{0}] Message:[{1}]", result.Status, result.StatusText));
                }


                var smsStatus = api.Status(result.Messageid.ToString());

                if (smsStatus.Status == Kavenegar.Models.Enums.MessageStatus.Delivered)
                {
                    sm.IsDelivered = true;
                }

                sm.StatusCode = smsStatus.Status.ToString();
                sm.Message = smsStatus.Statustext;
                sm.MessageID = smsStatus.Messageid;


                WebUtility.Helpers.LogHelpers.TakeALogWithTime(smsStatus.Statustext);
                return sm;
            }

            catch (ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                WebUtility.Helpers.LogHelpers.TakeALogWithTime(ex.Message);

                sm.Message = ex.Message;
                sm.StatusCode = "-1";

                return sm;
            }
            catch (Kavenegar.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                WebUtility.Helpers.LogHelpers.TakeALogWithTime(ex.Message);

                sm.Message = ex.Message;
                sm.StatusCode = "-1";

                return sm;
            }
        }
    }
}