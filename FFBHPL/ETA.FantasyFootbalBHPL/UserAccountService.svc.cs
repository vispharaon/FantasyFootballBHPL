using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FFBHPL.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserAccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserAccountService.svc or UserAccountService.svc.cs at the Solution Explorer and start debugging.
    public class UserAccountService : IUserAccountService
    {

        public JsonObjectAttribute readUserAccount(int userId)
        {
            var context = new FFBHPLEntities();
            var userAccount = context.user.Where(t => t.userId == userId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(userAccount).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readAllUserAccounts()
        {
            var context = new FFBHPLEntities();
            var userAccount = context.user.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(userAccount).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createUserAccount(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                user s = js.Deserialize<user>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateUserAccount(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            user s = js.Deserialize<user>(str1);

            var userAccount = context.user.Where(t => t.userId == s.userId).First();

            userAccount.firstName = s.firstName;
            userAccount.cellPhone = s.cellPhone;
            userAccount.closestCity = s.closestCity;
            userAccount.country = s.country;
            userAccount.dateOfBirth = s.dateOfBirth;
            userAccount.email = s.email;
            userAccount.gender = s.gender;
            userAccount.idPlayersTeam1 = s.idPlayersTeam1;
            userAccount.lastName = s.lastName;
            userAccount.league = s.league;
            userAccount.leagueparticipants = s.leagueparticipants;
            userAccount.password = s.password;
            userAccount.region = s.region;
            userAccount.timeZone = s.timeZone;
            userAccount.usergroup = s.usergroup;
            userAccount.zipCode = s.zipCode;

            string str2 = js.Serialize(userAccount).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteUserAccount(int idUser)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new user { userId = idUser };
            context.user.Attach(s);
            context.user.Remove(s);
            var check = new user { userId = idUser };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
