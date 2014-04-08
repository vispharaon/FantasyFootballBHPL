using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using FFBHPL.Models;

namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SquadService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SquadService.svc or SquadService.svc.cs at the Solution Explorer and start debugging.
    public class SquadService : ISquadService
    {
       
        public bool createSquad(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                selectedsquad s = js.Deserialize<selectedsquad>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public bool buyPlayer(int playerId, int userId)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            bool value = false;
            var squad = context.selectedsquad.Where(t => t.idPlayersTeam2 == userId).First();
           squad.mid5In = playerId;
           if(squad.mid5In!=0) value = true;

            string str2 = js.Serialize(squad).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return value;
        }

        public bool sellPlayer(int playerId, int userId)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            bool value = false;
            var squad = context.selectedsquad.Where(t => t.idPlayersTeam2 == userId).First();
            squad.mid5In = 0;
            if (squad.mid5In == 0) value = true;

            string str2 = js.Serialize(squad).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return value;
        }

        public bool leaveLeague(int userId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new user { owner = userId };
            context.league.Attach(s);
            context.league.Remove(s);
            var check = new league { idLeague = userId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
