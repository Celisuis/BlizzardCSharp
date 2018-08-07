using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Hero
    {
        public class HeroSkill
        {
            public Skill ActualSkill { get; internal set; }
            public Rune ActiveRune { get; internal set; }

            public HeroSkill(JObject rawData)
            {
                if (rawData["skill"] != null)
                    ActualSkill = new Skill(JObject.Parse(rawData["skill"].ToString()));
                if (rawData["rune"] != null)
                    ActiveRune = new Rune(JObject.Parse(rawData["rune"].ToString()));
            }
        }

        public class HeroProgression
        {
            public class CompletedQuest
            {
                public string Slug { get; internal set; }

                public string Name { get; internal set; }

                public CompletedQuest(JObject rawData)
                {
                    if (rawData["slug"] != null)
                        Slug = rawData["slug"].ToString();
                    if (rawData["name"] != null)
                        Name = rawData["name"].ToString();
                }
            }

            public bool ActCompleted { get; internal set; }
            public List<CompletedQuest> CompletedQuests { get; internal set; }

            public HeroProgression(JObject rawData)
            {
                if (rawData["completed"] != null)
                    ActCompleted = bool.Parse(rawData["completed"].ToString());
                if(rawData["completedQuests"] != null && rawData["completedQuests"].HasValues)
                {
                    JArray questArray = JArray.Parse(rawData["completedQuests"].ToString());
                    CompletedQuests = questArray.OfType<CompletedQuest>().ToList();
                }
            }
        }
        
        public long ID { get; internal set; }

        public string Name { get; internal set; }

        public string Class { get; internal set; }

        public string ClassSlug { get; internal set; }

        public int Gender { get; internal set; }

        public int Level { get; internal set; }

        public Kill Kills { get; internal set; }

        public int ParagonLevel { get; internal set; }

        public bool Hardcore { get; internal set; }

        public bool Seasonal { get; internal set; }

        public bool Dead { get; internal set; }

        public long LastUpdated { get; internal set; }

        public int SeasonCreated { get; internal set; }

        public List<HeroSkill> ActiveSkills { get; internal set; }

        public List<Skill> PassiveSkills { get; internal set; }

        public List<EquippedItem> EquippedItems { get; internal set; }

        public List<Follower> Followers { get; internal set; }

        public List<LegendaryPower> LegendaryPowers { get; internal set; }

        public List<HeroProgression> Progression { get; internal set; }

        public bool Alive { get; internal set; }

        public int HighestSoloRiftCompleted { get; internal set; }

        public Stats Stats { get; internal set; }
        
        public Hero(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = long.Parse(rawData["id"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["class"] != null)
                Class = rawData["class"].ToString();
            if (rawData["classSlug"] != null)
                ClassSlug = rawData["classSlug"].ToString();
            if (rawData["gender"] != null)
                Gender = int.Parse(rawData["gender"].ToString());
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["kills"] != null && rawData["kills"].HasValues)
                Kills = new Kill(JObject.Parse(rawData["kills"].ToString()));
            if (rawData["paragonLevel"] != null)
                ParagonLevel = int.Parse(rawData["paragonLevel"].ToString());
            if (rawData["hardcore"] != null)
                Hardcore = bool.Parse(rawData["hardcore"].ToString());
            if (rawData["seasonal"] != null)
                Seasonal = bool.Parse(rawData["seasonal"].ToString());
            if (rawData["dead"] != null)
                Dead = bool.Parse(rawData["dead"].ToString());
            if (rawData["lastUpdated"] != null)
                LastUpdated = long.Parse(rawData["lastUpdated"].ToString());
            if (rawData["seasonCreated"] != null)
                SeasonCreated = int.Parse(rawData["seasonCreated"].ToString());
            if(rawData["skills"]["active"] != null && rawData["skills"]["active"].HasValues)
            {
                ActiveSkills = new List<HeroSkill>();

                foreach(JObject hs in rawData["skills"]["active"])
                {
                    HeroSkill hero = new HeroSkill(hs);
                    ActiveSkills.Add(hero);
                }
            }
            if (rawData["skills"]["passive"] != null && rawData["skills"]["passive"].HasValues)
            {
                PassiveSkills = new List<Skill>();

                foreach (JObject hs in rawData["skills"]["passive"])
                {
                    Skill skill = new Skill(hs);
                    PassiveSkills.Add(skill);
                }
            }
            if(rawData["items"] != null && rawData["items"].HasValues)
            {
                EquippedItems = new List<EquippedItem>();
                
                foreach(JObject eitem in rawData["items"])
                {
                    EquippedItem item = new EquippedItem(eitem);
                    EquippedItems.Add(item);
                }
            }
            if(rawData["followers"] != null && rawData["followers"].HasValues)
            {
                Followers = new List<Follower>();

                foreach(JObject foll in rawData["followers"])
                {
                    Follower follower = new Follower(foll);
                    Followers.Add(follower);
                }
            }
            if(rawData["legendaryPowers"] != null && rawData["legendaryPowers"].HasValues)
            {
                LegendaryPowers = new List<LegendaryPower>();

                foreach(JObject lp in rawData["legendaryPowers"])
                {
                    LegendaryPower power = new LegendaryPower(lp);
                    LegendaryPowers.Add(power);
                }
            }
            if(rawData["progression"] != null && rawData["progression"].HasValues)
            {
                Progression = new List<HeroProgression>();

                foreach(JObject prog in rawData["progression"])
                {
                    HeroProgression hp = new HeroProgression(prog);
                    Progression.Add(hp);
                }
            }
            if (rawData["alive"] != null)
                Alive = bool.Parse(rawData["alive"].ToString());
            if (rawData["highestSoloRiftCompleted"] != null)
                HighestSoloRiftCompleted = int.Parse(rawData["highestSoloRiftCompleted"].ToString());
            if (rawData["stats"] != null)
                Stats = new Stats(JObject.Parse(rawData["stats"].ToString()));
        }
    }
}
