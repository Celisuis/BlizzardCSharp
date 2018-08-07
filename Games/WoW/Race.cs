using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Race
    {
        public int RaceID { get; internal set; }

        public int Mask { get; internal set; }

        public string Faction { get; internal set; }

        public string Name { get; internal set; }

        public Race(JObject rawData)
        {
            RaceID = int.Parse(rawData["id"].ToString());
            Mask = int.Parse(rawData["mask"].ToString());
            Faction = rawData["side"].ToString();
            Name = rawData["name"].ToString();
        }
    }
}
