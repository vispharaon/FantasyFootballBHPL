using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILeagueService" in both code and config file together.
    [ServiceContract]
    public interface ILeagueService
    {
        [OperationContract]
        JsonObjectAttribute readLeague(int matchEventId);
        [OperationContract]
        JsonObjectAttribute readPlayersLeague(int playerId);
        [OperationContract]
        bool createLeague(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateLeague(JsonObjectAttribute input);
        [OperationContract]
        bool deleteLeague(int leagueId);
    }
}
