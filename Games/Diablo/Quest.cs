using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Quest
    {
        public int QuestID { get; internal set; }

        public string Name { get; internal set; }

        public string Slug { get; internal set; }

        public Quest(JObject rawData)
        {
            if (rawData["id"] != null)
                QuestID = int.Parse(rawData["id"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
        }
    }
}
