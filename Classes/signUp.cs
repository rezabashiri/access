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

        public void user_insert(string userName, string pass, string email)
        {
            bool isconfirm = false; //when this true that 
            bool isActive = false;
            bool isOnline = false;

            DB.sp_signup_insert(null, null, userName, pass, null, isActive, isOnline, isconfirm, null, null, null, null, null, null, null, email, null, null, null, null, null, null, null, null, null, null, null, null, null);

        }

        public int select(string username)
        {
            int result = 0;

            try
            {
                //LINQ command for check username
                var query = from u in DB.Users
                            where u.UserName == username
                            select u;
                var user = query.ToList();

                if (user.Count == 0)
                {
                    result = -2; // this user is not  exist
                    return result;
                }

                if (user.Count == 1)
                {

                    if (user[0].IsConfirm == false)
                    {
                        result = -1; // this user is exist but not confirm code yet
                        return result;
                    }

                    //update is_confirm , is_active true
                    result = user[0].ID;
                }
            }
            catch
            {
            }
            return result;
        }

        public void activeUsers(string userName)
        {
            int ID = this.select(userName);

            if (ID > 0)// can update
            {
                DB.sp_active_User(true, true, ID);
            }
        }

    }
}