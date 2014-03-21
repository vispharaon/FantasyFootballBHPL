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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlayerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlayerService.svc or PlayerService.svc.cs at the Solution Explorer and start debugging.
    public class PlayerService : IPlayerService
    {

        public JsonObjectAttribute readPlayer(int playerId)
        {
            var context = new FFBHPLEntities();
            var player = context.footballplayer.Where(t => t.idFootballPlayer == playerId);
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(player).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public JsonObjectAttribute readAllPlayers()
        {
            var context = new FFBHPLEntities();
            var player = context.footballplayer.ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string joa = js.Serialize(player).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
            return j;
        }

        public bool createPlayer(Newtonsoft.Json.JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            bool value = false;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = input.ToString();
            if (!str.Equals(""))
            {
                footballplayer s = js.Deserialize<footballplayer>(str);
                value = true;
            }
            context.SaveChanges();
            return value;
        }

        public Newtonsoft.Json.JsonObjectAttribute updatePlayer(Newtonsoft.Json.JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            footballplayer s = js.Deserialize<footballplayer>(str1);

            var player = context.footballplayer.Where(t => t.idFootballPlayer == s.idFootballPlayer).First();

            player.firstName = s.firstName;
            player.footballteam = s.footballteam;
            player.idFootballTeam1 = s.idFootballTeam1;
            player.idPosition1 = s.idPosition1;
            player.lastName = s.lastName;
            player.matchevents = s.matchevents;
            player.picture = s.picture;
            player.playernews = s.playernews;
            player.playersteam = s.playersteam;
            player.playersteam1 = s.playersteam1;
            player.playersteam10 = s.playersteam10;
            player.playersteam11 = s.playersteam11;
            player.playersteam12 = s.playersteam12;
            player.playersteam13 = s.playersteam13;
            player.playersteam14 = s.playersteam14;
            player.playersteam2 = s.playersteam2;
            player.playersteam3 = s.playersteam3;
            player.playersteam4 = s.playersteam4;
            player.playersteam5 = s.playersteam5;
            player.playersteam6 = s.playersteam6;
            player.playersteam7 = s.playersteam7;
            player.playersteam8 = s.playersteam8;
            player.playersteam9 = s.playersteam9;
  

            string str2 = js.Serialize(player).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
        }

        public bool deletePlayer(int playerId)
        {
            bool value = false;
            var context = new FFBHPLEntities();
            var s = new footballplayer { idFootballPlayer = playerId };
            context.footballplayer.Attach(s);
            context.footballplayer.Remove(s);
            var check = new footballplayer { idFootballPlayer = playerId };
            if (check != null) value = true;

            context.SaveChanges();
            return value;
        }
    }
}
