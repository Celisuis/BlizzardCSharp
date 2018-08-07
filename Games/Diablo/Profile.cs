using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Profile
    {
        public class CharacterArtisan
        {
            public string Slug { get; internal set; }

            public int Level { get; internal set; }

            public CharacterArtisan(JObject rawData)
            {
                if (rawData["slug"] != null)
                    Slug = rawData["slug"].ToString();
                if (rawData["level"] != null)
                    Level = int.Parse(rawData["level"].ToString());
            }
        }
        public string BattleTag { get; internal set; }

        public int ParagonLevel { get; internal set; }

        public int HardcoreParagonLevel { get; internal set; }

        public int SeasonParagonLevel { get; internal set; }

        public int HardcoreSeasonParagonLevel { get; internal set; }

        public string GuildName { get; internal set; }

        public List<Hero> Heroes { get; internal set; }

        public long LastHeroPlayedID { get; internal set; }

        public long LastUpdated { get; internal set; }

        public Kill Kills { get; internal set; }

        public int HighestHardcoreLevel { get; internal set; }

        public TimePlayed TimePlayed { get; internal set; }

        public Progression Progression { get; internal set; }

        public List<SeasonalProfile> SeasonalProfiles { get; internal set; }

        public CharacterArtisan Blacksmith { get; internal set; }

        public CharacterArtisan SeasonBlacksmith { get; internal set; }

        public CharacterArtisan HardcoreBlacksmith { get; internal set; }

        public CharacterArtisan HardcoreSeasonBlacksmith { get; internal set; }

        public CharacterArtisan Mystic { get; internal set; }

        public CharacterArtisan SeasonMystic { get; internal set; }

        public CharacterArtisan HardcoreMystic { get; internal set; }

        public CharacterArtisan HardcoreSeasonMystic { get; internal set; }

        public CharacterArtisan Jeweler { get; internal set; }

        public CharacterArtisan SeasonJeweler { get; internal set; }

        public CharacterArtisan HardcoreJeweler { get; internal set; }

        public CharacterArtisan HardcoreSeasonJeweler { get; internal set; }

        public Profile(JObject rawData)
        {
            if (rawData["battleTag"] != null)
                BattleTag = rawData["battleTag"].ToString();
            if (rawData["paragonLevel"] != null)
                ParagonLevel = int.Parse(rawData["paragonLevel"].ToString());
            if (rawData["paragonLevelHardcore"] != null)
                HardcoreParagonLevel = int.Parse(rawData["paragonLevelHardcore"].ToString());
            if (rawData["paragonLevelSeason"] != null)
                SeasonParagonLevel = int.Parse(rawData["paragonLevelSeason"].ToString());
            if (rawData["paragonLevelSeasonHardcore"] != null)
                HardcoreSeasonParagonLevel = int.Parse(rawData["paragonLevelSeasonHardcore"].ToString());
            if (rawData["guildName"] != null)
                GuildName = rawData["guildName"].ToString();
            if (rawData["heroes"] != null && rawData["heroes"].HasValues)
            {
                Heroes = new List<Hero>();

                foreach (JObject heroObject in rawData["heroes"])
                {
                    Hero hero = new Hero(heroObject);
                    Heroes.Add(hero);
                }
            }
            if (rawData["lastHeroPlayed"] != null)
                LastHeroPlayedID = long.Parse(rawData["lastHeroPlayed"].ToString());
            if (rawData["lastUpdated"] != null)
                LastUpdated = long.Parse(rawData["lastUpdated"].ToString());
            if (rawData["kills"] != null)
                Kills = new Kill(JObject.Parse(rawData["kills"].ToString()));
            if (rawData["highestHardcoreLevel"] != null)
                HighestHardcoreLevel = int.Parse(rawData["highestHardcoreLevel"].ToString());
            if (rawData["timePlayed"] != null)
                TimePlayed = new TimePlayed(JObject.Parse(rawData["timePlayed"].ToString()));
            if (rawData["progression"] != null)
                Progression = new Progression(JObject.Parse(rawData["progression"].ToString()));
            if(rawData["seasonalProfiles"] != null && rawData["seasonalProfiles"].HasValues)
            {
                SeasonalProfiles = new List<SeasonalProfile>();
                foreach(JObject season in rawData["seasonalProfiles"])
                {
                    SeasonalProfile sp = new SeasonalProfile(season);
                    SeasonalProfiles.Add(sp);
                }
            }
            if (rawData["blacksmith"] != null)
                Blacksmith = new CharacterArtisan(JObject.Parse(rawData["blacksmith"].ToString()));
            if (rawData["mystic"] != null)
                Mystic = new CharacterArtisan(JObject.Parse(rawData["mystic"].ToString()));
            if (rawData["jeweler"] != null)
                Jeweler = new CharacterArtisan(JObject.Parse(rawData["jeweler"].ToString()));
            if (rawData["blacksmithSeason"] != null)
                SeasonBlacksmith = new CharacterArtisan(JObject.Parse(rawData["blacksmithSeason"].ToString()));
            if (rawData["mysticSeason"] != null)
                SeasonMystic = new CharacterArtisan(JObject.Parse(rawData["mysticSeason"].ToString()));
            if (rawData["jewelerSeason"] != null)
                SeasonJeweler = new CharacterArtisan(JObject.Parse(rawData["jewelerSeason"].ToString()));
            if (rawData["blacksmithHardcore"] != null)
                HardcoreBlacksmith = new CharacterArtisan(JObject.Parse(rawData["blacksmithHardcore"].ToString()));
            if (rawData["mysticHardcore"] != null)
                HardcoreMystic = new CharacterArtisan(JObject.Parse(rawData["mysticHardcore"].ToString()));
            if (rawData["jewelerHardcore"] != null)
                HardcoreJeweler = new CharacterArtisan(JObject.Parse(rawData["jewelerHardcore"].ToString()));
            if (rawData["blacksmithSeasonHardcore"] != null)
                HardcoreSeasonBlacksmith = new CharacterArtisan(JObject.Parse(rawData["blacksmithSeasonHardcore"].ToString()));
            if (rawData["mysticSeasonHardcore"] != null)
                HardcoreSeasonMystic = new CharacterArtisan(JObject.Parse(rawData["mysticSeasonHardcore"].ToString()));
            if (rawData["jewelerSeasonHardcore"] != null)
                HardcoreSeasonJeweler = new CharacterArtisan(JObject.Parse(rawData["jewelerSeasonHardcore"].ToString()));

        }
    }
}
