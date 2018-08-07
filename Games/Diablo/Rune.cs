using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Rune
    {
        public string Slug { get; internal set; }

        public string Type { get; internal set; }

        public string Name { get; internal set; }

        public int Level { get; internal set; }

        public string Description { get; internal set; }

        public string DescriptionHTML { get; internal set; }

        public Rune(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["type"] != null)
                Type = rawData["type"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["descriptionHtml"] != null)
                DescriptionHTML = rawData["descriptionHtml"].ToString();
        }
    }
}
