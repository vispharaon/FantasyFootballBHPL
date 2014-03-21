using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FFBHPL.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MatchEventService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MatchEventService.svc or MatchEventService.svc.cs at the Solution Explorer and start debugging.
    public class MatchEventService : IMatchEventService
    {
        public void DoWork()
        {
        }

        public JsonObjectAttribute readMatchEvent(int matchEventId)
        {
            var context = new FFBHPLEntities();
            var matchEvent = context.matchevents.Where(t => t.idMatchEvents == matchEventId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(matchEvent).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createMatchEvent(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                matchevents s = js.Deserialize<matchevents>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateMatchEvent(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            matchevents s = js.Deserialize<matchevents>(str1);

            var matchEvent = context.matchevents.Where(t => t.idMatchEvents == s.idMatchEvents).First();

            matchEvent.idEvents1 = s.idEvents1;
            matchEvent.idFootballPlayer1 = s.idFootballPlayer1;
            matchEvent.idMatch1 = s.idMatch1;
            matchEvent.idMatchEvents = s.idMatchEvents;
            matchEvent.match = s.match;
            matchEvent.minute = s.minute;



            string str2 = js.Serialize(matchEvent).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteMatchEvent(int matchId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new matchevents { idMatchEvents = matchId };
            context.matchevents.Attach(s);
            context.matchevents.Remove(s);
            var check = new matchevents { idMatchEvents = matchId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
