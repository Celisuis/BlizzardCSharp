using BlizzardCSharp.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class Ability
    {
        public string Name { get; internal set; }

        public string Description { get; internal set; }

        public Image Icon { get; internal set; }

        public string IconPath { get; internal set; }

        public Ability(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if(rawData["icon"] != null)
            {
                IconPath = rawData["icon"].ToString();
                Icon = ImageHelper.RetrieveImage(IconPath);
            }
        }
    }
}
