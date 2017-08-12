using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace AccessManagementService.Access
{

  
    [Serializable]
    public enum RightRelatedService
    {
        [Description("سرویس مشاهده اسناد")]
        View,
        [Description("سرویس افزودن به اسناد")]
        Insert,
        [Description("سرویس ویرایش اسناد")]
        Edit,
        [Description("سرویس حذف اسناد")]
        Delete,
        [Description("سرویس پیوست اسناد")]
        Attach,
        [Description("سرویس چاپ اسناد")]
        Print,
        [Description("اجرای گردش")]
        WorkFlow,
        [Description("سرویس تشخیص هویت")]
        Authenticate,
        [Description("سرویس چارت سازمانی")]
        Chart,
        [Description("سرویس جستجو اسناد")]
        Search
    }
}