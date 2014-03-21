using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FFBHPL.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserGroupService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserGroupService.svc or UserGroupService.svc.cs at the Solution Explorer and start debugging.
    public class UserGroupService : IUserGroupService
    {

        public JsonObjectAttribute readUserGroup(int userGroupId)
        {
            var context = new FFBHPLEntities();
            var userGroup = context.usergroup.Where(t => t.idUserGroup == userGroupId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(userGroup).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readAllUserGroups()
        {
            var context = new FFBHPLEntities();
            var userGroup = context.usergroup.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(userGroup).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createUserGroup(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                usergroup s = js.Deserialize<usergroup>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateUserGroup(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            usergroup s = js.Deserialize<usergroup>(str1);

            var userGroup = context.usergroup.Where(t => t.idUserGroup == s.idUserGroup).First();

            userGroup.groupName = s.groupName;
           

            string str2 = js.Serialize(userGroup).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteUserGroup(int idUserGroup)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new usergroup { idUserGroup = idUserGroup };
            context.usergroup.Attach(s);
            context.usergroup.Remove(s);
            var check = new usergroup { idUserGroup = idUserGroup };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
