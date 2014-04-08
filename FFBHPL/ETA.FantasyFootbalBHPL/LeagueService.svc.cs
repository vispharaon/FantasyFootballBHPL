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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LeagueService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LeagueService.svc or LeagueService.svc.cs at the Solution Explorer and start debugging.
    public class LeagueService : ILeagueService
    {

        public JsonObjectAttribute readLeague(int leagueId)
        {
            var context = new FFBHPLEntities();
            var league = context.league.Where(t => t.idLeague == leagueId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(league).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readPlayersLeague(int playerId)
        {
            var context = new FFBHPLEntities();
            var league = context.league.Where(t => t.owner == playerId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(league).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createLeague(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                league s = js.Deserialize<league>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateLeague(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            league s = js.Deserialize<league>(str1);

            var league = context.league.Where(t => t.idLeague == s.idLeague).First();

            league.fromGameweek = s.fromGameweek;
            league.gameweek = s.gameweek;
            league.leagueName = s.leagueName;
            league.leagueparticipants = s.leagueparticipants;
            league.owner = s.owner;
            league.user = s.user;


            string str2 = js.Serialize(league).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteLeague(int leagueId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new league { idLeague = leagueId };
            context.league.Attach(s);
            context.league.Remove(s);
            var check = new footballteam { idFootballTeam = leagueId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
