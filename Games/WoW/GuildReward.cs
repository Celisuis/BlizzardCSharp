using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class GuildReward
    {
        public int MinimumGuildLevel { get; internal set; }

        public int MinimumGuildReputationLevel { get; internal set; }

        public Achievement Achievement { get; internal set; }

        public Item Item { get; internal set; }

        public GuildReward(JToken rawData)
        {
            MinimumGuildLevel = int.Parse(rawData["minGuildLevel"].ToString());
            MinimumGuildReputationLevel = int.Parse(rawData["minGuildRepLevel"].ToString());
            Achievement = new Achievement(JObject.Parse(rawData["achievement"].ToString()));
            Item = new Item(JObject.Parse(rawData["item"].ToString()));
        }
    }
}
