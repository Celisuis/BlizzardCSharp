﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class EquippedItem
    {
        public string ID { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public string DisplayColor { get; internal set; }

        public string TooltipParameters { get; internal set; }

        public Dye DyeColor { get; internal set; }

        public Item TransmoggedItem { get; internal set; }

        public EquippedItem(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = rawData["id"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["displayColor"] != null)
                DisplayColor = rawData["displayColor"].ToString();
            if (rawData["tooltipParams"] != null)
                TooltipParameters = rawData["tooltipParams"].ToString();
            if (rawData["dyeColor"] != null)
                DyeColor = new Dye(JObject.Parse(rawData["dyeColor"].ToString()));
            if (rawData["transmogItem"] != null)
                TransmoggedItem = new Item(JObject.Parse(rawData["transmogItem"].ToString()));
        }
    }
}
