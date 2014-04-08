using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserAccountService" in both code and config file together.
    [ServiceContract]
    public interface IUserAccountService
    {
        [OperationContract]
        JsonObjectAttribute readUserAccount(int userId);
        [OperationContract]
        JsonObjectAttribute readAllUserAccounts();
        [OperationContract]
        bool createUserAccount(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateUserAccount(JsonObjectAttribute input);
        [OperationContract]
        bool deleteUserAccount(int idUser);
}
