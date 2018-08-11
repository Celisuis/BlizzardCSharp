using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Talent
    {
        

        public int Tier { get; internal set; }

        public int Column { get; internal set; }

        public Spell Spell { get; internal set; }

        public Specialization Specialization { get; internal set; }

        public Talent(JObject rawData)
        {
            if (rawData["tier"] != null)
                Tier = int.Parse(rawData["tier"].ToString());
            if (rawData["column"] != null)
                Column = int.Parse(rawData["column"].ToString());
            if (rawData["spell"] != null)
                Spell = new Spell(JObject.Parse(rawData["spell"].ToString()));
            if (rawData["spec"] != null)
                Specialization = new Specialization(JObject.Parse(rawData["spec"].ToString()));
        }


    }
}
