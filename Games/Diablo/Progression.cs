using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class Progression
    {
        public bool ActOne { get; internal set; }

        public bool ActTwo { get; internal set; }

        public bool ActThree { get; internal set; }

        public bool ActFour { get; internal set; }

        public bool ActFive { get; internal set; }

        public Progression(JObject rawData)
        {
            if (rawData["act1"] != null)
                ActOne = bool.Parse(rawData["act1"].ToString());
            if (rawData["act2"] != null)
                ActTwo = bool.Parse(rawData["act2"].ToString());
            if (rawData["act3"] != null)
                ActThree = bool.Parse(rawData["act3"].ToString());
            if (rawData["act4"] != null)
                ActFour = bool.Parse(rawData["act4"].ToString());
            if (rawData["act5"] != null)
                ActFive = bool.Parse(rawData["act5"].ToString());
        }
    }
}
