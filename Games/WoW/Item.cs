using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Item
    {
        public class ItemStat
        {
            public int Stat { get; internal set; }

            public int Amount { get; internal set; }

            public ItemStat(JToken StatToken)
            {
                if (StatToken["stat"] != null)
                    Stat = int.Parse(StatToken["stat"].ToString());
                if (StatToken["amount"] != null)
                    Amount = int.Parse(StatToken["amount"].ToString());
            }
        }

        public class ItemSpell
        {
            public class SpellItem
            {
                public int ID { get; internal set; }

                public string Name { get; internal set; }

                public string Icon { get; internal set; }

                public string Description { get; internal set; }

                public string CastTime { get; internal set; }

                public SpellItem(JToken SpellItemToken)
                {
                    if (SpellItemToken["id"] != null)
                        ID = int.Parse(SpellItemToken["id"].ToString());
                    if (SpellItemToken["name"] != null)
                        Name = SpellItemToken["name"].ToString();
                    if (SpellItemToken["icon"] != null)
                        Icon = SpellItemToken["icon"].ToString();
                    if (SpellItemToken["description"] != null)
                        Description = SpellItemToken["description"].ToString();
                    if (SpellItemToken["castTime"] != null)
                        CastTime = SpellItemToken["castTime"].ToString();
                }
            }

            public int SpellID { get; internal set; }

            public SpellItem Spell_Item { get; internal set; }

            public int NumberOfCharges { get; internal set; }

            public bool IsConsumable { get; internal set; }

            public int CategoryID { get; internal set; }

            public string Trigger { get; internal set; }

            public ItemSpell(JToken ItemToken)
            {
                if (ItemToken["spellId"] != null)
                    SpellID = int.Parse(ItemToken["spellId"].ToString());
                if (ItemToken["spell"] != null)
                    Spell_Item = new SpellItem(ItemToken["spell"]);
                if (ItemToken["nCharges"] != null)
                    NumberOfCharges = int.Parse(ItemToken["nCharges"].ToString());
                if (ItemToken["consumable"] != null)
                    IsConsumable = bool.Parse(ItemToken["consumable"].ToString());
                if (ItemToken["categoryId"] != null)
                    CategoryID = int.Parse(ItemToken["categoryId"].ToString());
                if (ItemToken["trigger"] != null)
                    Trigger = ItemToken["trigger"].ToString();
            }
        }

        public class WeaponInfo
        {
            public class Damage
            {
                public int Minimum { get; internal set; }

                public int Maximum { get; internal set; }

                public double ExactMinimum { get; internal set; }

                public double ExactMaximum { get; internal set; }

                public Damage(JToken DamageToken)
                {
                    Minimum = int.Parse(DamageToken["min"].ToString());
                    Maximum = int.Parse(DamageToken["max"].ToString());
                    ExactMinimum = double.Parse(DamageToken["exactMin"].ToString());
                    ExactMaximum = double.Parse(DamageToken["exactMax"].ToString());
                }
            }

            public Damage WeaponDamage { get; internal set; }

            public double WeaponSpeed { get; internal set; }

            public float DPS { get; internal set; }

            public WeaponInfo(JToken WeaponInfoToken)
            {
                if (WeaponInfoToken["damage"] != null)
                    WeaponDamage = new Damage(WeaponInfoToken["damage"]);
                if (WeaponInfoToken["weaponSpeed"] != null)
                    WeaponSpeed = double.Parse(WeaponInfoToken["weaponSpeed"].ToString());
                if (WeaponInfoToken["dps"] != null)
                    DPS = float.Parse(WeaponInfoToken["dps"].ToString());
            }
        }

        public class Source
        {
            public int SourceID { get; internal set; }

            public string SourceType { get; internal set; }

            public Source(JToken SourceToken)
            {
                if (SourceToken["sourceId"] != null)
                    SourceID = int.Parse(SourceToken["sourceId"].ToString());
                if (SourceToken["sourceType"] != null)
                    SourceType = SourceToken["sourceType"].ToString();
            }
        }

        public class Bonus
        {
            public class BonusChance
            {
                public string ChanceType { get; internal set; }

                public List<ItemStat> Stats { get; internal set; }

                public object Sockets { get; internal set; }

                public BonusChance(JToken BonusToken)
                {
                    if (BonusToken["chanceType"] != null)
                        ChanceType = BonusToken["chanceType"].ToString();
                    if (BonusToken["stats"] != null && BonusToken["stats"].HasValues)
                    {
                        Stats = new List<ItemStat>();
                        foreach (JToken StatToken in BonusToken["stats"])
                        {
                            ItemStat stat = new ItemStat(StatToken);
                            Stats.Add(stat);
                        }
                    }
                    if (BonusToken["sockets"] != null)
                        Sockets = BonusToken["sockets"];
                }
            }

            public List<int> DefaultBonusList { get; internal set; }

            public List<int> ChanceBonusList { get; internal set; }

            public List<BonusChance> BonusChances { get; internal set; }

            public Bonus(JToken BonusToken)
            {
                if (BonusToken["defaultBonusLists"] != null && BonusToken["defaultBonusLists"].HasValues)
                {
                    DefaultBonusList = new List<int>();
                    foreach (int BonusInt in BonusToken["defaultBonusLists"])
                    {
                        DefaultBonusList.Add(BonusInt);
                    }
                }
                if (BonusToken["chanceBonusLists"] != null && BonusToken["chanceBonusLists"].HasValues)
                {
                    ChanceBonusList = new List<int>();
                    foreach (int BonusInt in BonusToken["chanceBonusLists"])
                    {
                        ChanceBonusList.Add(BonusInt);
                    }
                }
                if (BonusToken["bonusChances"] != null && BonusToken["bonusChances"].HasValues)
                {
                    BonusChances = new List<BonusChance>();

                    foreach (JToken ChanceToken in BonusToken["bonusChances"])
                    {
                        BonusChance chance = new BonusChance(ChanceToken);
                        BonusChances.Add(chance);
                    }
                }
            }
        }

        public class TooltipParameters
        {
            public class TooltipUpgrade
            {
                public int Current { get; internal set; }

                public int Total { get; internal set; }

                public int ItemLevelIncrement { get; internal set; }

                public TooltipUpgrade(JToken UpgradeToken)
                {
                    if (UpgradeToken["current"] != null)
                        Current = int.Parse(UpgradeToken["current"].ToString());
                    if (UpgradeToken["total"] != null)
                        Total = int.Parse(UpgradeToken["total"].ToString());
                    if (UpgradeToken["itemLevelIncrement"] != null)
                        ItemLevelIncrement = int.Parse(UpgradeToken["itemLevelIncrement"].ToString());
                }

            }

            public TooltipUpgrade Upgrade { get; internal set; }

            public int TimewalkingLevel { get; internal set; }

            public TooltipParameters(JToken TooltipToken)
            {
                if (TooltipToken["upgrade"] != null)
                    Upgrade = new TooltipUpgrade(TooltipToken["upgrade"]);
                if (TooltipToken["timewalkerLevel"] != null)
                    TimewalkingLevel = int.Parse(TooltipToken["timewalkerLevel"].ToString());
            }
        }

        public int ID { get; internal set; }

        public int DisenchantingLevel { get; internal set; }

        public string Description { get; internal set; }

        public string Name { get; internal set; }

        public string Icon { get; internal set; }

        public int Stackable { get; internal set; }

        public int ItemBound { get; internal set; }

        public List<ItemStat> BonusStats { get; internal set; }

        public List<ItemSpell> ItemSpells { get; internal set; }

        public int BuyPrice { get; internal set; }

        public int ItemClass { get; internal set; }

        public int ItemSubClass { get; internal set; }

        public int ContainerSlots { get; internal set; }

        public WeaponInfo WeaponInfomation { get; internal set; }

        public int InventoryType { get; internal set; }

        public bool IsEquippable { get; internal set; }

        public int ItemLevel { get; internal set; }

        public int MaxCount { get; internal set; }

        public int MaxDurability { get; internal set; }

        public int MinimumFactionID { get; internal set; }

        public int MinimumReputation { get; internal set; }

        public int Quality { get; internal set; }

        public int SellPrice { get; internal set; }

        public int RequiredSkill { get; internal set; }

        public int RequiredLevel { get; internal set; }

        public int RequiredSkillLevel { get; internal set; }

        public Source ItemSource { get; internal set; }

        public int BaseArmour { get; internal set; }

        public bool HasSockets { get; internal set; }

        public bool CanBeAuctioned { get; internal set; }

        public int Armour { get; internal set; }

        public int DisplayInfoID { get; internal set; }

        public string NameDescription { get; internal set; }

        public string NameDescriptionColour { get; internal set; }

        public bool CanBeUpgraded { get; internal set; }

        public bool HeroicTooltip { get; internal set; }
        public string Context { get; internal set; }

        public List<int> BonusLists { get; internal set; }

        public List<string> AvailableContexts { get; internal set; }

        public Bonus BonusSummary { get; internal set; }

        public TooltipParameters TooltipParams { get; internal set; }


        #region Artifact Info
        public class ArtifactTraits
        {
            public int ID { get; internal set; }

            public int Rank { get; internal set; }

            public ArtifactTraits(JObject TraitObject)
            {
                if (TraitObject["id"] != null)
                    ID = int.Parse(TraitObject["id"].ToString());
                if (TraitObject["rank"] != null)
                    Rank = int.Parse(TraitObject["rank"].ToString());
            }
        }

        public class ArtifactRelic
        {
            public int Socket { get; internal set; }

            public int RelicID { get; internal set; }

            public int Context { get; internal set; }

            public List<int> BonusList { get; internal set; }

            public ArtifactRelic(JObject RelicObject)
            {
                if (RelicObject["socket"] != null)
                    Socket = int.Parse(RelicObject["socket"].ToString());
                if (RelicObject["itemId"] != null)
                    RelicID = int.Parse(RelicObject["itemId"].ToString());
                if (RelicObject["context"] != null)
                    Context = int.Parse(RelicObject["context"].ToString());
                if (RelicObject["bonusLists"] != null && RelicObject["bonusLists"].HasValues)
                {
                    BonusList = new List<int>();

                    foreach (int bonus in RelicObject["bonusLists"])
                    {
                        BonusList.Add(bonus);
                    }
                }
            }
        }
        public int ArtifactID { get; internal set; }

        public int ArtifactAppearanceID { get; internal set; }

        public List<ArtifactTraits> TraitList { get; internal set; }

        public List<ArtifactRelic> RelicList { get; internal set; }

        #endregion

        public class Appearance
        {
            public int ItemID { get; internal set; }

            public int ItemAppearanceModID { get; internal set; }

            public int TransmogItemAppearanceID { get; internal set; }

            public Appearance(JObject AppearObject)
            {
                if (AppearObject["itemId"] != null)
                    ItemID = int.Parse(AppearObject["itemId"].ToString());
                if (AppearObject["itemAppearanceModId"] != null)
                    ItemAppearanceModID = int.Parse(AppearObject["itemAppearanceModId"].ToString());
                if (AppearObject["transmogItemAppearanceModId"] != null)
                    TransmogItemAppearanceID = int.Parse(AppearObject["transmogItemAppearanceModId"].ToString());
            }
        }

        public Appearance ItemAppearance { get; internal set; }

        public Item(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = int.Parse(rawData["id"].ToString());
            if (rawData["disenchantingSkillRank"] != null)
                DisenchantingLevel = int.Parse(rawData["disenchantingSkillRank"].ToString());
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["stackable"] != null)
                Stackable = int.Parse(rawData["stackable"].ToString());
            if (rawData["itemBind"] != null)
                ItemBound = int.Parse(rawData["itemBind"].ToString());
            if (rawData["bonusStats"] != null && rawData["bonusStats"].HasValues)
            {
                BonusStats = new List<ItemStat>();

                foreach (JToken BonusToken in rawData["bonusStats"])
                {
                    ItemStat stat = new ItemStat(BonusToken);
                    BonusStats.Add(stat);
                }
            }
            if (rawData["itemSpells"] != null && rawData["itemSpells"].HasValues)
            {
                ItemSpells = new List<ItemSpell>();

                foreach (JToken SpellToken in rawData["itemSpells"])
                {
                    ItemSpell spell = new ItemSpell(SpellToken);
                    ItemSpells.Add(spell);
                }
            }
            if (rawData["buyPrice"] != null)
                BuyPrice = int.Parse(rawData["buyPrice"].ToString());
            if (rawData["itemClass"] != null)
                ItemClass = int.Parse(rawData["itemClass"].ToString());
            if (rawData["itemSubClass"] != null)
                ItemSubClass = int.Parse(rawData["itemSubClass"].ToString());
            if (rawData["containerSlots"] != null)
                ContainerSlots = int.Parse(rawData["containerSlots"].ToString());
            if (rawData["weaponInfo"] != null)
                WeaponInfomation = new WeaponInfo(rawData["weaponInfo"]);
            if (rawData["inventoryType"] != null)
                InventoryType = int.Parse(rawData["inventoryType"].ToString());
            if (rawData["equippable"] != null)
                IsEquippable = bool.Parse(rawData["equippable"].ToString());
            if (rawData["itemLevel"] != null)
                ItemLevel = int.Parse(rawData["itemLevel"].ToString());
            if (rawData["maxCount"] != null)
                MaxCount = int.Parse(rawData["maxCount"].ToString());
            if (rawData["maxDurability"] != null)
                MaxDurability = int.Parse(rawData["maxDurability"].ToString());
            if (rawData["minFactionId"] != null)
                MinimumFactionID = int.Parse(rawData["minFactionId"].ToString());
            if (rawData["minReputation"] != null)
                MinimumReputation = int.Parse(rawData["minReputation"].ToString());
            if (rawData["quality"] != null)
                Quality = int.Parse(rawData["quality"].ToString());
            if (rawData["sellPrice"] != null)
                SellPrice = int.Parse(rawData["sellPrice"].ToString());
            if (rawData["requiredSkill"] != null)
                RequiredSkill = int.Parse(rawData["requiredSkill"].ToString());
            if (rawData["requiredLevel"] != null)
                RequiredLevel = int.Parse(rawData["requiredLevel"].ToString());
            if (rawData["requiredSkillRank"] != null)
                RequiredSkillLevel = int.Parse(rawData["requiredSkillRank"].ToString());
            if (rawData["itemSource"] != null)
                ItemSource = new Source(rawData["itemSource"]);
            if (rawData["baseArmor"] != null)
                BaseArmour = int.Parse(rawData["baseArmor"].ToString());
            if (rawData["hasSockets"] != null)
                HasSockets = bool.Parse(rawData["hasSockets"].ToString());
            if (rawData["isAuctionable"] != null)
                CanBeAuctioned = bool.Parse(rawData["isAuctionable"].ToString());
            if (rawData["armor"] != null)
                Armour = int.Parse(rawData["armor"].ToString());
            if (rawData["displayInfoId"] != null)
                DisplayInfoID = int.Parse(rawData["displayInfoId"].ToString());
            if (rawData["nameDescription"] != null)
                NameDescription = rawData["nameDescription"].ToString();
            if (rawData["nameDescriptionColor"] != null)
                NameDescriptionColour = rawData["nameDescriptionColor"].ToString();
            if (rawData["upgradable"] != null)
                CanBeUpgraded = bool.Parse(rawData["upgradable"].ToString());
            if (rawData["heroicTooltip"] != null)
                HeroicTooltip = bool.Parse(rawData["heroicTooltip"].ToString());
            if (rawData["context"] != null)
                Context = rawData["context"].ToString();
            if (rawData["bonusLists"] != null && rawData["bonusLists"].HasValues)
            {
                BonusLists = new List<int>();

                foreach (int ID in rawData["bonusLists"])
                {
                    BonusLists.Add(ID);
                }
            }
            if (rawData["availableContexts"] != null && rawData["availableContexts"].HasValues)
            {
                AvailableContexts = new List<string>();

                foreach (string Context in rawData["availableContexts"])
                {
                    AvailableContexts.Add(Context);
                }
            }
            if (rawData["bonusSummary"] != null)
                BonusSummary = new Bonus(rawData["bonusSummary"]);
            if (rawData["tooltipParams"] != null)
                TooltipParams = new TooltipParameters(rawData["tooltipParams"]);
            if (rawData["artifactId"] != null)
                ArtifactID = int.Parse(rawData["artifactId"].ToString());
            if (rawData["artifactAppearanceId"] != null)
                ArtifactAppearanceID = int.Parse(rawData["artifactAppearanceId"].ToString());
            if (rawData["artifactTraits"] != null && rawData["artifactTraits"].HasValues)
            {
                TraitList = new List<ArtifactTraits>();

                foreach (JObject trait in rawData["artifactTraits"])
                {
                    TraitList.Add(new ArtifactTraits(trait));
                }
            }
            if (rawData["relics"] != null && rawData["relics"].HasValues)
            {
                RelicList = new List<ArtifactRelic>();

                foreach (JObject relic in rawData["relics"])
                {
                    RelicList.Add(new ArtifactRelic(relic));
                }
            }
            if (rawData["appearance"] != null)
                ItemAppearance = new Appearance(JObject.Parse(rawData["appearance"].ToString()));


        }

    }
}
