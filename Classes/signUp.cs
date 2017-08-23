using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessManagementService.Model;

namespace AccessManagementService.Classes
{
    public class signUp
    {
        AccessEntities DB = new AccessEntities();

        public sp_signup_insert_Result UserSignUp(User user)
        {
            var res = DB.sp_signup_insert(user.FirstName, user.LastName, user.UserName, user.Password, user.NewPassword, user.IsActive, user.IsOnline, user.IsConfirm, user.LastLoginTime, user.Gender, user.MarriedStatus, user.BirthDate, user.CountryNo, user.LanguageNo, user.Address, user.E_Mail, user.PhotoPath, user.CreationDate, user.EditionDate, user.LastRefreshTime, user.LastChangePassDate, user.NativeID, user.PersonnelID, user.ActiveSessionID, user.SystemProfile, user.IPLocation, user.DepartmentID, user.Phone, user.Mobile).FirstOrDefault();

            return res;
        }
        public sp_signup_insert_Result UserSignUp(string username, string pass, string email)
        {
            User u = new User();
            u.UserName = username;
            u.Password = pass;
            u.E_Mail = email;
            u.IsActive = false;
            u.IsOnline = false;

            return UserSignUp(u);
        }
        //public int select(string username)
        //{
        //    int result = 0;

        //    try
        //    {
        //        //LINQ command for check username
        //        var query = from u in DB.Users
        //                    where u.UserName == username
        //                    select u;
        //        var user = query.ToList();

        //        if (user.Count == 0)
        //        {
        //            result = -2; // this user is not  exist
        //            return result;
        //        }

        //        if (user.Count == 1)
        //        {

        //            if (user[0].IsActive == false)
        //            {
        //                result = -1; // this user is exist but not confirm code yet
        //                return result;
        //            }

        //            //update is_active true
        //            result = user[0].ID;
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return result;
        //}

        public void activeUsers(string userName)
        {
            DB.SpActiveUserByUserName(userName, true);
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