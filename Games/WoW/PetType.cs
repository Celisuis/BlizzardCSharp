using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class PetType
    {
        public int ID { get; internal set; }

        public string Key { get; internal set; }

        public string Name { get; internal set; }

        public int TypeAbilityID { get; internal set; }

        public int StrongAgainstID { get; internal set; }

        public int WeakAgainstID { get; internal set; }

        public PetType(JObject rawData)
        {
            ID = int.Parse(rawData["id"].ToString());
            Key = rawData["key"].ToString();
            Name = rawData["name"].ToString();
            TypeAbilityID = int.Parse(rawData["typeAbilityId"].ToString());
            StrongAgainstID = int.Parse(rawData["strongAgainstId"].ToString());
            WeakAgainstID = int.Parse(rawData["weakAgainstId"].ToString());
        }
    }
}
