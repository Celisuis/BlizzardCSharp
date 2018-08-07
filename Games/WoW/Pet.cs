using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Pet
    {
        public class Stats
        {
            public long SpeciesID { get; internal set; }

            public long BreedID { get; internal set; }

            public long PetQualityID { get; internal set; }
            
            public long Level { get; internal set; }

            public long Health { get; internal set; }

            public long Power { get; internal set; }

            public long Speed { get; internal set; }

            public Stats(JObject StatsObject)
            {
                if (StatsObject["speciesId"] != null)
                    SpeciesID = long.Parse(StatsObject["speciesId"].ToString());
                if (StatsObject["breedId"] != null)
                    BreedID = long.Parse(StatsObject["breedId"].ToString());
                if (StatsObject["petQualityId"] != null)
                    PetQualityID = long.Parse(StatsObject["petQualityId"].ToString());
                if (StatsObject["level"] != null)
                    Level = long.Parse(StatsObject["level"].ToString());
                if (StatsObject["health"] != null)
                    Health = long.Parse(StatsObject["health"].ToString());
                if (StatsObject["power"] != null)
                    Power = long.Parse(StatsObject["power"].ToString());
                if (StatsObject["speed"] != null)
                    Speed = long.Parse(StatsObject["speed"].ToString());
            }
        }

        public class Ability
        {
            public long Slot { get; internal set; }

            public long Order { get; internal set; }

            public long RequiredLevel { get; internal set; }

            public long AbilityID { get; internal set; }

            public string Name { get; internal set; }

            public string Icon { get; internal set; }

            public long Cooldown { get; internal set; }

            public long Rounds { get; internal set; }

            public long PetTypeID { get; internal set; }

            public bool IsPassive { get; internal set; }

            public bool HideHints { get; internal set; }

            public Ability(JObject AbilityObject)
            {
                if (AbilityObject["slot"] != null)
                    Slot = long.Parse(AbilityObject["slot"].ToString());
                if (AbilityObject["order"] != null)
                    Order = long.Parse(AbilityObject["order"].ToString());
                if (AbilityObject["requiredLevel"] != null)
                    RequiredLevel = long.Parse(AbilityObject["requiredLevel"].ToString());
                if (AbilityObject["id"] != null)
                    AbilityID = long.Parse(AbilityObject["id"].ToString());
                if (AbilityObject["name"] != null)
                    Name = AbilityObject["name"].ToString();
                if (AbilityObject["icon"] != null)
                    Icon = AbilityObject["icon"].ToString();
                if (AbilityObject["cooldown"] != null)
                    Cooldown = long.Parse(AbilityObject["cooldown"].ToString());
                if (AbilityObject["rounds"] != null)
                    Rounds = long.Parse(AbilityObject["rounds"].ToString());
                if (AbilityObject["petTypeId"] != null)
                    PetTypeID = long.Parse(AbilityObject["petTypeId"].ToString());
                if (AbilityObject["isPassive"] != null)
                    IsPassive = bool.Parse(AbilityObject["isPassive"].ToString());
                if (AbilityObject["hideHints"] != null)
                    HideHints = bool.Parse(AbilityObject["hideHints"].ToString());
            }
        }

        public class Species
        {
            public long SpeciesID { get; internal set; }

            public long PetTypeID { get; internal set; }

            public long CreatureID { get; internal set; }

            public string Name { get; internal set; }

            public bool CanBattle { get; internal set; }

            public string Icon { get; internal set; }

            public string Description { get; internal set; }

            public string Source { get; internal set; }

            public List<Ability> PetAbilities { get; internal set; }

            public Species(JObject SpeciesObject)
            {
                if (SpeciesObject["speciesId"] != null)
                    SpeciesID = long.Parse(SpeciesObject["speciesId"].ToString());
                if (SpeciesObject["petTypeId"] != null)
                    PetTypeID = long.Parse(SpeciesObject["petTypeId"].ToString());
                if (SpeciesObject["creatureId"] != null)
                    CreatureID = long.Parse(SpeciesObject["creatureId"].ToString());
                if (SpeciesObject["name"] != null)
                    Name = SpeciesObject["name"].ToString();
                if (SpeciesObject["canBattle"] != null)
                    CanBattle = bool.Parse(SpeciesObject["canBattle"].ToString());
                if (SpeciesObject["icon"] != null)
                    Icon = SpeciesObject["icon"].ToString();
                if (SpeciesObject["description"] != null)
                    Description = SpeciesObject["description"].ToString();
                if (SpeciesObject["source"] != null)
                    Source = SpeciesObject["source"].ToString();
                if (SpeciesObject["abilities"] != null && SpeciesObject["abilities"].HasValues)
                {
                    PetAbilities = new List<Ability>();

                    foreach (JObject AbilityObject in SpeciesObject["abilities"])
                    {
                        PetAbilities.Add(new Ability(AbilityObject));
                    }
                }
            }
        }

        public bool CanBattle { get; internal set; }

        public long CreatureID { get; internal set; }

        public string Name { get; internal set; }

        public string Family { get; internal set; }

        public string Icon { get; internal set; }

        public long QualityID { get; internal set; }

        public long ItemID { get; internal set; }
        public Stats PetStats { get; internal set; }

        public List<string> StrongAgainst { get; internal set; }

        public long TypeID { get; internal set; }

        public List<string> WeakAgainst { get; internal set; }

        public bool IsFavourite { get; internal set; }

        public bool FirstAbilitySlotSelected { get; internal set; }

        public bool SecondAbilitySlotSelected { get; internal set; }

        public bool ThirdAbilitySlotSelected { get; internal set; }

        public string CreatureName { get; internal set; }

        public Pet(JObject rawData)
        {
            if (rawData["canBattle"] != null)
                CanBattle = bool.Parse(rawData["canBattle"].ToString());
            if (rawData["creatureId"] != null)
                CreatureID = long.Parse(rawData["creatureId"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["family"] != null)
                Family = rawData["family"].ToString();
            if (rawData["icon"] != null)
                Icon = rawData["icon"].ToString();
            if (rawData["qualityId"] != null)
                QualityID = long.Parse(rawData["qualityId"].ToString());
            if (rawData["itemId"] != null)
                ItemID = long.Parse(rawData["itemId"].ToString());
            if (rawData["stats"] != null)
                PetStats = new Stats(JObject.Parse(rawData["stats"].ToString()));
            if (rawData["strongAgainst"] != null && rawData["strongAgainst"].HasValues)
            {
                StrongAgainst = new List<string>();
                foreach (string strong in rawData["strongAgainst"])
                {
                    StrongAgainst.Add(strong);
                }
            }
            if (rawData["typeId"] != null)
                TypeID = long.Parse(rawData["typeId"].ToString());
            if (rawData["weakAgainst"] != null && rawData["weakAgainst"].HasValues)
            {
                WeakAgainst = new List<string>();

                foreach (string weak in rawData["weakAgainst"])
                {
                    WeakAgainst.Add(weak);
                }
            }
            if (rawData["isFavorite"] != null)
                IsFavourite = bool.Parse(rawData["isFavorite"].ToString());
            if (rawData["isFirstAbilitySlotSelected"] != null)
                FirstAbilitySlotSelected = bool.Parse(rawData["isFirstAbilitySlotSelected"].ToString());
            if (rawData["isSecondAbilitySlotSelected"] != null)
                SecondAbilitySlotSelected = bool.Parse(rawData["isSecondAbilitySlotSelected"].ToString());
            if (rawData["isThirdAbilitySlotSelected"] != null)
                ThirdAbilitySlotSelected = bool.Parse(rawData["isThirdAbilitySlotSelected"].ToString());
        }
    }
}
