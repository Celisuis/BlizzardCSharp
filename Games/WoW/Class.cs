using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Class
    {
        public int ClassID { get; internal set; }

        public int Mask { get; internal set; }

        public string PowerType { get; internal set; }

        public string Name { get; internal set; }

        public Class(JObject rawData)
        {
            ClassID = int.Parse(rawData["id"].ToString());
            Mask = int.Parse(rawData["mask"].ToString());
            PowerType = rawData["powerType"].ToString();
            Name = rawData["name"].ToString();
        }
    }
}
