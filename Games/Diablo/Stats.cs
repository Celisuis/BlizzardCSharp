using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Stats
    {
        public double GoldFind { get; internal set; }

        public double MagicFind { get; internal set; }

        public double ExperienceBonus { get; internal set; }

        public double Life { get; internal set; }

        public double Damage { get; internal set; }

        public double Toughness { get; internal set; }

        public double Healing { get; internal set; }

        public double AttackSpeed { get; internal set; }

        public double Armor { get; internal set; }

        public double Strength { get; internal set; }

        public double Dexterity { get; internal set; }

        public double Intelligence { get; internal set; }

        public double Vitality { get; internal set; }

        public double PhysicalResistance { get; internal set; }

        public double FireResistance { get; internal set; }

        public double ColdResistance { get; internal set; }

        public double LightningResistance { get; internal set; }

        public double PoisonResistance { get; internal set; }

        public double ArcaneResistance { get; internal set; }

        public double BlockChance { get; internal set; }

        public double MinimumBlockAmount { get; internal set; }

        public double MaximumBlockAmount { get; internal set; }

        public double CriticalChance { get; internal set; }

        public double Thorns { get; internal set; }

        public double LifeSteal { get; internal set; }

        public double LifePerKill { get; internal set; }

        public double LifeOnHit { get; internal set; }

        public double PrimaryResource { get; internal set; }

        public double SecondaryResource { get; internal set; }

        

        public Stats(JObject rawData)
        {
            if (rawData["goldFind"] != null)
                GoldFind = double.Parse(rawData["goldFind"].ToString());
            if (rawData["magicFind"] != null)
                MagicFind = double.Parse(rawData["magicFind"].ToString());
            if (rawData["experienceBonus"] != null)
                ExperienceBonus = double.Parse(rawData["experienceBonus"].ToString());
            if (rawData["life"] != null)
                Life = double.Parse(rawData["life"].ToString());
            if (rawData["damage"] != null)
                Damage = double.Parse(rawData["damage"].ToString());
            if (rawData["toughness"] != null)
                Toughness = double.Parse(rawData["toughness"].ToString());
            if (rawData["healing"] != null)
                Healing = double.Parse(rawData["healing"].ToString());
            if (rawData["attackSpeed"] != null)
                AttackSpeed = double.Parse(rawData["attackSpeed"].ToString());
            if (rawData["armor"] != null)
                Armor = double.Parse(rawData["armor"].ToString());
            if (rawData["strength"] != null)
                Strength = double.Parse(rawData["strength"].ToString());
            if (rawData["dexterity"] != null)
                Dexterity = double.Parse(rawData["dexterity"].ToString());
            if (rawData["intelligence"] != null)
                Intelligence = double.Parse(rawData["intelligence"].ToString());
            if (rawData["vitality"] != null)
                Vitality = double.Parse(rawData["vitality"].ToString());
            if (rawData["physicalResist"] != null)
                PhysicalResistance = double.Parse(rawData["physicalResist"].ToString());
            if (rawData["fireResist"] != null)
                FireResistance = double.Parse(rawData["fireResist"].ToString());
            if (rawData["coldResist"] != null)
                ColdResistance = double.Parse(rawData["coldResist"].ToString());
            if (rawData["lightningResist"] != null)
                LightningResistance = double.Parse(rawData["lightningResist"].ToString());
            if (rawData["poisonResist"] != null)
                PoisonResistance = double.Parse(rawData["poisonResist"].ToString());
            if (rawData["arcaneResist"] != null)
                ArcaneResistance = double.Parse(rawData["arcaneResist"].ToString());
            if (rawData["blockChance"] != null)
                BlockChance = double.Parse(rawData["blockChance"].ToString());
            if (rawData["blockAmountMin"] != null)
                MinimumBlockAmount = double.Parse(rawData["blockAmountMin"].ToString());
            if (rawData["blockAmountMax"] != null)
                MaximumBlockAmount = double.Parse(rawData["blockAmountMax"].ToString());
            if (rawData["critChance"] != null)
                CriticalChance = double.Parse(rawData["critChance"].ToString());
            if (rawData["thorns"] != null)
                Thorns = double.Parse(rawData["thorns"].ToString());
            if (rawData["lifeSteal"] != null)
                LifeSteal = double.Parse(rawData["lifeSteal"].ToString());
            if (rawData["lifePerKill"] != null)
                LifePerKill = double.Parse(rawData["lifePerKill"].ToString());
            if (rawData["lifeOnHit"] != null)
                LifeOnHit = double.Parse(rawData["lifeOnHit"].ToString());
            if (rawData["primaryResource"] != null)
                PrimaryResource = double.Parse(rawData["primaryResource"].ToString());
            if (rawData["secondaryResource"] != null)
                SecondaryResource = double.Parse(rawData["secondaryResource"].ToString());
        } 
    }
}
