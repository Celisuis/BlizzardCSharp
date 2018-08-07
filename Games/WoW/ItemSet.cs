using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class ItemSet
    {
        public class SetBonus
        {
            public string Description { get; internal set; }

            public int Threshold { get; internal set; }

            public SetBonus(JObject BonusObject)
            {
                Description = BonusObject["description"].ToString();
                Threshold = int.Parse(BonusObject["threshold"].ToString());
            }
        }

        public int SetID { get; internal set; }

        public string Name { get; internal set; }

        public List<SetBonus> Bonuses { get; internal set; }

        public List<int> Items { get; internal set; }

        public ItemSet(JObject rawData)
        {
            SetID = int.Parse(rawData["id"].ToString());
            Name = rawData["name"].ToString();

            foreach (JObject BonusObject in rawData["setBonuses"])
            {
                Bonuses.Add(new SetBonus(BonusObject));
            }

            Items = new List<int>();

            foreach (int ItemInt in rawData["items"])
            {
                Items.Add(ItemInt);
            }

        }
    }
}
