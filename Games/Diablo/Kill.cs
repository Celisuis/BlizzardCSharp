using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Kill
    {
        public int Elites { get; internal set; }

        public int Monsters { get; internal set; }

        public int HardcoreMonsters { get; internal set; }

        public Kill(JObject rawData)
        {
            if (rawData["elites"] != null)
                Elites = int.Parse(rawData["elites"].ToString());
            if (rawData["monsters"] != null)
                Monsters = int.Parse(rawData["monsters"].ToString());
            if (rawData["hardcoreMonsters"] != null)
                HardcoreMonsters = int.Parse(rawData["hardcoreMonsters"].ToString());
        }
    }
}
