using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class GuildPerk
    {
        public class Perk
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public string Subtext { get; internal set; }

            public string Icon { get; internal set; }

            public string Description { get; internal set; }

            public string CastTime { get; internal set; }

            public Perk(JObject PerkObject)
            {
                if (PerkObject["id"] != null)
                    ID = int.Parse(PerkObject["id"].ToString());
                if (PerkObject["name"] != null)
                    Name = PerkObject["name"].ToString();
                if (PerkObject["subtext"] != null)
                    Subtext = PerkObject["subtext"].ToString();
                if (PerkObject["icon"] != null)
                    Icon = PerkObject["icon"].ToString();
                if (PerkObject["description"] != null)
                    Description = PerkObject["description"].ToString();
                if (PerkObject["castTime"] != null)
                    CastTime = PerkObject["castTime"].ToString();

            }
        }

        public int GuildLevel { get; internal set; }

        public Perk PerkSpell { get; internal set; }

        public GuildPerk(JToken rawData)
        {
            GuildLevel = int.Parse(rawData["guildLevel"].ToString());
            PerkSpell = new Perk(JObject.Parse(rawData["spell"].ToString()));
        }
    }
}
