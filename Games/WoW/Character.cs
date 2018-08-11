using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Character
    {
        #region Character Achievements
        public class CharacterAchievements
        {
            public List<int> AchievementsCompleted { get; internal set; }

            public List<long> AchievementsCompletedTime { get; internal set; }

            public List<int> Criteria { get; internal set; }

            public List<Int64> CriteriaQuantity { get; internal set; }

            public List<long> CriteriaTime { get; internal set; }

            public List<long> CriteriaCreated { get; internal set; }

            public CharacterAchievements(JToken AchievementsToken)
            {
                if (AchievementsToken["achievementsCompleted"] != null && AchievementsToken["achievementsCompleted"].HasValues)
                {
                    AchievementsCompleted = new List<int>();
                    foreach (int AchievementObject in AchievementsToken["achievementsCompleted"])
                    {
                        AchievementsCompleted.Add(AchievementObject);
                    }
                }

                if (AchievementsToken["achievementsCompletedTimestamp"] != null && AchievementsToken["achievementsCompletedTimestamp"].HasValues)
                {
                    AchievementsCompletedTime = new List<long>();
                    foreach (long AchievementCompleteTimeStampObject in AchievementsToken["achievementsCompletedTimestamp"])
                    {
                        AchievementsCompletedTime.Add(AchievementCompleteTimeStampObject);
                    }
                }

                if (AchievementsToken["criteria"] != null && AchievementsToken["criteria"].HasValues)
                {
                    Criteria = new List<int>();
                    foreach (int JCriteria in AchievementsToken["criteria"])
                    {
                        Criteria.Add(JCriteria);
                    }
                }

                if (AchievementsToken["criteriaQuantity"] != null && AchievementsToken["criteriaQuantity"].HasValues)
                {
                    CriteriaQuantity = new List<Int64>();
                    foreach (Int64 CriteriaQuantityObject in AchievementsToken["criteriaQuantity"])
                    {
                        CriteriaQuantity.Add(CriteriaQuantityObject);
                    }
                }

                if (AchievementsToken["criteriaTimestamp"] != null && AchievementsToken["criteriaTimestamp"].HasValues)
                {
                    CriteriaTime = new List<long>();
                    foreach (long CriteriaTimeObject in AchievementsToken["criteriaTimestamp"])
                    {
                        CriteriaTime.Add(CriteriaTimeObject);
                    }
                }

                if (AchievementsToken["criteriaCreated"] != null && AchievementsToken["criteriaCreated"].HasValues)
                {
                    CriteriaCreated = new List<long>();
                    foreach (long CriteriaCreatedObject in AchievementsToken["criteriaCreated"])
                    {
                        CriteriaCreated.Add(CriteriaCreatedObject);
                    }
                }
            }
        }
        #endregion

        #region Character Appearance

        public class Appearance
        {
            public int FaceVariationID { get; internal set; }

            public int SkinColourID { get; internal set; }

            public int HairVariationID { get; internal set; }

            public int HairColourID { get; internal set; }

            public int FeatureVariationID { get; internal set; }

            public bool HelmHidden { get; internal set; }

            public bool CloakHidden { get; internal set; }

            public Appearance(JToken AppearanceToken)
            {
                if (AppearanceToken["faceVariation"] != null)
                    FaceVariationID = int.Parse(AppearanceToken["faceVariation"].ToString());
                if (AppearanceToken["skinColor"] != null)
                    SkinColourID = int.Parse(AppearanceToken["skinColor"].ToString());
                if (AppearanceToken["hairVariation"] != null)
                    HairVariationID = int.Parse(AppearanceToken["hairVariation"].ToString());
                if (AppearanceToken["hairColor"] != null)
                    HairColourID = int.Parse(AppearanceToken["hairColor"].ToString());
                if (AppearanceToken["featureVariation"] != null)
                    FeatureVariationID = int.Parse(AppearanceToken["featureVariation"].ToString());
                if (AppearanceToken["showHelm"] != null)
                    HelmHidden = bool.Parse(AppearanceToken["showHelm"].ToString());
                if (AppearanceToken["showCloak"] != null)
                    CloakHidden = bool.Parse(AppearanceToken["showCloak"].ToString());
            }
        }
        #endregion

        #region Character Feed

        public class Feed
        {
            public string Type { get; internal set; }

            public long Time { get; internal set; }

            public int ItemID { get; internal set; }

            public string Context { get; internal set; }

            public List<int> BonusList { get; internal set; }

            public Achievement Achievement { get; internal set; }

            public bool FeatOfStrength { get; internal set; }

            public Achievement Criteria { get; internal set; }

            public int Quantity { get; internal set; }

            public string Name { get; internal set; }

            public Feed(JToken FeedToken)
            {
                if (FeedToken["type"] != null)
                    Type = FeedToken["type"].ToString();
                if (FeedToken["timestamp"] != null)
                    Time = long.Parse(FeedToken["timestamp"].ToString());
                if (FeedToken["itemId"] != null)
                    ItemID = int.Parse(FeedToken["itemId"].ToString());
                if (FeedToken["context"] != null)
                    Context = FeedToken["context"].ToString();
                if (FeedToken["bonusLists"] != null && FeedToken["bonusLists"].HasValues)
                {
                    BonusList = new List<int>();
                    foreach (int BonusObject in FeedToken["bonusLists"])
                    {
                        BonusList.Add(BonusObject);
                    }
                }
                if (FeedToken["achievement"] != null && FeedToken["achievement"].HasValues)
                    Achievement = new Achievement(JObject.Parse(FeedToken["achievement"].ToString()));
                if (FeedToken["featOfStrength"] != null)
                    FeatOfStrength = bool.Parse(FeedToken["featOfStrength"].ToString());
                if (FeedToken["criteria"] != null)
                    Criteria = new Achievement(JObject.Parse(FeedToken["criteria"].ToString()));
                if (FeedToken["quantity"] != null)
                    Quantity = int.Parse(FeedToken["quantity"].ToString());
                if (FeedToken["name"] != null)
                    Name = FeedToken["name"].ToString();
            }
        }
        #endregion

       

        #region Character Professions

        public class Profession
        {
            public class Skill
            {
                public int ProfessionID { get; internal set; }

                public string Name { get; internal set; }

                public string Icon { get; internal set; }

                public int Rank { get; internal set; }

                public int Max { get; internal set; }

                public List<int> RecipeList { get; internal set; }

                public Skill(JObject ProfessionObject)
                {
                    RecipeList = new List<int>();
                    if (ProfessionObject["id"] != null)
                        ProfessionID = int.Parse(ProfessionObject["id"].ToString());
                    if (ProfessionObject["name"] != null)
                        Name = ProfessionObject["name"].ToString();
                    if (ProfessionObject["icon"] != null)
                        Icon = ProfessionObject["icon"].ToString();
                    if (ProfessionObject["rank"] != null)
                        Rank = int.Parse(ProfessionObject["rank"].ToString());
                    if (ProfessionObject["max"] != null)
                        Max = int.Parse(ProfessionObject["max"].ToString());
                    if (ProfessionObject["recipes"] != null && ProfessionObject["recipes"].HasValues)
                    {

                        foreach (int RecipeObject in ProfessionObject["recipes"])
                        {
                            RecipeList.Add(RecipeObject);
                        }
                    }

                }

            }



            public List<Skill> PrimaryProfessions { get; internal set; }

            public List<Skill> SecondaryProfessions { get; internal set; }

            public Profession(JObject ProfessionObject)
            {
                if (ProfessionObject["primary"] != null && ProfessionObject["primary"].HasValues)
                {
                    PrimaryProfessions = new List<Skill>();

                    foreach (JObject primary in ProfessionObject["primary"])
                    {
                        Skill primeProf = new Skill(primary);
                        PrimaryProfessions.Add(primeProf);
                    }
                }
                if (ProfessionObject["secondary"] != null && ProfessionObject["secondary"].HasValues)
                {
                    SecondaryProfessions = new List<Skill>();

                    foreach (JObject secondary in ProfessionObject["secondary"])
                    {
                        Skill secondaryProf = new Skill(secondary);
                        SecondaryProfessions.Add(secondaryProf);
                    }
                }
            }



        }
        #endregion

        #region Character Guild

        public class CharacterGuild
        {
            public string Name { get; internal set; }

            public string Realm { get; internal set; }

            public string Battlegroup { get; internal set; }

            public int MemberCount { get; internal set; }

            public int AchievementPoints { get; internal set; }

            public CharacterGuild(JToken GuildToken)
            {
                if (GuildToken["name"] != null)
                    Name = GuildToken["name"].ToString();
                if (GuildToken["realm"] != null)
                    Realm = GuildToken["realm"].ToString();
                if (GuildToken["battlegroup"] != null)
                    Battlegroup = GuildToken["battlegroup"].ToString();
                if (GuildToken["members"] != null)
                    MemberCount = int.Parse(GuildToken["members"].ToString());
                if (GuildToken["achievementPoints"] != null)
                    AchievementPoints = int.Parse(GuildToken["achievementPoints"].ToString());
            }
        }
        #endregion

        #region Character Hunter Pets

        public class HunterPets
        {
            public string Name { get; internal set; }

            public int CreatureID { get; internal set; }

            public int SlotID { get; internal set; }

            public PetSpec Spec { get; internal set; }

            public string CalcSpec { get; internal set; }

            public int FamilyID { get; internal set; }

            public string FamilyName { get; internal set; }

            public HunterPets(JObject HunterObject)
            {
                if (HunterObject["name"] != null)
                    Name = HunterObject["name"].ToString();
                if (HunterObject["creature"] != null)
                    CreatureID = int.Parse(HunterObject["creature"].ToString());
                if (HunterObject["slot"] != null)
                    SlotID = int.Parse(HunterObject["slot"].ToString());
                if (HunterObject["spec"] != null)
                    Spec = new PetSpec(JObject.Parse(HunterObject["spec"].ToString()));
                if (HunterObject["calcSpec"] != null)
                    CalcSpec = HunterObject["calcSpec"].ToString();
                if (HunterObject["familyId"] != null)
                    FamilyID = int.Parse(HunterObject["familyId"].ToString());
                if (HunterObject["familyName"] != null)
                    FamilyName = HunterObject["familyName"].ToString();
            }

        }

        public class PetSpec
        {
            public string Name { get; internal set; }

            public string Role { get; internal set; }

            public string BackgroundImage { get; internal set; }

            public string Icon { get; internal set; }

            public string Description { get; internal set; }

            public int Order { get; internal set; }

            public PetSpec(JObject PetSpecObject)
            {
                if (PetSpecObject["name"] != null)
                    Name = PetSpecObject["name"].ToString();
                if (PetSpecObject["role"] != null)
                    Role = PetSpecObject["role"].ToString();
                if (PetSpecObject["backgroundImage"] != null)
                    BackgroundImage = PetSpecObject["backgroundImage"].ToString();
                if (PetSpecObject["icon"] != null)
                    Icon = PetSpecObject["icon"].ToString();
                if (PetSpecObject["description"] != null)
                    Description = PetSpecObject["description"].ToString();
                if (PetSpecObject["order"] != null)
                    Order = int.Parse(PetSpecObject["order"].ToString());
            }

        }

        #endregion

        #region Equipped Items

        public class EquippedItem
        {

            public int AverageItemLevel { get; internal set; }

            public int AverageEquippedItemLevel { get; internal set; }

            public Item Head { get; internal set; }

            public Item Neck { get; internal set; }

            public Item Shoulders { get; internal set; }

            public Item Back { get; internal set; }

            public Item Chest { get; internal set; }

            public Item Wrist { get; internal set; }

            public Item Hands { get; internal set; }

            public Item Waist { get; internal set; }

            public Item Legs { get; internal set; }

            public Item Feet { get; internal set; }

            public Item Ring1 { get; internal set; }

            public Item Ring2 { get; internal set; }

            public Item Trinket1 { get; internal set; }

            public Item Trinket2 { get; internal set; }

            public Item MainHandWeapon { get; internal set; }

            public Item OffHandWeapon { get; internal set; }

            public EquippedItem(JObject EquippedObject)
            {
                if (EquippedObject["averageItemLevel"] != null)
                    AverageItemLevel = int.Parse(EquippedObject["averageItemLevel"].ToString());
                if (EquippedObject["averageItemLevelEquipped"] != null)
                    AverageEquippedItemLevel = int.Parse(EquippedObject["averageItemLevelEquipped"].ToString());
                if (EquippedObject["head"] != null)
                    Head = new Item(JObject.Parse(EquippedObject["head"].ToString()));
                if (EquippedObject["neck"] != null)
                    Neck = new Item(JObject.Parse(EquippedObject["neck"].ToString()));
                if (EquippedObject["shoulder"] != null)
                    Shoulders = new Item(JObject.Parse(EquippedObject["shoulder"].ToString()));
                if (EquippedObject["back"] != null)
                    Back = new Item(JObject.Parse(EquippedObject["back"].ToString()));
                if (EquippedObject["chest"] != null)
                    Chest = new Item(JObject.Parse(EquippedObject["chest"].ToString()));
                if (EquippedObject["wrist"] != null)
                    Wrist = new Item(JObject.Parse(EquippedObject["wrist"].ToString()));
                if (EquippedObject["hands"] != null)
                    Hands = new Item(JObject.Parse(EquippedObject["hands"].ToString()));
                if (EquippedObject["waist"] != null)
                    Waist = new Item(JObject.Parse(EquippedObject["waist"].ToString()));
                if (EquippedObject["legs"] != null)
                    Legs = new Item(JObject.Parse(EquippedObject["legs"].ToString()));
                if (EquippedObject["feet"] != null)
                    Feet = new Item(JObject.Parse(EquippedObject["feet"].ToString()));
                if (EquippedObject["finger1"] != null)
                    Ring1 = new Item(JObject.Parse(EquippedObject["finger1"].ToString()));
                if (EquippedObject["finger2"] != null)
                    Ring2 = new Item(JObject.Parse(EquippedObject["finger2"].ToString()));
                if (EquippedObject["trinket1"] != null)
                    Trinket1 = new Item(JObject.Parse(EquippedObject["trinket1"].ToString()));
                if (EquippedObject["trinket2"] != null)
                    Trinket2 = new Item(JObject.Parse(EquippedObject["trinket2"].ToString()));
                if (EquippedObject["mainHand"] != null)
                    MainHandWeapon = new Item(JObject.Parse(EquippedObject["mainHand"].ToString()));
                if (EquippedObject["offHand"] != null)
                    OffHandWeapon = new Item(JObject.Parse(EquippedObject["offHand"].ToString()));
            }


        }
        #endregion

        #region Mounts

        public class Mounts
        {
            public int Collected { get; internal set; }

            public int NotCollected { get; internal set; }

            public List<Mount> CollectedList { get; internal set; }

            public Mounts(JObject MountObject)
            {
                if (MountObject["numCollected"] != null)
                    Collected = int.Parse(MountObject["numCollected"].ToString());
                if (MountObject["numNotCollected"] != null)
                    NotCollected = int.Parse(MountObject["numNotCollected"].ToString());
                if (MountObject["collected"] != null && MountObject["collected"].HasValues)
                {
                    CollectedList = new List<Mount>();
                    foreach (JObject mountObject in MountObject["collected"])
                    {
                        Mount mount = new Mount(mountObject);
                        CollectedList.Add(mount);
                    }
                }
            }
        }
        #endregion

        #region Character Pets

        public class Pets
        {
            public int Collected { get; internal set; }

            public int NotCollected { get; internal set; }

            public List<Pet> CollectedList { get; internal set; }

            public Pets(JObject PetObject)
            {
                if (PetObject["numCollected"] != null)
                    Collected = int.Parse(PetObject["numCollected"].ToString());
                if (PetObject["numNotCollected"] != null)
                    NotCollected = int.Parse(PetObject["numNotCollected"].ToString());
                if (PetObject["collected"] != null && PetObject["collected"].HasValues)
                {
                    JArray petArray = JArray.Parse(PetObject["collected"].ToString());
                    CollectedList = new List<Pet>();
                    foreach (JObject petObject in petArray)
                    {
                        Pet pet = new Pet(petObject);
                        CollectedList.Add(pet);
                    }
                }
            }

        }
        #endregion

        #region Character Pet Slots

        public class PetSlots
        {
            public int SlotID { get; internal set; }

            public bool IsLocked { get; internal set; }

            public bool IsEmpty { get; internal set; }

            public List<int> Abilities { get; internal set; }

            public PetSlots(JToken PetSlotToken)
            {
                if (PetSlotToken["slot"] != null)
                    SlotID = int.Parse(PetSlotToken["slot"].ToString());
                if (PetSlotToken["isEmpty"] != null)
                    IsEmpty = bool.Parse(PetSlotToken["isEmpty"].ToString());
                if (PetSlotToken["isLocked"] != null)
                    IsLocked = bool.Parse(PetSlotToken["isLocked"].ToString());
                if (PetSlotToken["abilities"] != null && PetSlotToken["abilities"].HasValues)
                {
                    Abilities = new List<int>();
                    foreach (int AbilityObject in PetSlotToken["abilities"])
                    {
                        Abilities.Add(AbilityObject);
                    }
                }
            }
        }
        #endregion

        #region Character Progression

        public class Progression
        {
            public List<Raid> RaidList { get; internal set; }

            public Progression(JObject ProgressionObject)
            {
                if (ProgressionObject["raids"] != null && ProgressionObject["raids"].HasValues)
                {

                    RaidList = new List<Raid>();
                    foreach (JToken RaidToken in ProgressionObject["raids"])
                    {
                        Raid raid = new Raid(RaidToken);
                        RaidList.Add(raid);
                    }
                }
            }
        }
        #endregion

        #region Character PVP
        public class CharacterPvP
        {
            public class PvPBracket
            {
                public string Slug { get; internal set; }

                public int Rating { get; internal set; }

                public int WeeklyPlayed { get; internal set; }

                public int WeeklyWon { get; internal set; }

                public int WeeklyLost { get; internal set; }

                public int SeasonPlayed { get; internal set; }

                public int SeasonWon { get; internal set; }

                public int SeasonLost { get; internal set; }

                public PvPBracket(JToken BracketObject)
                {
                    if (BracketObject["slug"] != null)
                        Slug = BracketObject["slug"].ToString();
                    if (BracketObject["rating"] != null)
                        Rating = int.Parse(BracketObject["rating"].ToString());
                    if (BracketObject["weeklyPlayed"] != null)
                        WeeklyPlayed = int.Parse(BracketObject["weeklyPlayed"].ToString());
                    if (BracketObject["weeklyWon"] != null)
                        WeeklyWon = int.Parse(BracketObject["weeklyWon"].ToString());
                    if (BracketObject["weeklyLost"] != null)
                        WeeklyLost = int.Parse(BracketObject["weeklyLost"].ToString());
                    if (BracketObject["seasonPlayed"] != null)
                        SeasonPlayed = int.Parse(BracketObject["seasonPlayed"].ToString());
                    if (BracketObject["seasonWon"] != null)
                        SeasonWon = int.Parse(BracketObject["seasonWon"].ToString());
                    if (BracketObject["seasonLost"] != null)
                        SeasonLost = int.Parse(BracketObject["seasonLost"].ToString());

                }
            }
            public PvPBracket Arena2v2 { get; internal set; }
            public PvPBracket Arena3v3 { get; internal set; }
            public PvPBracket ArenaRBG { get; internal set; }
            public PvPBracket Arena2v2Skirmish { get; internal set; }
            public PvPBracket Unknown { get; internal set; }


            public CharacterPvP(JObject PvPObject)
            {
                if (PvPObject["brackets"]["ARENA_BRACKET_2v2"] != null && PvPObject["brackets"]["ARENA_BRACKET_2v2"].HasValues)
                    Arena2v2 = new PvPBracket(PvPObject["brackets"]["ARENA_BRACKET_2v2"]);
                if (PvPObject["brackets"]["ARENA_BRACKET_3v3"] != null && PvPObject["brackets"]["ARENA_BRACKET_3v3"].HasValues)
                    Arena3v3 = new PvPBracket(PvPObject["brackets"]["ARENA_BRACKET_3v3"]);
                if (PvPObject["brackets"]["ARENA_BRACKET_RBG"] != null && PvPObject["brackets"]["ARENA_BRACKET_RBG"].HasValues)
                    ArenaRBG = new PvPBracket(PvPObject["brackets"]["ARENA_BRACKET_RBG"]);
                if (PvPObject["brackets"]["ARENA_BRACKET_2v2_SKIRMISH"] != null && PvPObject["brackets"]["ARENA_BRACKET_2v2_SKIRMISH"].HasValues)
                    Arena2v2Skirmish = new PvPBracket(PvPObject["brackets"]["ARENA_BRACKET_2v2_SKIRMISH"]);
                if (PvPObject["brackets"]["UNKNOWN"] != null && PvPObject["brackets"]["UNKNOWN"].HasValues)
                    Unknown = new PvPBracket(PvPObject["brackets"]["UNKNOWN"]);


            }
        }


        #endregion

        #region Character Quests

        public class Quests
        {
            public List<int> CompletedQuestList { get; internal set; }

            public Quests(JToken QuestsToken)
            {

                CompletedQuestList = new List<int>();
                if (QuestsToken["quests"] != null && QuestsToken["quests"].HasValues)
                {
                    foreach (int QuestInt in QuestsToken["quests"])
                    {
                        CompletedQuestList.Add(QuestInt);
                    }
                }
            }
        }
        #endregion

        #region Character Reputation

        public class Reputation
        {
            public int ReputationID { get; internal set; }

            public string Name { get; internal set; }

            public int Standing { get; internal set; }

            public int Value { get; internal set; }

            public int Max { get; internal set; }

            public Reputation(JToken ReputationToken)
            {
                if (ReputationToken["id"] != null)
                    ReputationID = int.Parse(ReputationToken["id"].ToString());
                if (ReputationToken["name"] != null)
                    Name = ReputationToken["name"].ToString();
                if (ReputationToken["standing"] != null)
                    Standing = int.Parse(ReputationToken["standing"].ToString());
                if (ReputationToken["value"] != null)
                    Value = int.Parse(ReputationToken["value"].ToString());
                if (ReputationToken["max"] != null)
                    Max = int.Parse(ReputationToken["max"].ToString());
            }
        }
        #endregion

        #region Character Statistics
        public class Statistics
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public List<StatisticSubCategory> CategoryList { get; internal set; }

            public Statistics(JObject StatisticObject)
            {
                if (StatisticObject["id"] != null)
                    ID = int.Parse(StatisticObject["id"].ToString());
                if (StatisticObject["name"] != null)
                    Name = StatisticObject["name"].ToString();
                if (StatisticObject["subCategories"] != null && StatisticObject["subCategories"].HasValues)
                {
                    CategoryList = new List<StatisticSubCategory>();

                    foreach (JToken StatToken in StatisticObject["subCategories"])
                    {
                        StatisticSubCategory sub = new StatisticSubCategory(StatToken);
                        CategoryList.Add(sub);
                    }
                }
            }
        }

        public class StatisticSubCategory
        {
            public int CategoryID { get; internal set; }

            public string Name { get; internal set; }

            public List<Statistic> StatisticList { get; internal set; }

            public StatisticSubCategory(JToken CategoryToken)
            {
                if (CategoryToken["id"] != null)
                    CategoryID = int.Parse(CategoryToken["id"].ToString());
                if (CategoryToken["name"] != null)
                    Name = CategoryToken["name"].ToString();
                if (CategoryToken["statistics"] != null && CategoryToken["statistics"].HasValues)
                {
                    StatisticList = new List<Statistic>();

                    foreach (JObject StatisticObject in CategoryToken["statistics"])
                    {
                        Statistic stat = new Statistic(StatisticObject);
                        StatisticList.Add(stat);
                    }
                }
            }
        }

        public class Statistic
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public long Quantity { get; internal set; }

            public long LastUpdated { get; internal set; }

            public string Highest { get; internal set; }

            public bool IsMoney { get; internal set; }

            public Statistic(JObject StatisticObject)
            {
                if (StatisticObject["id"] != null)
                    ID = int.Parse(StatisticObject["id"].ToString());
                if (StatisticObject["name"] != null)
                    Name = StatisticObject["name"].ToString();
                if (StatisticObject["quantity"] != null)
                    Quantity = long.Parse(StatisticObject["quantity"].ToString());
                if (StatisticObject["lastUpdated"] != null)
                    LastUpdated = long.Parse(StatisticObject["lastUpdated"].ToString());
                if (StatisticObject["highest"] != null)
                    Highest = StatisticObject["highest"].ToString();
                if (StatisticObject["money"] != null)
                    IsMoney = bool.Parse(StatisticObject["money"].ToString());
            }
        }
        #endregion

        #region Character Stats and Attributes

        public class Stats
        {
            public int Health { get; internal set; }

            public string PowerType { get; internal set; }

            public int PowerMax { get; internal set; }

            public int Strength { get; internal set; }

            public int Agility { get; internal set; }

            public int Intellect { get; internal set; }

            public int Stamina { get; internal set; }

            public double SpeedRating { get; internal set; }

            public double SpeedRatingBonus { get; internal set; }

            public double CriticalStrike { get; internal set; }

            public int CriticalStrikeRating { get; internal set; }

            public double Haste { get; internal set; }

            public int HasteRating { get; internal set; }

            public double HasteRatingPercent { get; internal set; }

            public double Mastery { get; internal set; }

            public int MasteryRating { get; internal set; }

            public double Leech { get; internal set; }

            public double LeechRating { get; internal set; }

            public double LeechRatingBonus { get; internal set; }

            public int VersatilityRating { get; internal set; }

            public double VersatilityDamageBonus { get; internal set; }

            public double VersatilityHealingBonus { get; internal set; }

            public double VersatilityDamageReductionBonus { get; internal set; }

            public double Avoidance { get; internal set; }

            public double AvoidanceRatingBonus { get; internal set; }

            public int SpellPenetration { get; internal set; }

            public double SpellCriticalStrike { get; internal set; }

            public int SpellCriticalStrikeRating { get; internal set; }

            public double ManaRegeneration { get; internal set; }

            public double CombatManaRegeneration { get; internal set; }

            public int ArmourRating { get; internal set; }

            public double Dodge { get; internal set; }

            public int DodgeRating { get; internal set; }

            public double Parry { get; internal set; }

            public int ParryRating { get; internal set; }

            public double Block { get; internal set; }

            public int BlockRating { get; internal set; }

            public double MainHandWeaponDamageMinimum { get; internal set; }

            public double MainHandWeaponDamageMaximum { get; internal set; }

            public double MainHandWeaponSpeed { get; internal set; }

            public double MainHandWeaponDPS { get; internal set; }

            public double OffHandWeaponDamageMinimum { get; internal set; }

            public double OffHandWeaponDamageMaximum { get; internal set; }

            public double OffHandWeaponSpeed { get; internal set; }

            public double OffHandWeaponDPS { get; internal set; }

            public double RangedWeaponDamageMinimum { get; internal set; }

            public double RangedWeaponDamageMaximum { get; internal set; }

            public double RangedWeaponSpeed { get; internal set; }

            public double RangedWeaponDPS { get; internal set; }

            public Stats(JObject StatsObject)
            {
                if (StatsObject["health"] != null)
                    Health = int.Parse(StatsObject["health"].ToString());
                if (StatsObject["powerType"] != null)
                    PowerType = StatsObject["powerType"].ToString();
                if (StatsObject["power"] != null)
                    PowerMax = int.Parse(StatsObject["power"].ToString());
                if (StatsObject["str"] != null)
                    Strength = int.Parse(StatsObject["str"].ToString());
                if (StatsObject["agi"] != null)
                    Agility = int.Parse(StatsObject["agi"].ToString());
                if (StatsObject["int"] != null)
                    Intellect = int.Parse(StatsObject["int"].ToString());
                if (StatsObject["sta"] != null)
                    Stamina = int.Parse(StatsObject["sta"].ToString());
                if (StatsObject["speedRating"] != null)
                    SpeedRating = double.Parse(StatsObject["speedRating"].ToString());
                if (StatsObject["speedRatingBonus"] != null)
                    SpeedRatingBonus = double.Parse(StatsObject["speedRatingBonus"].ToString());
                if (StatsObject["crit"] != null)
                    CriticalStrike = double.Parse(StatsObject["crit"].ToString());
                if (StatsObject["critRating"] != null)
                    CriticalStrikeRating = int.Parse(StatsObject["critRating"].ToString());
                if (StatsObject["haste"] != null)
                    Haste = double.Parse(StatsObject["haste"].ToString());
                if (StatsObject["hasteRating"] != null)
                    HasteRating = int.Parse(StatsObject["hasteRating"].ToString());
                if (StatsObject["hasteRatingPercent"] != null)
                    HasteRatingPercent = double.Parse(StatsObject["hasteRatingPercent"].ToString());
                if (StatsObject["mastery"] != null)
                    Mastery = double.Parse(StatsObject["mastery"].ToString());
                if (StatsObject["masteryRating"] != null)
                    MasteryRating = int.Parse(StatsObject["masteryRating"].ToString());
                if (StatsObject["leech"] != null)
                    Leech = double.Parse(StatsObject["leech"].ToString());
                if (StatsObject["leechRating"] != null)
                    LeechRating = double.Parse(StatsObject["leechRating"].ToString());
                if (StatsObject["leechRatingBonus"] != null)
                    LeechRatingBonus = double.Parse(StatsObject["leechRatingBonus"].ToString());
                if (StatsObject["versatility"] != null)
                    VersatilityRating = int.Parse(StatsObject["versatility"].ToString());
                if (StatsObject["versatilityDamageDoneBonus"] != null)
                    VersatilityDamageBonus = double.Parse(StatsObject["versatilityDamageDoneBonus"].ToString());
                if (StatsObject["versatilityHealingDoneBonus"] != null)
                    VersatilityHealingBonus = double.Parse(StatsObject["versatilityHealingDoneBonus"].ToString());
                if (StatsObject["versatilityDamageTakenBonus"] != null)
                    VersatilityDamageReductionBonus = double.Parse(StatsObject["versatilityDamageTakenBonus"].ToString());
                if (StatsObject["avoidanceRating"] != null)
                    Avoidance = double.Parse(StatsObject["avoidanceRating"].ToString());
                if (StatsObject["avoidanceRatingBonus"] != null)
                    AvoidanceRatingBonus = double.Parse(StatsObject["avoidanceRatingBonus"].ToString());
                if (StatsObject["spellPen"] != null)
                    SpellPenetration = int.Parse(StatsObject["spellPen"].ToString());
                if (StatsObject["spellCrit"] != null)
                    SpellCriticalStrike = double.Parse(StatsObject["spellCrit"].ToString());
                if (StatsObject["spellCritRating"] != null)
                    SpellCriticalStrikeRating = int.Parse(StatsObject["spellCritRating"].ToString());
                if (StatsObject["mana5"] != null)
                    ManaRegeneration = double.Parse(StatsObject["mana5"].ToString());
                if (StatsObject["mana5Combat"] != null)
                    CombatManaRegeneration = double.Parse(StatsObject["mana5Combat"].ToString());
                if (StatsObject["armor"] != null)
                    ArmourRating = int.Parse(StatsObject["armor"].ToString());
                if (StatsObject["dodge"] != null)
                    Dodge = double.Parse(StatsObject["dodge"].ToString());
                if (StatsObject["dodgeRating"] != null)
                    DodgeRating = int.Parse(StatsObject["dodgeRating"].ToString());
                if (StatsObject["parry"] != null)
                    Parry = double.Parse(StatsObject["parry"].ToString());
                if (StatsObject["parryRating"] != null)
                    ParryRating = int.Parse(StatsObject["parryRating"].ToString());
                if (StatsObject["block"] != null)
                    Block = double.Parse(StatsObject["block"].ToString());
                if (StatsObject["blockRating"] != null)
                    BlockRating = int.Parse(StatsObject["blockRating"].ToString());
                if (StatsObject["mainHandDmgMin"] != null)
                    MainHandWeaponDamageMinimum = double.Parse(StatsObject["mainHandDmgMin"].ToString());
                if (StatsObject["mainHandDmgMax"] != null)
                    MainHandWeaponDamageMaximum = double.Parse(StatsObject["mainHandDmgMax"].ToString());
                if (StatsObject["mainHandSpeed"] != null)
                    MainHandWeaponSpeed = double.Parse(StatsObject["mainHandSpeed"].ToString());
                if (StatsObject["mainHandDps"] != null)
                    MainHandWeaponDPS = double.Parse(StatsObject["mainHandDps"].ToString());

                if (StatsObject["offHandDmgMin"] != null)
                    OffHandWeaponDamageMinimum = double.Parse(StatsObject["offHandDmgMin"].ToString());
                if (StatsObject["offHandDmgMax"] != null)
                    OffHandWeaponDamageMaximum = double.Parse(StatsObject["offHandDmgMax"].ToString());
                if (StatsObject["offHandSpeed"] != null)
                    OffHandWeaponSpeed = double.Parse(StatsObject["offHandSpeed"].ToString());
                if (StatsObject["offHandDps"] != null)
                    OffHandWeaponDPS = double.Parse(StatsObject["offHandDps"].ToString());

                if (StatsObject["rangedDmgMin"] != null)
                    RangedWeaponDamageMinimum = double.Parse(StatsObject["rangedDmgMin"].ToString());
                if (StatsObject["rangedDmgMax"] != null)
                    RangedWeaponDamageMaximum = double.Parse(StatsObject["rangedDmgMax"].ToString());
                if (StatsObject["rangedSpeed"] != null)
                    RangedWeaponSpeed = double.Parse(StatsObject["rangedSpeed"].ToString());
                if (StatsObject["rangedDps"] != null)
                    RangedWeaponDPS = double.Parse(StatsObject["rangedDps"].ToString());
            }



        }
        #endregion

        #region Character Talents

        public class Talents
        {
            public class IndividualTalent
            {
                public int Tier { get; internal set; }
                public int Column { get; internal set; }

                public Spell Spell { get; internal set; }

                public Specialization Spec { get; internal set; }

                public IndividualTalent(JObject TalentObject)
                {
                    if (TalentObject["tier"] != null)
                        Tier = int.Parse(TalentObject["tier"].ToString());
                    if (TalentObject["column"] != null)
                        Column = int.Parse(TalentObject["column"].ToString());
                    if (TalentObject["spell"] != null)
                        Spell = new Spell(JObject.Parse(TalentObject["spell"].ToString()));
                    if (TalentObject["spec"] != null)
                        Spec = new Specialization(JObject.Parse(TalentObject["spec"].ToString()));
                }
            }
            public bool Selected { get; internal set; }

            public List<IndividualTalent> TalentsList { get; internal set; }

            public Talents(JObject TalentObject)
            {
                TalentsList = new List<IndividualTalent>();
                if (TalentObject["selected"] != null)
                    Selected = bool.Parse(TalentObject["selected"].ToString());
                if (TalentObject["talents"] != null && TalentObject["talents"].HasValues)
                {


                    foreach (JObject talent in TalentObject["talents"])
                    {
                        TalentsList.Add(new IndividualTalent(talent));
                    }
                }
            }
        }


        #endregion

        #region Character Titles

        public class Titles
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public Titles(JToken TitlesToken)
            {
                if (TitlesToken["id"] != null)
                    ID = int.Parse(TitlesToken["id"].ToString());
                if (TitlesToken["name"] != null)
                    Name = TitlesToken["name"].ToString();
            }
        }
        #endregion

        #region Character Audit

        public class Audit
        {
            public class EquipmentSlot
            {
                public int Head { get; internal set; }

                public int Neck { get; internal set; }

                public int Shoulder { get; internal set; }

                public int Shirt { get; internal set; }

                public int Chest { get; internal set; }

                public int Waist { get; internal set; }

                public int Legs { get; internal set; }

                public int Feet { get; internal set; }

                public int Wrist { get; internal set; }

                public int Hands { get; internal set; }

                public int Ring1 { get; internal set; }

                public int Ring2 { get; internal set; }

                public int Trinket1 { get; internal set; }

                public int Trinket2 { get; internal set; }

                public int Back { get; internal set; }

                public int MainHand { get; internal set; }

                public int OffHand { get; internal set; }

                public EquipmentSlot(JObject SlotObject)
                {
                    if (SlotObject["1"] != null)
                        Head = int.Parse(SlotObject["1"].ToString());

                    if (SlotObject["2"] != null)
                        Neck = int.Parse(SlotObject["2"].ToString());

                    if (SlotObject["3"] != null)
                        Shoulder = int.Parse(SlotObject["3"].ToString());

                    if (SlotObject["4"] != null)
                        Shirt = int.Parse(SlotObject["4"].ToString());

                    if (SlotObject["5"] != null)
                        Chest = int.Parse(SlotObject["5"].ToString());

                    if (SlotObject["6"] != null)
                        Waist = int.Parse(SlotObject["6"].ToString());

                    if (SlotObject["7"] != null)
                        Legs = int.Parse(SlotObject["7"].ToString());

                    if (SlotObject["8"] != null)
                        Feet = int.Parse(SlotObject["8"].ToString());

                    if (SlotObject["9"] != null)
                        Wrist = int.Parse(SlotObject["9"].ToString());

                    if (SlotObject["10"] != null)
                        Hands = int.Parse(SlotObject["10"].ToString());

                    if (SlotObject["11"] != null)
                        Ring1 = int.Parse(SlotObject["11"].ToString());

                    if (SlotObject["12"] != null)
                        Ring2 = int.Parse(SlotObject["12"].ToString());

                    if (SlotObject["13"] != null)
                        Trinket1 = int.Parse(SlotObject["13"].ToString());

                    if (SlotObject["14"] != null)
                        Trinket2 = int.Parse(SlotObject["14"].ToString());

                    if (SlotObject["15"] != null)
                        Back = int.Parse(SlotObject["15"].ToString());

                    if (SlotObject["16"] != null)
                        MainHand = int.Parse(SlotObject["16"].ToString());

                    if (SlotObject["17"] != null)
                        OffHand = int.Parse(SlotObject["17"].ToString());

                }
            }

            public int NumberOfIssues { get; internal set; }

            public EquipmentSlot Slots { get; internal set; }

            public int EmptyGlyphSlots { get; internal set; }

            public int UnspentTalentPoints { get; internal set; }

            public bool NoSpec { get; internal set; }

            public EquipmentSlot UnenchantedItems { get; internal set; }

            public int EmptySockets { get; internal set; }

            public EquipmentSlot ItemsWithEmptySockets { get; internal set; }

            public int AppropriateArmourType { get; internal set; }

            public EquipmentSlot InappropriateArmourTypes { get; internal set; }

            public EquipmentSlot LowLevelItems { get; internal set; }

            public int LowLevelThreshold { get; internal set; }

            public EquipmentSlot MissingSocketItem { get; internal set; }

            public Item RecommendedBeltBuckle { get; internal set; }

            public EquipmentSlot MissingBlacksmithSockets { get; internal set; }

            public EquipmentSlot MissingEnchantments { get; internal set; }

            public EquipmentSlot MissingEngineerEnhancements { get; internal set; }

            public EquipmentSlot MissingScribeEnhancements { get; internal set; }

            public int NumberOfMissingGems { get; internal set; }

            public Item RecommendedGem { get; internal set; }

            public EquipmentSlot MissingLeatherworkingEnhancements { get; internal set; }

            public Audit(JObject AuditObject)
            {
                if (AuditObject["numberOfIssues"] != null)
                    NumberOfIssues = int.Parse(AuditObject["numberOfIssues"].ToString());
                if (AuditObject["slots"] != null)
                    Slots = new EquipmentSlot(JObject.Parse(AuditObject["slots"].ToString()));
                if (AuditObject["emptyGlyphSlots"] != null)
                    EmptyGlyphSlots = int.Parse(AuditObject["emptyGlyphSlots"].ToString());
                if (AuditObject["unspentTalentPoints"] != null)
                    UnspentTalentPoints = int.Parse(AuditObject["unspentTalentPoints"].ToString());
                if (AuditObject["noSpec"] != null)
                    NoSpec = bool.Parse(AuditObject["noSpec"].ToString());
                if (AuditObject["unenchantedItems"] != null)
                    UnenchantedItems = new EquipmentSlot(JObject.Parse(AuditObject["unenchantedItems"].ToString()));
                if (AuditObject["emptySockets"] != null)
                    EmptySockets = int.Parse(AuditObject["emptySockets"].ToString());
                if (AuditObject["itemsWithEmptySockets"] != null)
                    ItemsWithEmptySockets = new EquipmentSlot(JObject.Parse(AuditObject["itemsWithEmptySockets"].ToString()));
                if (AuditObject["appropriateArmorType"] != null)
                    AppropriateArmourType = int.Parse(AuditObject["appropriateArmorType"].ToString());
                if (AuditObject["inappropriateArmorType"] != null)
                    InappropriateArmourTypes = new EquipmentSlot(JObject.Parse(AuditObject["inappropriateArmorType"].ToString()));
                if (AuditObject["lowLevelItems"] != null)
                    LowLevelItems = new EquipmentSlot(JObject.Parse(AuditObject["lowLevelItems"].ToString()));
                if (AuditObject["lowLevelThreshold"] != null)
                    LowLevelThreshold = int.Parse(AuditObject["lowLevelThreshold"].ToString());
                if (AuditObject["missingExtraSockets"] != null)
                    MissingSocketItem = new EquipmentSlot(JObject.Parse(AuditObject["missingExtraSockets"].ToString()));
                if (AuditObject["recommendedBeltBuckle"] != null)
                    RecommendedBeltBuckle = new Item(JObject.Parse(AuditObject["recommendedBeltBuckle"].ToString()));
                if (AuditObject["missingBlacksmithSockets"] != null)
                    MissingBlacksmithSockets = new EquipmentSlot(JObject.Parse(AuditObject["missingBlacksmithSockets"].ToString()));
                if (AuditObject["missingEnchanterEnchants"] != null)
                    MissingEnchantments = new EquipmentSlot(JObject.Parse(AuditObject["missingEnchanterEnchants"].ToString()));
                if (AuditObject["missingEngineerEnchants"] != null)
                    MissingEngineerEnhancements = new EquipmentSlot(JObject.Parse(AuditObject["missingEngineerEnchants"].ToString()));
                if (AuditObject["missingScribeEnchants"] != null)
                    MissingScribeEnhancements = new EquipmentSlot(JObject.Parse(AuditObject["missingScribeEnchants"].ToString()));
                if (AuditObject["nMissingJewelcrafterGems"] != null)
                    NumberOfMissingGems = int.Parse(AuditObject["nMissingJewelcrafterGems"].ToString());
                if (AuditObject["recommendedJewelcrafterGem"] != null)
                    RecommendedGem = new Item(JObject.Parse(AuditObject["recommendedJewelcrafterGem"].ToString()));
                if (AuditObject["missingLeatherworkerEnchants"] != null)
                    MissingLeatherworkingEnhancements = new EquipmentSlot(JObject.Parse(AuditObject["missingLeatherworkerEnchants"].ToString()));
            }


        }
        #endregion


        public long LastModified { get; internal set; }

        public string Name { get; internal set; }

        public string Realm { get; internal set; }

        public string Battlegroup { get; internal set; }

        [JsonProperty("class")]
        public int ClassID { get; internal set; }

        public int RaceID { get; internal set; }

        public int GenderID { get; internal set; }

        public int Level { get; internal set; }

        public int AchievementPoints { get; internal set; }

        public string Thumbnail { get; internal set; }

        public Specialization Specialization { get; internal set; }

        public CharacterGuild Guild { get; internal set; }

        public CharacterAchievements Achievements { get; internal set; }

        public Appearance CharacterAppearance { get; internal set; }

        public List<Feed> CharacterFeed { get; internal set; }

        public List<HunterPets> CombatPets { get; internal set; }

        public EquippedItem EquippedItems { get; internal set; }

        public Mounts CharacterMounts { get; internal set; }

        public Pets BattlePets { get; internal set; }

        public List<PetSlots> BattlePetSlots { get; internal set; }

        public Profession Professions { get; internal set; }

        public Progression RaidProgression { get; internal set; }

        public CharacterPvP PVP { get; internal set; }

        public List<int> CompletedQuests { get; internal set; }

        public List<Reputation> CharacterReputation { get; internal set; }

        public Statistics CharacterStatistics { get; internal set; }

        public Stats StatsAndAttributes { get; internal set; }

        public List<Talents> CharacterTalents { get; internal set; }

        public List<Titles> ObtainedTitles { get; internal set; }

        public Audit RawAudit { get; internal set; }

        public string CalcClass { get; internal set; }

        public int Faction { get; internal set; }

        public int TotalHonourableKills { get; internal set; }

        public Character(JObject rawData)
        {
            if (rawData["lastModified"] != null)
                LastModified = long.Parse(rawData["lastModified"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["realm"] != null)
                Realm = rawData["realm"].ToString();
            if (rawData["battlegroup"] != null)
                Battlegroup = rawData["battlegroup"].ToString();
            if (rawData["class"] != null)
                ClassID = int.Parse(rawData["class"].ToString());
            if (rawData["race"] != null)
                RaceID = int.Parse(rawData["race"].ToString());
            if (rawData["gender"] != null)
                GenderID = int.Parse(rawData["gender"].ToString());
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["achievementPoints"] != null)
                AchievementPoints = int.Parse(rawData["achievementPoints"].ToString());
            if (rawData["thumbnail"] != null)
                Thumbnail = rawData["thumbnail"].ToString();

            if (rawData["guild"] != null && rawData["guild"].HasValues)
                Guild = new CharacterGuild(rawData["guild"]);
            if (rawData["achievements"] != null && rawData["achievements"].HasValues)
                Achievements = new CharacterAchievements(rawData["achievements"]);
            if (rawData["appearance"] != null && rawData["appearance"].HasValues)
                CharacterAppearance = new Appearance(rawData["appearance"]);
            if (rawData["feed"] != null && rawData["feed"].HasValues)
            {
                CharacterFeed = new List<Feed>();

                foreach (JObject feed in rawData["feed"])
                {
                    Feed charFeed = new Feed(feed);
                    CharacterFeed.Add(charFeed);
                }
            }
            if (rawData["hunterPets"] != null && rawData["hunterPets"].HasValues)
            {
                CombatPets = new List<HunterPets>();

                foreach (JObject pet in rawData["hunterPets"])
                {
                    HunterPets hunterPet = new HunterPets(pet);
                    CombatPets.Add(hunterPet);
                }
            }
            if (rawData["items"] != null && rawData["items"].HasValues)
                EquippedItems = new EquippedItem(JObject.Parse(rawData["items"].ToString()));
            if (rawData["mounts"] != null && rawData["mounts"].HasValues)
                CharacterMounts = new Mounts(JObject.Parse(rawData["mounts"].ToString()));
            if (rawData["pets"] != null && rawData["pets"].HasValues)
                BattlePets = new Pets(JObject.Parse(rawData["pets"].ToString()));
            if (rawData["petSlots"] != null && rawData["petSlots"].HasValues)
            {
                BattlePetSlots = new List<PetSlots>();

                foreach (JObject PetObject in rawData["petSlots"])
                {
                    PetSlots slot = new PetSlots(PetObject);
                    BattlePetSlots.Add(slot);
                }
            }
            if (rawData["professions"] != null && rawData["professions"].HasValues)
                Professions = new Profession(JObject.Parse(rawData["professions"].ToString()));
            if (rawData["progression"] != null && rawData["progression"].HasValues)
                RaidProgression = new Progression(JObject.Parse(rawData["progression"].ToString()));
            if (rawData["pvp"] != null && rawData["pvp"].HasValues)
                PVP = new CharacterPvP(JObject.Parse(rawData["pvp"].ToString()));
            if (rawData["quests"] != null && rawData["quests"].HasValues)
            {
                CompletedQuests = new List<int>();

                foreach (int quest in rawData["quests"])
                {
                    CompletedQuests.Add(quest);
                }
            }
            if (rawData["reputation"] != null && rawData["reputation"].HasValues)
            {
                CharacterReputation = new List<Reputation>();

                foreach (JObject rep in rawData["reputation"])
                {
                    Reputation newRep = new Reputation(rep);
                    CharacterReputation.Add(newRep);
                }
            }
            if (rawData["spec"] != null && rawData["spec"].HasValues)
                Specialization = new Specialization(JObject.Parse(rawData["spec"].ToString()));
            if (rawData["statistics"] != null && rawData["statistics"].HasValues)
                CharacterStatistics = new Statistics(JObject.Parse(rawData["statistics"].ToString()));
            if (rawData["stats"] != null && rawData["stats"].HasValues)
                StatsAndAttributes = new Stats(JObject.Parse(rawData["stats"].ToString()));
            if (rawData["talents"] != null && rawData["talents"].HasValues)
            {
                CharacterTalents = new List<Talents>();

                foreach (JObject talent in rawData["talents"])
                {
                    Talents newTalent = new Talents(talent);
                    CharacterTalents.Add(newTalent);
                }
            }
            if (rawData["titles"] != null && rawData["titles"].HasValues)
            {
                ObtainedTitles = new List<Titles>();

                foreach (JObject title in rawData["titles"])
                {
                    Titles obtainedTitle = new Titles(title);
                    ObtainedTitles.Add(obtainedTitle);
                }
            }
            if (rawData["audit"] != null && rawData["audit"].HasValues)
                RawAudit = new Audit(JObject.Parse(rawData["audit"].ToString()));
            if (rawData["calcClass"] != null)
                CalcClass = rawData["calcClass"].ToString();
            if (rawData["faction"] != null)
                Faction = int.Parse(rawData["faction"].ToString());
            if (rawData["totalHonorableKills"] != null)
                TotalHonourableKills = int.Parse(rawData["totalHonorableKills"].ToString());
        }

    }
}
