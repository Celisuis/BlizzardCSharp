using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Talent
    {
        public Skill ActualSkill { get; internal set; }

        public List<Rune> Runes { get; internal set; }

        public Talent(JObject rawData)
        {
            if (rawData["skill"] != null)
                ActualSkill = new Skill(JObject.Parse(rawData["skill"].ToString()));
            if(rawData["runes"] != null && rawData["runes"].HasValues)
            {
                Runes = new List<Rune>();

                foreach(JObject runeObject in rawData["runes"])
                {
                    Rune rune = new Rune(runeObject);
                    Runes.Add(rune);
                }
            }
        }
    }
}
