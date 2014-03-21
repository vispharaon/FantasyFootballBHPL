using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace FFBHPL
{
    
    [ServiceContract]
    public interface ISeasonService
    {
        [OperationContract]
        JsonObjectAttribute readSeason(int seasonId);
        [OperationContract]
        bool createSeason(JsonObjectAttribute input);
        [OperationContract]
        JsonObjectAttribute updateSeason(JsonObjectAttribute input);
        [OperationContract]
        bool deleteSeason(int seasonId);

        
    }
}
