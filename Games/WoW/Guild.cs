using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Guild
    {
        public class Members
        {
            public Character MemberName { get; internal set; }

            public int Rank { get; internal set; }

            public Members(JObject MemberObject)
            {
                MemberName = new Character(JObject.Parse(MemberObject["character"].ToString()));
                Rank = int.Parse(MemberObject["rank"].ToString());
            }
        }

        public class Achievements
        {
            public List<long> AchievementsCompleted { get; internal set; }

            public List<long> AchievementsCompletedTime { get; internal set; }

            public List<long> Criteria { get; internal set; }

            public List<long> CriteriaQuantity { get; internal set; }

            public List<long> CriteriaTime { get; internal set; }

            public List<long> CriteriaCreated { get; internal set; }

            public Achievements(JObject AchievementsObject)
            {
                if (AchievementsObject["achievementsCompleted"] != null && AchievementsObject["achievementsCompleted"].HasValues)
                {
                    AchievementsCompleted = new List<long>();
                    foreach (long AchievementCompleteObject in AchievementsObject["achievementsCompleted"])
                    {
                        AchievementsCompleted.Add(AchievementCompleteObject);
                    }
                }

                if (AchievementsObject["achievementsCompletedTimestamp"] != null && AchievementsObject["achievementsCompletedTimestamp"].HasValues)
                {
                    AchievementsCompletedTime = new List<long>();
                    foreach (long achievementsCompleteTimestampObject in AchievementsObject["achievementsCompletedTimestamp"])
                    {
                        AchievementsCompletedTime.Add(achievementsCompleteTimestampObject);
                    }
                }

                if (AchievementsObject["criteria"] != null && AchievementsObject["criteria"].HasValues)
                {
                    Criteria = new List<long>();
                    foreach (long CriteriaObject in AchievementsObject["criteria"])
                    {
                        Criteria.Add(CriteriaObject);
                    }
                }

                if (AchievementsObject["criteriaQuantity"] != null && AchievementsObject["criteriaQuantity"].HasValues)
                {
                    CriteriaQuantity = new List<long>();
                    foreach (long CriteriaQuantityObject in AchievementsObject["criteriaQuantity"])
                    {
                        CriteriaQuantity.Add(CriteriaQuantityObject);
                    }
                }

                if (AchievementsObject["criteriaTimestamp"] != null && AchievementsObject["criteriaTimestamp"].HasValues)
                {
                    CriteriaTime = new List<long>();
                    foreach (long CriteriaTimestampObject in AchievementsObject["criteriaTimestamp"])
                    {
                        CriteriaTime.Add(CriteriaTimestampObject);
                    }
                }

                if (AchievementsObject["criteriaCreated"] != null && AchievementsObject["criteriaCreated"].HasValues)
                {
                    CriteriaCreated = new List<long>();
                    foreach (long CriteriaCreatedObject in AchievementsObject["criteriaCreated"])
                    {
                        CriteriaCreated.Add(CriteriaCreatedObject);
                    }
                }
            }
        }

        public class News
        {
            public string Type { get; internal set; }

            public string Character { get; internal set; }

            public long Time { get; internal set; }

            public int ItemID { get; internal set; }

            public string Context { get; internal set; }

            public List<int> BonusList { get; internal set; }

            public Achievement Achievement { get; internal set; }

            public News(JObject NewsObject)
            {
                if (NewsObject["type"] != null)
                    Type = NewsObject["type"].ToString();
                if (NewsObject["character"] != null)
                    Character = NewsObject["character"].ToString();
                if (NewsObject["timestamp"] != null)
                    Time = long.Parse(NewsObject["timestamp"].ToString());
                if (NewsObject["context"] != null)
                    Context = NewsObject["context"].ToString();
                if (NewsObject["bonusLists"] != null && NewsObject["bonusLists"].HasValues)
                {
                    BonusList = new List<int>();

                    foreach (int BonusInt in NewsObject["bonusLists"])
                    {
                        BonusList.Add(BonusInt);
                    }
                }
                if (NewsObject["achievement"] != null && NewsObject["achievement"].HasValues)
                    Achievement = new Achievement(JObject.Parse(NewsObject["achievement"].ToString()));
            }
        }

        public class Emblem
        {
            public int Icon { get; internal set; }
            [JsonProperty("iconColor")]
            public string IconColourRaw { get; internal set; }
            [JsonIgnore]
            public Color IconColour { get; internal set; }

            public int Border { get; internal set; }
            [JsonProperty("borderColor")]
            public string BorderColourRaw { get; internal set; }
            [JsonIgnore]
            public Color BorderColour { get; internal set; }
            [JsonProperty("backgroundColor")]
            public string BackgroundColourRaw { get; internal set; }
            [JsonIgnore]
            public Color BackgroundColour { get; internal set; }

            public Emblem(JToken EmblemToken)
            {
                Icon = int.Parse(EmblemToken["icon"].ToString());
                IconColourRaw = EmblemToken["iconColor"].ToString();
                IconColour = ColorTranslator.FromHtml(IconColourRaw);
                Border = int.Parse(EmblemToken["border"].ToString());
                BorderColourRaw = EmblemToken["borderColor"].ToString();
                BorderColour = ColorTranslator.FromHtml(BorderColourRaw);
                BackgroundColourRaw = EmblemToken["backgroundColor"].ToString();
                BackgroundColour = ColorTranslator.FromHtml(BackgroundColourRaw);
            }
        }

        public string Name { get; internal set; }

        public string Realm { get; internal set; }

        public string Battlegroup { get; internal set; }

        public int Level { get; internal set; }

        public int Faction { get; internal set; }

        public int AchievementPoints { get; internal set; }

        public List<Members> GuildMemberMasterList { get; internal set; }

        public Achievements GuildAchievements { get; internal set; }

        public List<News> GuildNews { get; internal set; }

        public List<ChallengeMode> ChallengeMode { get; internal set; }

        public Emblem GuildEmblem { get; internal set; }

        public Guild(JObject rawData)
        {
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["realm"] != null)
                Realm = rawData["realm"].ToString();
            if (rawData["battlegroup"] != null)
                Battlegroup = rawData["battlegroup"].ToString();
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["side"] != null)
                Faction = int.Parse(rawData["side"].ToString());
            if (rawData["achievementPoints"] != null)
                AchievementPoints = int.Parse(rawData["achievementPoints"].ToString());
            if (rawData["members"] != null && rawData["members"].HasValues)
            {
                GuildMemberMasterList = new List<Members>();
                foreach (JObject MemberObject in rawData["members"])
                {
                    GuildMemberMasterList.Add(new Members(MemberObject));
                }
            }
            if (rawData["achievements"] != null)
                GuildAchievements = new Achievements(JObject.Parse(rawData["achievements"].ToString()));
            if (rawData["news"] != null && rawData["news"].HasValues)
            {
                GuildNews = new List<News>();
                foreach (JObject NewsObject in rawData["news"])
                {
                    GuildNews.Add(new News(NewsObject));
                }
            }
            if (rawData["challenge"] != null && rawData["challenge"].HasValues)
            {
                ChallengeMode = new List<ChallengeMode>();

                foreach (JObject ChallengeObject in rawData["challenge"])
                {
                    ChallengeMode.Add(new ChallengeMode(ChallengeObject));
                }
            }
        }


    }
}
