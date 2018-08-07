using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Follower
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public string RealName { get; internal set; }

        public string Portrait { get; internal set; }

        public List<Skill> Skills { get; internal set; }
        
        public List<EquippedItem> EquippedItems { get; internal set; }

        public Stats Stats { get; internal set; }

        public Follower(JObject rawData)
        {
            if (rawData["slug"] != null)
                Slug = rawData["slug"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["realName"] != null)
                RealName = rawData["realName"].ToString();
            if (rawData["portrait"] != null)
                Portrait = rawData["portrait"].ToString();
            if(rawData["skills"] != null && rawData["skills"].HasValues)
            {
                Skills = new List<Skill>();

                foreach(JObject skillObject in rawData["skills"])
                {
                    Skill skill = new Skill(skillObject);
                    Skills.Add(skill);
                }
            }
            if(rawData["items"] != null && rawData["items"].HasValues)
            {
                EquippedItems = new List<EquippedItem>();

                foreach(JObject item in rawData["items"])
                {
                    EquippedItem eq = new EquippedItem(item);
                    EquippedItems.Add(eq);
                }
            }
            if (rawData["stats"] != null)
                Stats = new Stats(JObject.Parse(rawData["stats"].ToString()));
        }
    }
}
