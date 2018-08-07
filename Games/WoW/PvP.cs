using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class PvP
    {
        public int Ranking { get; internal set; }

        public int Rating { get; internal set; }
        public string Name { get; internal set; }
        public int RealmID { get; internal set; }
        public string RealmName { get; internal set; }
        public string RealmSlug { get; internal set; }
        public int RaceID { get; internal set; }
        public int ClassID { get; internal set; }
        public int SpecID { get; internal set; }
        public int FactionID { get; internal set; }
        public int GenderID { get; internal set; }
        public int SeasonWins { get; internal set; }
        public int SeasonLosses { get; internal set; }
        public int WeeklyWins { get; internal set; }
        public int WeeklyLosses { get; internal set; }

        public PvP(JObject rawData)
        {
            Ranking = int.Parse(rawData["ranking"].ToString());
            Rating = int.Parse(rawData["rating"].ToString());
            Name = rawData["name"].ToString();
            RealmID = int.Parse(rawData["realmId"].ToString());
            RealmName = rawData["realmName"].ToString();
            RealmSlug = rawData["realmSlug"].ToString();
            RaceID = int.Parse(rawData["raceId"].ToString());
            ClassID = int.Parse(rawData["classId"].ToString());
            SpecID = int.Parse(rawData["specId"].ToString());
            FactionID = int.Parse(rawData["factionId"].ToString());
            GenderID = int.Parse(rawData["genderId"].ToString());
            SeasonWins = int.Parse(rawData["seasonWins"].ToString());
            SeasonLosses = int.Parse(rawData["seasonLosses"].ToString());
            WeeklyWins = int.Parse(rawData["weeklyWins"].ToString());
            WeeklyLosses = int.Parse(rawData["weeklyLosses"].ToString());
        }
    }
}
