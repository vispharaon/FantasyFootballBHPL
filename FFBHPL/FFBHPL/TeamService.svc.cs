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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TeamService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TeamService.svc or TeamService.svc.cs at the Solution Explorer and start debugging.
    public class TeamService : ITeamService
    {

        public JsonObjectAttribute readTeam(int teamId)
        {
            var context = new FFBHPLEntities();
            var team = context.footballteam.Where(t => t.idFootballTeam == teamId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(team).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readAllTeams()
        {
            var context = new FFBHPLEntities();
            var team = context.footballteam.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(team).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createTeam(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                footballteam s = js.Deserialize<footballteam>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public JsonObjectAttribute updateTeam(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            footballteam s = js.Deserialize<footballteam>(str1);

            var team = context.footballteam.Where(t => t.idFootballTeam == s.idFootballTeam).First();

            team.footballplayer = s.footballplayer;
            team.match = s.match;
            team.match1 = s.match1;
            team.teamAmblem = s.teamAmblem;
            team.teamName = s.teamName;
            team.teamShirt = s.teamShirt;


            string str2 = js.Serialize(team).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deleteTeam(int teamId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new footballteam { idFootballTeam = teamId };
            context.footballteam.Attach(s);
            context.footballteam.Remove(s);
            var check = new footballteam { idFootballTeam = teamId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
