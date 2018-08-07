using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Class
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public string MaleName { get; internal set; }

        public string FemaleName { get; internal set; }

        public string Icon { get; internal set; }

        public List<SkillCategory> SkillCategories { get; internal set; }

        public List<Skill> ActiveSkills { get; internal set; }

        public List<Skill> PassiveSkills { get; internal set; }

        public Class(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["maleName"] != null)
                MaleName = rawData["maleName"].ToString();
            if (rawData["femaleName"] != null)
                FemaleName = rawData["femaleName"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if(rawData["skillCategories"] != null && rawData["skillCategories"].HasValues)
            {
                SkillCategories = new List<SkillCategory>();

                foreach(JObject skillObject in rawData["skillCategories"])
                {
                    SkillCategory sc = new SkillCategory(skillObject);
                    SkillCategories.Add(sc);
                }
            }
            if(rawData["skills"]["active"] != null && rawData["skills"]["active"].HasValues)
            {
                ActiveSkills = new List<Skill>();

                foreach(JObject skillObject in rawData["skills"]["active"])
                {
                    Skill skill = new Skill(skillObject);
                    ActiveSkills.Add(skill);
                }
            }
            if (rawData["skills"]["passive"] != null && rawData["skills"]["passive"].HasValues)
            {
                PassiveSkills = new List<Skill>();

                foreach (JObject skillObject in rawData["skills"]["passive"])
                {
                    Skill skill = new Skill(skillObject);
                    PassiveSkills.Add(skill);
                }
            }
        }
    }
}
