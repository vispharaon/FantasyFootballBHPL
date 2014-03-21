using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMatchEventService" in both code and config file together.
    [ServiceContract]
    public interface IMatchEventService
    {
        [OperationContract]
        JsonObjectAttribute readMatchEvent(int matchEventId);
        [OperationContract]
        bool createMatchEvent(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateMatchEvent(JsonObjectAttribute input);
        [OperationContract]
        bool deleteMatchEvent(int seasonId);
    }
}
