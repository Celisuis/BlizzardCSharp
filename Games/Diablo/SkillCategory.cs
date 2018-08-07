using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class SkillCategory
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public SkillCategory(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
        }
    }
}
