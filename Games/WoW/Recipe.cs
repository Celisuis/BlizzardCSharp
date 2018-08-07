using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Recipe
    {
        public int ID { get; internal set; }

        public string Name { get; internal set; }

        public string Profession { get; internal set; }

        public string Icon { get; internal set; }

        public Recipe(JObject rawData)
        {
            ID = int.Parse(rawData["id"].ToString());
            Name = rawData["name"].ToString();
            Profession = rawData["profession"].ToString();
            Icon = rawData["icon"].ToString();
        }
    }
}
