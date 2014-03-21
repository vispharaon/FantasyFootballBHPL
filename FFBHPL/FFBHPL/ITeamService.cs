using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamService" in both code and config file together.
    [ServiceContract]
    public interface ITeamService
    {
        [OperationContract]
        JsonObjectAttribute readTeam(int teamId);
        [OperationContract]
        JsonObjectAttribute readAllTeams();
        [OperationContract]
        bool createTeam(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateTeam(JsonObjectAttribute input);
        [OperationContract]
        bool deleteTeam(int seasonId);
    }
}
