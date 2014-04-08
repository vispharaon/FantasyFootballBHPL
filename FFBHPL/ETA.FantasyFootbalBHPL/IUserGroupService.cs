using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserGroupService" in both code and config file together.
    [ServiceContract]
    public interface IUserGroupService
    {
        [OperationContract]
        JsonObjectAttribute readUserGroup(int userGroupId);
        [OperationContract]
        JsonObjectAttribute readAllUserGroups();
        [OperationContract]
        bool createUserGroup(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateUserGroup(JsonObjectAttribute input);
        [OperationContract]
        bool deleteUserGroup(int idUser);
    }
}
