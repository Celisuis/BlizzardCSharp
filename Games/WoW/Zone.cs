using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Zone
    {
        public class Location
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public Location(JObject LocationObject)
            {
                ID = int.Parse(LocationObject["id"].ToString());
                Name = LocationObject["name"].ToString();
            }
        }

        public int ID { get; internal set; }

        public string Name { get; internal set; }

        public string URLSlug { get; internal set; }

        public string Description { get; internal set; }
        public Location ZoneLocation { get; internal set; }
        public int ExpansionID { get; internal set; }
        public string NumberOfPlayers { get; internal set; }
        public bool IsDungeon { get; internal set; }
        public bool IsRaid { get; internal set; }
        public int AdvisedMinimumLevel { get; internal set; }
        public int AdvisedMaximumLevel { get; internal set; }
        public int AdvisedHeroicMinimumLevel { get; internal set; }
        public int AdvisedHeroicMaximumLevel { get; internal set; }
        public List<string> AvailableModes { get; internal set; }
        public int LFGNormalMinimumGearLevel { get; internal set; }
        public int LFGHeroicMinimumGearLevel { get; internal set; }
        public int Floors { get; internal set; }
        public List<Boss> Bosses { get; internal set; }

        public Zone(JObject rawData)
        {
            ID = int.Parse(rawData["id"].ToString());
            Name = rawData["name"].ToString();
            URLSlug = rawData["urlSlug"].ToString();
            Description = rawData["description"].ToString();
            ZoneLocation = new Location(JObject.Parse(rawData["location"].ToString()));
            ExpansionID = int.Parse(rawData["expansionId"].ToString());
            NumberOfPlayers = rawData["numPlayers"].ToString();
            IsDungeon = bool.Parse(rawData["isDungeon"].ToString());
            IsRaid = bool.Parse(rawData["isRaid"].ToString());
            AdvisedMinimumLevel = int.Parse(rawData["advisedMinLevel"].ToString());
            AdvisedMaximumLevel = int.Parse(rawData["advisedMaxLevel"].ToString());
            AdvisedHeroicMinimumLevel = int.Parse(rawData["advisedHeroicMinLevel"].ToString());
            AdvisedHeroicMaximumLevel = int.Parse(rawData["advisedHeroicMaxLevel"].ToString());
            AvailableModes = new List<string>();

            foreach (string mode in rawData["availableModes"])
            {

                AvailableModes.Add(mode);
            }

            LFGNormalMinimumGearLevel = int.Parse(rawData["lfgNormalMinGearLevel"].ToString());
            LFGHeroicMinimumGearLevel = int.Parse(rawData["lfgHeroicMinGearLevel"].ToString());
            Floors = int.Parse(rawData["floors"].ToString());

            Bosses = new List<Boss>();

            foreach (JObject BossObject in rawData["bosses"])
            {
                Bosses.Add(new Boss(BossObject));
            }
        }
    }
}
