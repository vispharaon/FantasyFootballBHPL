using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISquadService" in both code and config file together.
    [ServiceContract]
    public interface ISquadService
    {
        [OperationContract]
        bool createSquad(JsonObjectAttribute input);
         [OperationContract]
        bool buyPlayer(int playerId, int userId);
         [OperationContract]
        bool sellPlayer (int playerId, int userId);
         [OperationContract]
        bool leaveLeague(int userId);
    }
}
