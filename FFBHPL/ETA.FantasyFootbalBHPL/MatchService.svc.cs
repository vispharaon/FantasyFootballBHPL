using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using FFBHPL.Models;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MatchService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MatchService.svc or MatchService.svc.cs at the Solution Explorer and start debugging.
    public class MatchService : IMatchService
    {

        public JsonObjectAttribute readMatch(int matchId)
        {
            var context = new FFBHPLEntities();
            var match = context.match.Where(t => t.idMatch == matchId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(match).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readAllMatches()
        {
            var context = new FFBHPLEntities();
            var match = context.match.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(match).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createMatch(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                match s = js.Deserialize<match>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateMatch(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            match s = js.Deserialize<match>(str1);

            var match = context.match.Where(t => t.idMatch == s.idMatch).First();

            match.awayTeam = s.awayTeam;
            match.footballteam = s.footballteam;
            match.footballteam1 = s.footballteam1;
            match.gameweek = s.gameweek;
            match.homeTeam = s.homeTeam;
            match.idGameWeek2 = s.idGameWeek2;
            match.matchevents = s.matchevents;
            


            string str2 = js.Serialize(match).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteMatch(int matchId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new match { idMatch = matchId };
            context.match.Attach(s);
            context.match.Remove(s);
            var check = new match { idMatch = matchId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
