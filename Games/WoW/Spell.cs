using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Spell
    {
        public int ID { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public string Description { get; internal set; }

        public string Range { get; internal set; }

        public string PowerCost { get; internal set; }

        public string CastTime { get; internal set; }

        public string Cooldown { get; internal set; }

        public Spell(JObject rawData)
        {
            ID = int.Parse(rawData["id"].ToString());
            Name = rawData["name"].ToString();
            Icon = rawData["icon"].ToString();
            Description = rawData["description"].ToString();
            if (rawData["range"] != null)
                Range = rawData["range"].ToString();
            if (rawData["powerCost"] != null)
                PowerCost = rawData["powerCost"].ToString();
            if (rawData["castTime"] != null)
                CastTime = rawData["castTime"].ToString();
            if (rawData["cooldown"] != null)
                Cooldown = rawData["cooldown"].ToString();
        }
    }
}
