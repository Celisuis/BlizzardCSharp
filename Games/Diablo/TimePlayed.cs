using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class TimePlayed
    {
        public double DemonHunter { get; internal set; }

        public double Barbarian { get; internal set; }

        public double WitchDoctor { get; internal set; }

        public double Necromancer { get; internal set; }

        public double Wizard { get; internal set; }

        public double Monk { get; internal set; }

        public double Crusader { get; internal set; }

        public TimePlayed(JObject rawData)
        {
            if (rawData["demon-hunter"] != null)
                DemonHunter = double.Parse(rawData["demon-hunter"].ToString());
            if (rawData["barbarian"] != null)
                Barbarian = double.Parse(rawData["barbarian"].ToString());
            if (rawData["witch-doctor"] != null)
                WitchDoctor = double.Parse(rawData["witch-doctor"].ToString());
            if (rawData["necromancer"] != null)
                Necromancer = double.Parse(rawData["necromancer"].ToString());
            if (rawData["wizard"] != null)
                Wizard = double.Parse(rawData["wizard"].ToString());
            if (rawData["monk"] != null)
                Monk = double.Parse(rawData["monk"].ToString());
            if (rawData["crusader"] != null)
                Crusader = double.Parse(rawData["crusader"].ToString());
        }
    }
}
