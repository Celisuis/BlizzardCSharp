using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Boss
    {
        public class BossNPC
        {
            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public string URLSlug { get; internal set; }

            public BossNPC(JToken BossToken)
            {
                if (BossToken["id"] != null)
                    ID = int.Parse(BossToken["id"].ToString());
                if (BossToken["name"] != null)
                    Name = BossToken["name"].ToString();
                if (BossToken["urlSlug"] != null)
                    URLSlug = BossToken["urlSlug"].ToString();
            }
        }

        public int ID { get; internal set; }

        public string Name { get; internal set; }

        public string URLSlug { get; internal set; }

        public string Description { get; internal set; }

        public int ZoneID { get; internal set; }

        public bool NormalModeAvailable { get; internal set; }

        public bool HeroicModeAvailable { get; internal set; }

        public int Health { get; internal set; }

        public int HeroicHealth { get; internal set; }

        public int Level { get; internal set; }

        public int HeroicLevel { get; internal set; }

        public int JournalID { get; internal set; }

        public List<BossNPC> NPCList { get; internal set; }

        public Boss(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = int.Parse(rawData["id"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["urlSlug"] != null)
                URLSlug = rawData["urlSlug"].ToString();
            if (rawData["description"] != null)
                Description = rawData["description"].ToString();
            if (rawData["zoneId"] != null)
                ZoneID = int.Parse(rawData["zoneId"].ToString());
            if (rawData["availableInNormalMode"] != null)
                NormalModeAvailable = bool.Parse(rawData["availableInNormalMode"].ToString());
            if (rawData["availableInHeroicMode"] != null)
                HeroicModeAvailable = bool.Parse(rawData["availableInHeroicMode"].ToString());
            if (rawData["health"] != null)
                Health = int.Parse(rawData["health"].ToString());
            if (rawData["heroicHealth"] != null)
                HeroicHealth = int.Parse(rawData["heroicHealth"].ToString());
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if (rawData["heroicLevel"] != null)
                HeroicLevel = int.Parse(rawData["heroicLevel"].ToString());
            if (rawData["journalId"] != null)
                JournalID = int.Parse(rawData["journalId"].ToString());
            if (rawData["npcs"] != null)
            {
                NPCList = new List<BossNPC>();
                foreach (JToken NPCToken in rawData["npcs"])
                {
                    BossNPC npc = new BossNPC(NPCToken);
                    NPCList.Add(npc);
                }
            }
        }
    }
}
