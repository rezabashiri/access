using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessManagementService.Model;

namespace AccessManagementService.Classes
{
    public class signUp
    {


        public sp_signup_insert_Result UserSignUp(User user, string roleName)
        {
            using (var db = new AccessEntities())
            {
                try
                {
                    var res = db.sp_signup_insert(user.FirstName, user.LastName, user.UserName, user.Password, user.NewPassword, user.IsActive, user.IsOnline, user.IsConfirm, user.LastLoginTime, user.Gender, user.MarriedStatus, user.BirthDate, user.CountryNo, user.LanguageNo, user.Address, user.E_Mail, user.PhotoPath, user.CreationDate, user.EditionDate, user.LastRefreshTime, user.LastChangePassDate, user.NativeID, user.PersonnelID, user.ActiveSessionID, user.SystemProfile, user.IPLocation, user.DepartmentID, user.Phone, user.Mobile, roleName).FirstOrDefault();
                    return res;
                }
                catch (Exception ex)
                {
                    WebUtility.Helpers.LogHelpers.TakeALogWithTime(ex.Message);
                    return new sp_signup_insert_Result();
                }

            }
        }
        public sp_signup_insert_Result UserSignUp(string username, string pass, string email, string roleName)
        {
            User u = new User();
            u.UserName = username;
            u.Password = pass;
            u.E_Mail = email;
            u.IsActive = false;
            u.IsOnline = false;
            u.IPLocation = tkv.Utility.WebHelpers.UserIPAddress;

            return UserSignUp(u, roleName);
        }


        public void activeUsers(string userName, string groupName)
        {
            string roleName = groupName + "-" + userName;
            activeUsers(userName, groupName, groupName, roleName);
        }
        public void activeUsers(string userName, string groupName, string orgRoleName)
        {
            if (string.IsNullOrEmpty(orgRoleName))
            {
                activeUsers(userName, groupName);
            }
            else
            {
                string roleName = groupName + "-" + userName;
                activeUsers(userName, groupName, orgRoleName, roleName);
            }
        }
        public void activeUsers(string userName, string groupName, string orgRoleName, string roleName)
        {
            using (var db = new AccessEntities())
            {
                try
                {
                    db.SpActiveUserByUserName(userName, true, true, groupName, orgRoleName, roleName);
                }
                catch (Exception ex)
                {
                    WebUtility.Helpers.LogHelpers.TakeALogWithTime(ex.Message);
                }
            }
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}