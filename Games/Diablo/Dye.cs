using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
   public class Dye
    {
        public string ID { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public string TooltipParameters { get; internal set; }

        public Dye(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = rawData["id"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["tooltipParams"] != null)
                TooltipParameters = rawData["tooltipParams"].ToString();
        }
    }
}
