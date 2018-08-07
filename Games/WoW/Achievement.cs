using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BlizzardCSharp.Games.WoW
{
    public class Achievement
    {
        public int ID { get; internal set; }

        public string Title { get; internal set; }

        public int Points { get; internal set; }

        public string Description { get; internal set; }

        public string Reward { get; internal set; }

        public List<Item> ItemReward { get; internal set; }

        public string Icon { get; internal set; }

        public List<Achievement> Criteria { get; internal set; }

        public bool AccountWide { get; internal set; }

        public int OrderIndex { get; internal set; }

        public int Max { get; internal set; }

        public Achievement(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = int.Parse(rawData["id"].ToString());
            if (rawData["title"] != null)
                Title = rawData["title"].ToString();
            if (rawData["points"] != null)
                Points = int.Parse(rawData["points"].ToString());
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["reward"] != null)
                Reward = rawData["reward"].ToString();
            if (rawData["rewardItems"] != null && rawData["rewardItems"].HasValues)
            {
                this.ItemReward = new List<Item>();
                foreach (JObject ItemRewardObject in rawData["rewardItems"])
                {
                    Item rewardItem = new Item(ItemRewardObject);
                    this.ItemReward.Add(rewardItem);
                }
            }
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["criteria"] != null && rawData["criteria"].HasValues)
            {
                Criteria = new List<Achievement>();
                foreach (JObject CriteriaObject in rawData["criteria"])
                {
                    Achievement criteria = new Achievement(CriteriaObject);
                    Criteria.Add(criteria);
                }
            }
            if (rawData["accountWide"] != null)
                AccountWide = bool.Parse(rawData["accountWide"].ToString());
            if (rawData["orderIndex"] != null)
                OrderIndex = int.Parse(rawData["orderIndex"].ToString());
            if (rawData["max"] != null)
                Max = int.Parse(rawData["max"].ToString());
        }

    }
}
