using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Recipe
    {
        public string ID { get; internal set; }

        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public int Cost { get; internal set; }

        public List<Reagent> Reagents { get; internal set; }

        public Item ItemProduced { get; internal set; }

        public Recipe(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = rawData["id"].ToString();
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["cost"] != null)
                Cost = int.Parse(rawData["cost"].ToString());
            if(rawData["reagents"] != null && rawData["reagents"].HasValues)
            {
                Reagents = new List<Reagent>();

                foreach(JObject reagentObject in rawData["reagents"])
                {
                    Reagent reagent = new Reagent(reagentObject);

                    Reagents.Add(reagent);
                }
            }
            if (rawData["itemProduced"] != null)
                ItemProduced = new Item(JObject.Parse(rawData["itemProduced"].ToString()));
        }
    }
}
