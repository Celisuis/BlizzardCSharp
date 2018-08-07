using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Item
    {
        public class ItemType
        {
            public bool TwoHanded { get; internal set; }
            public string ID { get; internal set; }

            public ItemType(JObject rawData)
            {
                if (rawData["twoHanded"] != null)
                    TwoHanded = bool.Parse(rawData["twoHanded"].ToString());
                if (rawData["id"] != null)
                    ID = rawData["id"].ToString();
            }
        }

        public class Attribute
        {
            public List<string> Primary { get; internal set; }
            public List<string> Secondary { get; internal set; }

            public Attribute(JObject rawData)
            {
                if(rawData["primary"] != null && rawData["primary"].HasValues)
                {
                    JArray primaryArray = JArray.Parse(rawData["primary"].ToString());

                    Primary = primaryArray.Select(x => x.ToString()).ToList();
                }
                if(rawData["secondary"] != null && rawData["secondary"].HasValues)
                {
                    JArray secondaryArray = JArray.Parse(rawData["secondary"].ToString());

                    Secondary = secondaryArray.Select(x => x.ToString()).ToList();
                }
            }
        }

        public class Gem
        {
            public Item ActualItem { get; internal set; }

            public List<string> Attributes { get; internal set; }

            public bool IsGem { get; internal set; }

            public bool IsJewel { get; internal set; }

            public Gem(JObject rawData)
            {
                if (rawData["item"] != null)
                    ActualItem = new Item(JObject.Parse(rawData["item"].ToString()));
                if(rawData["attributes"] != null && rawData["attributes"].HasValues)
                {
                    JArray array = JArray.Parse(rawData["attributes"].ToString());
                    Attributes = array.Select(x => x.ToString()).ToList();
                }
                if (rawData["isGem"] != null)
                    IsGem = bool.Parse(rawData["isGem"].ToString());
                if (rawData["isJewel"] != null)
                    IsJewel = bool.Parse(rawData["isJewel"].ToString());
            }
        }

        public class ItemSet
        {
            public string ID { get; internal set; }

            public string Name { get; internal set; }

            public string Description { get; internal set; }

            public string DescriptionHTML { get; internal set; }

            public ItemSet(JObject rawData)
            {
                if (rawData["id"] != null)
                    ID = rawData["id"].ToString();
                if (rawData["name"] != null)
                    Name = rawData["name"].ToString();
                if (rawData["description"] != null)
                    Description = rawData["description"].ToString();
                if (rawData["descriptionHtml"] != null)
                    DescriptionHTML = rawData["descriptionHtml"].ToString();
            }
        }

        public string ID { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public string Path { get; internal set; }
        public string DisplayColor { get; internal set; }

        public string TooltipParameters { get; internal set; }

        public int RequiredLevel { get; internal set; }

        public int ItemLevel { get; internal set; }

        public int MaxStackSize { get; internal set; }

        public bool AccountBound { get; internal set; }

        public string FlavorText { get; internal set; }

        public string TypeName { get; internal set; }

        public ItemType Type { get; internal set; }

        public double Armor { get; internal set; }

        public double AttacksPerSecond { get; internal set; }

        public string Damage { get; internal set; }

        public string DPS { get; internal set; }
        public double MinimumDamage { get; internal set; }

        public double MaximumDamage { get; internal set; }

        public string Slot { get; internal set; }

        public string Augmentation { get; internal set; }

        public Attribute Attributes { get; internal set; }

        public Attribute AttributesHTML { get; internal set; }

        public int OpenSockets { get; internal set; }

        public List<Gem> Gems { get; internal set; }

        public ItemSet Set { get; internal set; }

        public int SeasonRequired { get; internal set; }

        public Dye Dye { get; internal set; }

        public bool SeasonalItem { get; internal set; }

        public string ElementType { get; internal set; }

        public Item TransmoggedItem { get; internal set; }

        public Item(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = rawData["id"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["path"] != null)
                Path = rawData["path"].ToString();
            if (rawData["displayColor"] != null)
                DisplayColor = rawData["displayColor"].ToString();
            if (rawData["tooltipParams"] != null)
                TooltipParameters = rawData["tooltipParams"].ToString();
            if (rawData["requiredLevel"] != null)
                RequiredLevel = int.Parse(rawData["requiredLevel"].ToString());
            if (rawData["itemLevel"] != null)
                ItemLevel = int.Parse(rawData["itemLevel"].ToString());
            if (rawData["stackSizeMax"] != null)
                MaxStackSize = int.Parse(rawData["stackSizeMax"].ToString());
            if (rawData["accountBound"] != null)
                AccountBound = bool.Parse(rawData["accountBound"].ToString());
            if (rawData["flavorText"] != null)
                FlavorText = rawData["flavorText"].ToString();
            if (rawData["typeName"] != null)
                TypeName = rawData["typeName"].ToString();
            if (rawData["type"] != null)
                Type = new ItemType(JObject.Parse(rawData["type"].ToString()));
            if (rawData["armor"] != null)
                Armor = double.Parse(rawData["armor"].ToString());
            if (rawData["attacksPerSecond"] != null)
                AttacksPerSecond = double.Parse(rawData["attacksPerSecond"].ToString());
            if (rawData["damage"] != null)
                Damage = rawData["damage"].ToString();
            if (rawData["dps"] != null)
                DPS = rawData["dps"].ToString();
            if (rawData["minDamage"] != null)
                MinimumDamage = double.Parse(rawData["minDamage"].ToString());
            if (rawData["maxDamage"] != null)
                MaximumDamage = double.Parse(rawData["maxDamage"].ToString());
            if (rawData["slots"] != null && rawData["slots"].HasValues)
                Slot = rawData["slots"].ToString();
            if (rawData["augmentation"] != null)
                Augmentation = rawData["augmentation"].ToString();
            if (rawData["attributes"] != null)
                Attributes = new Attribute(JObject.Parse(rawData["attributes"].ToString()));
            if (rawData["attributesHtml"] != null)
                AttributesHTML = new Attribute(JObject.Parse(rawData["attributesHtml"].ToString()));
            if (rawData["openSockets"] != null)
                OpenSockets = int.Parse(rawData["openSockets"].ToString());
            if(rawData["gems"] != null && rawData["gems"].HasValues)
            {
                Gems = new List<Gem>();

                foreach(JObject gobject in rawData["gems"])
                {
                    Gem gem = new Gem(gobject);
                    Gems.Add(gem);
                }
            }
            if (rawData["set"] != null)
                Set = new ItemSet(JObject.Parse(rawData["set"].ToString()));
            if (rawData["seasonRequiredToDrop"] != null)
                SeasonRequired = int.Parse(rawData["seasonRequiredToDrop"].ToString());
            if (rawData["dye"] != null)
                Dye = new Dye(JObject.Parse(rawData["dye"].ToString()));
            if (rawData["isSeasonRequiredToDrop"] != null)
                SeasonalItem = bool.Parse(rawData["isSeasonRequiredToDrop"].ToString());
            if (rawData["elementalType"] != null)
                ElementType = rawData["elementalType"].ToString();
            if (rawData["transmog"] != null)
                TransmoggedItem = new Item(JObject.Parse(rawData["transmog"].ToString()));
        }

    }
}
