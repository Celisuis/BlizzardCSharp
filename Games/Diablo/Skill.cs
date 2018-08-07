using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Skill
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public int Level { get; internal set; }

        public string ToolTipURL { get; internal set; }

        public string Description { get; internal set; }

        public string DescriptionHTML { get; internal set; }

        public Skill(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["tooltipUrl"] != null)
                ToolTipURL = rawData["tooltipUrl"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["descriptionHtml"] != null)
                DescriptionHTML = rawData["descriptionHtml"].ToString();
        }
    }
}
