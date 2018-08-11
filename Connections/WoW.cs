using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlizzardCSharp.Games.WoW;

namespace BlizzardCSharp.Connections
{
    public class WorldOfWarcraft
    {
        private readonly Client Client;

        private readonly string Api_Url;
        private readonly string Api_Key;
        private readonly string Locale;
        private readonly string User_Agent;

        public WorldOfWarcraft(Client client, string api_url, string locale, string api_key, string user_agent)
        {
            Client = client;
            Api_Url = api_url;
            Locale = locale;
            Api_Key = api_key;
            User_Agent = user_agent;
        }

        #region API Functions
        #region Achievements

        public Achievement GetAchievement(int id)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/achievement/{id}?locale={Locale}&apikey={Api_Key}");
            return new Achievement(JObject.Parse(request.Response));
        }
        #endregion

        #region Auctions
        public List<Auction> GetAuctions(string realm)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/auction/data/{realm}?locale={Locale}&apikey={Api_Key}");
            request.Get(JObject.Parse(request.Response)["files"][0]["url"].ToString());

            List<Auction> activeAuctions = new List<Auction>();
            foreach (JObject AuctionObject in JObject.Parse(request.Response)["auctions"])
            {
                activeAuctions.Add(new Auction(AuctionObject));
            }

            return activeAuctions;
        }


        #endregion

        #region Bosses

        public List<Boss> GetBossMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/boss/?locale={Locale}&apikey={Api_Key}");

            List<Boss> BossList = new List<Boss>();
            foreach (JObject BossObject in JObject.Parse(request.Response)["bosses"])
            {
                BossList.Add(new Boss(BossObject));
            }
            return BossList;
        }

        public Boss GetBoss(int id)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/boss/{id}?locale={Locale}&apikey={Api_Key}");

            return new Boss(JObject.Parse(request.Response));
        }
        #endregion

        #region Challenge Mode

        public List<ChallengeMode> GetChallengeModeRealmLeaderboards(string realm)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/challenge/{realm}?locale={Locale}&apikey={Api_Key}");

            List<ChallengeMode> ChallengeList = new List<ChallengeMode>();
            foreach (JObject ChallengeObject in JObject.Parse(request.Response)["challenge"])
            {
                ChallengeList.Add(new ChallengeMode(ChallengeObject));
            }
            return ChallengeList;

        }

        public List<ChallengeMode> GetChallengeModeRegionLeaderboards()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/challenge/region?locale={Locale}&apikey={Api_Key}");

            List<ChallengeMode> ChallengeList = new List<ChallengeMode>();
            foreach (JObject ChallengeObject in JObject.Parse(request.Response)["challenge"])
            {
                ChallengeList.Add(new ChallengeMode(ChallengeObject));
            }
            return ChallengeList;
        }
        #endregion

        #region Character

        public enum CharacterFields
        {
            achievements,
            appearance,
            feed,
            guild,
            hunterPets,
            items,
            mounts,
            pets,
            petSlots,
            professions,
            progression,
            pvp,
            quests,
            reputation,
            statistics,
            stats,
            talents,
            titles,
            audit,
            none
        }

        public Character GetCharacterProfile(string realm, string character)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/character/{realm}/{character}?locale={Locale}&apikey={Api_Key}");
            return new Character(JObject.Parse(request.Response));
        }

        public Character GetCharacterProfile(string realm, string character, CharacterFields field)
        {
            string fieldInput = field.ToString();

            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/character/{realm}/{character}?fields={fieldInput}&locale={Locale}&apikey={Api_Key}");
            return new Character(JObject.Parse(request.Response));
        }
        #endregion

        #region Guild

        public enum GuildFields
        {
            achievements,
            challenge,
            members,
            news
        }

        public Guild GetGuildProfile(string realm, string guild)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/guild/{realm}/{guild}?locale={Locale}&apikey={Api_Key}");
            return new Guild(JObject.Parse(request.Response));
        }

        public Guild GetGuildProfile(string realm, string guild, GuildFields field)
        {
            string fieldInput = field.ToString();

            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/guild/{realm}/{guild}?fields={fieldInput}&locale={Locale}&apikey={Api_Key}");
            return new Guild(JObject.Parse(request.Response));
        }
        #endregion

        #region Item

        public Item GetItem(int itemID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/item/{itemID}?locale={Locale}&apikey={Api_Key}");
            return new Item(JObject.Parse(request.Response));
        }

        public ItemSet GetItemSet(int setID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/item/set/{setID}?locale={Locale}&apikey={Api_Key}");
            return new ItemSet(JObject.Parse(request.Response));
        }
        #endregion

        #region Mounts

        public List<Mount> GetMountMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/mount/?locale={Locale}&apikey={Api_Key}");
            JObject rawData = JObject.Parse(request.Response);

            List<Mount> MountMasterList = new List<Mount>();
            foreach (JObject MountObject in rawData["mounts"])
            {
                Mount mount = new Mount(MountObject);

                MountMasterList.Add(mount);
            }
            return MountMasterList;
        }

        #endregion

        #region Pets

        public List<Pet> GetPetMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/pet/?locale={Locale}&apikey={Api_Key}");
            JObject rawData = JObject.Parse(request.Response);

            List<Pet> PetMasterList = new List<Pet>();
            foreach (JObject PetObject in rawData["pets"])
            {
                Pet pet = new Pet(PetObject);
                PetMasterList.Add(pet);
            }
            return PetMasterList;
        }

        public Pet.Ability GetPetAbility(int abilityID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/pet/ability/{abilityID}?locale={Locale}&apikey={Api_Key}");

            return new Pet.Ability(JObject.Parse(request.Response));
        }

        public Pet.Species GetPetSpecies(int speciesID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/pet/species/{speciesID}?locale={Locale}&apikey={Api_Key}");

            return new Pet.Species(JObject.Parse(request.Response));
        }

        public Pet.Stats GetPetStats(int speciesID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/pet/stats/{speciesID}?locale={Locale}&apikey={Api_Key}");

            return new Pet.Stats(JObject.Parse(request.Response));
        }
        #endregion

        #region PVP

        public enum LeaderboardBracket
        {
            v2,
            v3,
            v5,
            rbg,
            none
        }

        public List<PvP> GetPvPLeaderboards(LeaderboardBracket bracket)
        {
            string bracketString;

            switch (bracket)
            {
                case LeaderboardBracket.v2:
                    bracketString = "2v2";
                    break;
                case LeaderboardBracket.v3:
                    bracketString = "3v3";
                    break;
                case LeaderboardBracket.v5:
                    bracketString = "5v5";
                    break;
                case LeaderboardBracket.rbg:
                    bracketString = "rbg";
                    break;
                default:
                    throw new Exception($"The bracket {bracket} is not supported.");
            }

            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/leaderboard/{bracketString}?locale={Locale}&apikey={Api_Key}");

            List<PvP> Leaderboards = new List<PvP>();

            foreach (JObject PvPObject in JObject.Parse(request.Response)["rows"])
            {
                Leaderboards.Add(new PvP(PvPObject));
            }
            return Leaderboards;

        }
        #endregion

        #region Quest

        public Quest GetQuest(int questID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/quest/{questID}?locale={Locale}&apikey={Api_Key}");

            return new Quest(JObject.Parse(request.Response));
        }

        #endregion

        #region Realm Status

        public List<Realm> GetRealmStatus()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/realm/status?locale={Locale}&apikey={Api_Key}");

            List<Realm> RealmMasterList = new List<Realm>();

            foreach (JObject RealmObject in JObject.Parse(request.Response)["realms"])
            {
                RealmMasterList.Add(new Realm(RealmObject));
            }

            return RealmMasterList;
        }
        #endregion

        #region Recipe

        public Recipe GetRecipe(int recipeID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/recipe/{recipeID}?locale={Locale}&apikey={Api_Key}");

            return new Recipe(JObject.Parse(request.Response));
        }
        #endregion

        #region Spells

        public Spell GetSpell(int spellID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/spell/{spellID}?locale={Locale}&apikey={Api_Key}");

            return new Spell(JObject.Parse(request.Response));
        }

        #endregion

        #region Zones

        public List<Zone> GetZoneMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/zone/?locale={Locale}&apikey={Api_Key}");

            List<Zone> ZoneMasterList = new List<Zone>();

            foreach (JObject ZoneObject in JObject.Parse(request.Response)["zones"])
            {
                ZoneMasterList.Add(new Zone(ZoneObject));
            }
            return ZoneMasterList;
        }

        public Zone GetZone(int zoneID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/zone/{zoneID}?locale={Locale}&apikey={Api_Key}");

            return new Zone(JObject.Parse(request.Response));
        }
        #endregion

        #region Data Resource

        #region Battlegroups

        public List<Battlegroup> GetBattlegroups()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/battlegroups/?locale={Locale}&apikey={Api_Key}");

            List<Battlegroup> BattlegroupMasterList = new List<Battlegroup>();

            foreach (JObject BattlegroupObject in JObject.Parse(request.Response)["battlegroups"])
            {
                BattlegroupMasterList.Add(new Battlegroup(BattlegroupObject));
            }
            return BattlegroupMasterList;
        }
        #endregion

        #region Character Races

        public List<Race> GetCharacterRaces()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/character/races?locale={Locale}&apikey={Api_Key}");

            List<Race> RaceMasterList = new List<Race>();

            foreach (JObject RaceObject in JObject.Parse(request.Response)["races"])
            {
                RaceMasterList.Add(new Race(RaceObject));
            }
            return RaceMasterList;
        }

        #endregion

        #region Character Classes

        public List<Class> GetCharacterClasses()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/character/classes?locale={Locale}&apikey={Api_Key}");

            List<Class> ClassMasterList = new List<Class>();

            foreach (JObject ClassObject in JObject.Parse(request.Response)["classes"])
            {
                ClassMasterList.Add(new Class(ClassObject));
            }
            return ClassMasterList;
        }
        #endregion

        #region Character Achievements

        public List<Achievement> GetCharacterAchievements()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/character/achievements?locale={Locale}&apikey={Api_Key}");

            List<Achievement> AchievementsMasterList = new List<Achievement>();

            foreach (JObject AchievementObjectList in JObject.Parse(request.Response)["achievements"])
            {
                foreach (JObject AchievementObject in AchievementObjectList["achievements"])
                {
                    AchievementsMasterList.Add(new Achievement(AchievementObject));
                }
            }
            return AchievementsMasterList;
        }
        #endregion

        #region Guild Rewards

        public List<GuildReward> GetGuildRewards()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/guild/rewards?locale={Locale}&apikey={Api_Key}");

            List<GuildReward> GuildRewardMasterList = new List<GuildReward>();

            foreach (JObject GuildRewardObject in JObject.Parse(request.Response)["rewards"])
            {
                GuildRewardMasterList.Add(new GuildReward(GuildRewardObject));
            }
            return GuildRewardMasterList;
        }
        #endregion

        #region Guild Perks

        public List<GuildPerk> GetGuildPerks()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/guild/perks?locale={Locale}&apikey={Api_Key}");

            List<GuildPerk> GuildPerkMasterList = new List<GuildPerk>();

            foreach (JObject GuildPerkObject in JObject.Parse(request.Response)["perks"])
            {
                GuildPerkMasterList.Add(new GuildPerk(GuildPerkObject));
            }
            return GuildPerkMasterList;
        }
        #endregion

        #region Guild Achievements

        public List<Achievement> GetGuildAchievements()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/guild/achievements?locale={Locale}&apikey={Api_Key}");

            List<Achievement> GuildAchievementMasterList = new List<Achievement>();

            foreach (JObject GuildAchievementObjectList in JObject.Parse(request.Response)["achievements"])
            {
                foreach (JObject GuildAchievementObject in GuildAchievementObjectList["achievements"])
                {
                    GuildAchievementMasterList.Add(new Achievement(GuildAchievementObject));
                }
            }
            return GuildAchievementMasterList;
        }

        #endregion

        #region Item Classes

        public List<ItemClass> GetItemClasses()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/item/classes?locale={Locale}&apikey={Api_Key}");

            List<ItemClass> ItemClassMasterList = new List<ItemClass>();

            foreach (JObject ItemClassObject in JObject.Parse(request.Response)["classes"])
            {
                ItemClassMasterList.Add(new ItemClass(ItemClassObject));
            }
            return ItemClassMasterList;
        }

        #endregion

        #region Talents

        public enum CharacterClass
        {
            None,
            Warrior,
            Paladin,
            Hunter,
            Rogue,
            Priest,
            DeathKnight,
            Shaman,
            Mage,
            Warlock,
            Monk,
            Druid,
            DemonHunter

        }
        public List<Talent> GetTalents(CharacterClass characterClass)
        {
            string classID = String.Empty;

            switch (characterClass)
            {
                case CharacterClass.Warrior:
                    classID = "1";
                    break;
                case CharacterClass.Paladin:
                    classID = "2";
                    break;
                case CharacterClass.Hunter:
                    classID = "3";
                    break;
                case CharacterClass.Rogue:
                    classID = "4";
                    break;
                case CharacterClass.Priest:
                    classID = "5";
                    break;
                case CharacterClass.DeathKnight:
                    classID = "6";
                    break;
                case CharacterClass.Shaman:
                    classID = "7";
                    break;
                case CharacterClass.Mage:
                    classID = "8";
                    break;
                case CharacterClass.Warlock:
                    classID = "9";
                    break;
                case CharacterClass.Monk:
                    classID = "10";
                    break;
                case CharacterClass.Druid:
                    classID = "11";
                    break;
                case CharacterClass.DemonHunter:
                    classID = "12";
                    break;

            }
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/talents?locale={Locale}&apikey={Api_Key}");

            List<Talent> TalentMasterList = new List<Talent>();
           
            foreach (JArray TalentObject in JObject.Parse(request.Response)[classID]["talents"])
            {
                foreach (JArray TalentObjects in TalentObject)
                {
                    foreach (JObject talent in TalentObjects)
                    {

                        TalentMasterList.Add(new Talent(talent));
                    }
                }
            }
            return TalentMasterList;

        }

        #region Specs
        public List<Specialization> GetClassSpecializations(CharacterClass characterClass)
        {

            string classID = String.Empty;

            switch (characterClass)
            {
                case CharacterClass.Warrior:
                    classID = "1";
                    break;
                case CharacterClass.Paladin:
                    classID = "2";
                    break;
                case CharacterClass.Hunter:
                    classID = "3";
                    break;
                case CharacterClass.Rogue:
                    classID = "4";
                    break;
                case CharacterClass.Priest:
                    classID = "5";
                    break;
                case CharacterClass.DeathKnight:
                    classID = "6";
                    break;
                case CharacterClass.Shaman:
                    classID = "7";
                    break;
                case CharacterClass.Mage:
                    classID = "8";
                    break;
                case CharacterClass.Warlock:
                    classID = "9";
                    break;
                case CharacterClass.Monk:
                    classID = "10";
                    break;
                case CharacterClass.Druid:
                    classID = "11";
                    break;
                case CharacterClass.DemonHunter:
                    classID = "12";
                    break;

            }
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}wow/data/talents?locale={Locale}&apikey={Api_Key}");

            List<Specialization> SpecMasterList = new List<Specialization>();

            foreach (JObject TalentObjectList in JObject.Parse(request.Response)[classID]["specs"])
            {
                SpecMasterList.Add(new Specialization(TalentObjectList));
            }

            return SpecMasterList;
        }
        #endregion

        #endregion

        #region Pet Types

        public List<PetType> GetPetTypes()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Key}wow/data/pet/types?locale={Locale}&apikey={Api_Key}");

            List<PetType> PetTypeMasterList = new List<PetType>();

            foreach (JObject PetTypeObject in JObject.Parse(request.Response)["petTypes"])
            {
                PetTypeMasterList.Add(new PetType(PetTypeObject));
            }
            return PetTypeMasterList;
        }

        #endregion
        #endregion

        #endregion
    }
}

