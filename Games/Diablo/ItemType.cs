using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Diablo
{
    public class ItemType
    {
        public string ID { get; internal set; }

        public string Name { get; internal set; }

        public string Path { get; internal set; }


        public ItemType(JObject rawData)
        {
            if (rawData["id"] != null)
                ID = rawData["id"].ToString();
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["path"] != null)
                Path = rawData["path"].ToString();
        }
    }
}
