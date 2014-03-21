using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlayerService" in both code and config file together.
    [ServiceContract]
    public interface IPlayerService
    {
        [OperationContract]
        JsonObjectAttribute readPlayer(int playerId);
        [OperationContract]
        JsonObjectAttribute readAllPlayers();
        [OperationContract]
        bool createPlayer(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updatePlayer(JsonObjectAttribute input);
        [OperationContract]
        bool deletePlayer(int seasonId);
    }
}
