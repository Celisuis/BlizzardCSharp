using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Quest
    {
        public int QuestID { get; internal set; }

        public string Title { get; internal set; }

        public int RequiredLevel { get; internal set; }

        public int SuggestedPartySize { get; internal set; }

        public string Category { get; internal set; }

        public int Level { get; internal set; }

        public Quest(JObject rawData)
        {
            QuestID = int.Parse(rawData["id"].ToString());
            Title = rawData["title"].ToString();
            RequiredLevel = int.Parse(rawData["reqLevel"].ToString());
            SuggestedPartySize = int.Parse(rawData["suggestedPartyMembers"].ToString());
            Category = rawData["category"].ToString();
            Level = int.Parse(rawData["level"].ToString());
        }
    }
}
