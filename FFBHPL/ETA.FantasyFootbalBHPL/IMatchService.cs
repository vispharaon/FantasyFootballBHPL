using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMatchService" in both code and config file together.
    [ServiceContract]
    public interface IMatchService
    {
        [OperationContract]
        JsonObjectAttribute readMatch(int matchId);
        [OperationContract]
        JsonObjectAttribute readAllMatches();
        [OperationContract]
        bool createMatch(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateMatch(JsonObjectAttribute input);
        [OperationContract]
        bool deleteMatch(int seasonId);
    }
}
