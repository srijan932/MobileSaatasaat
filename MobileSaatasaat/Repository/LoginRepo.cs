using Dapper;
using MobileSaatasaat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.Repository
{
    public class LoginRepo
    {
        public SessionVM CheckLogin(string Email, string Password, string returnUrl)
        {
            string query = "select u.UserId, u.FullName, u.Email" +
                " from Users u" +
                " where u.Email = '" + Email + "' and u.Password = '" + Password + "'";
            using (var db = DBHelper.GetDbConnection())
            {
                return db.Query<SessionVM>(query).SingleOrDefault();
            }
        }
    }
}