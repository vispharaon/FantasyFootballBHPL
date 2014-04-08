using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FFBHPL.Models;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
namespace FFBHPL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ISeasonService
    {  
       public JsonObjectAttribute readSeason(int seasonId)
           {
            var context = new FFBHPLEntities();
            var season = context.season.Where(t => t.idSeason == seasonId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            string joa= js.Serialize(season).ToString();

            JsonObjectAttribute j = new JsonObjectAttribute(joa);
            context.SaveChanges();
           return j;
        }

        public bool createSeason(JsonObjectAttribute input)
            {
                var context = new FFBHPLEntities();
                bool value = false;
                JavaScriptSerializer js = new JavaScriptSerializer();
                string str = input.ToString();
                if (!str.Equals(""))
                {
                    season s = js.Deserialize<season>(str);
                    value = true;
                }
                context.SaveChanges();
                return value;
        }

        public JsonObjectAttribute updateSeason(JsonObjectAttribute input)
        {
            var context = new FFBHPLEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str1 = input.ToString();
            season s = js.Deserialize<season>(str1);

            var season = context.season.Where(t => t.idSeason == s.idSeason).First();

            season.seasonName = s.seasonName;
            season.description = s.description;
            season.gameweek = s.gameweek;

            string str2 = js.Serialize(season).ToString();
            JsonObjectAttribute j = new JsonObjectAttribute(str2);

            context.SaveChanges();
            return j;
           
        }

        public bool deleteSeason(int seasonId)
        {

        bool value = false;
        var context = new FFBHPLEntities();
        var s = new season { idSeason = seasonId};
        context.season.Attach(s);
        context.season.Remove(s);
        var check = new season { idSeason= seasonId};
        if (check != null) value = true;

        context.SaveChanges();
        return value;
        }
}
}
