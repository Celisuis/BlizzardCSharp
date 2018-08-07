using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class SeasonalProfile
    {
        public int SeasonID { get; internal set; }

        public int ParagonLevel { get; internal set; }

        public int HardcoreParagonLevel { get; internal set; }

        public Kill Kills { get; internal set; }

        public TimePlayed TimePlayed { get; internal set; }

        public int HighestHardcoreLevel { get; internal set; }

        public SeasonalProfile(JObject rawData)
        {
            if (rawData["seasonId"] != null)
                SeasonID = int.Parse(rawData["seasonId"].ToString());
            if (rawData["paragonLevel"] != null)
                ParagonLevel = int.Parse(rawData["paragonLevel"].ToString());
            if (rawData["paragonLevelHardcore"] != null)
                HardcoreParagonLevel = int.Parse(rawData["paragonLevelHardcore"].ToString());
            if (rawData["kills"] != null)
                Kills = new Kill(JObject.Parse(rawData["kills"].ToString()));
            if (rawData["timePlayed"] != null)
                TimePlayed = new TimePlayed(JObject.Parse(rawData["timePlayed"].ToString()));
            if (rawData["highestHardcoreLevel"] != null)
                HighestHardcoreLevel = int.Parse(rawData["highestHardcoreLevel"].ToString());
        }
    }
}
