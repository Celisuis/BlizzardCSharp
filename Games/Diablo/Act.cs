using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Act
    {
        public string Slug { get; internal set; }

        public int Number { get; internal set; }

        public string Name { get; internal set; }

        public List<Quest> QuestList { get; internal set; }

        public Act(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["number"] != null)
                Number = int.Parse(rawData["number"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if(rawData["quests"] != null && rawData["quests"].HasValues)
            {
                QuestList = new List<Quest>();

                foreach(JObject quest in rawData["quests"])
                {
                    Quest newQuest = new Quest(quest);
                    QuestList.Add(newQuest);
                }
            }
        }
    }
}
