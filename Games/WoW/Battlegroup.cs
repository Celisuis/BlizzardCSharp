using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Battlegroup
    {
        public string Name { get; internal set; }

        public string Slug { get; internal set; }

        public Battlegroup(JObject rawData)
        {
            Name = rawData["name"].ToString();
            Slug = rawData["slug"].ToString();
        }
    }
}
