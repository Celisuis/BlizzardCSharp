using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Realm
    {
        public class RealmZone
        {
            public int Area { get; internal set; }

            [JsonProperty("controlling-faction")]
            public int ControllingFaction { get; internal set; }

            public int Status { get; internal set; }

            public long Next { get; internal set; }

            public RealmZone(JObject ZoneObject)
            {
                Area = int.Parse(ZoneObject["area"].ToString());
                ControllingFaction = int.Parse(ZoneObject["controlling-faction"].ToString());
                Status = int.Parse(ZoneObject["status"].ToString());
                Next = long.Parse(ZoneObject["next"].ToString());
            }
        }

        public string Type { get; internal set; }

        public string Population { get; internal set; }

        public bool Queue { get; internal set; }


        public bool Status { get; internal set; }

        public string Name { get; internal set; }

        public string Slug { get; internal set; }

        public string Battlegroup { get; internal set; }

        public string Locale { get; internal set; }

        public string TimeZone { get; internal set; }

        public List<string> ConnectedRealms { get; internal set; }

        public Realm(JObject rawData)
        {
            Type = rawData["type"].ToString();
            Population = rawData["population"].ToString();
            Queue = bool.Parse(rawData["queue"].ToString());
            Status = bool.Parse(rawData["status"].ToString());
            Name = rawData["name"].ToString();
            Slug = rawData["slug"].ToString();
            Battlegroup = rawData["battlegroup"].ToString();
            Locale = rawData["locale"].ToString();
            TimeZone = rawData["timezone"].ToString();
            ConnectedRealms = new List<string>();

            foreach (string realm in rawData["connected_realms"])
            {
                ConnectedRealms.Add(realm);
            }
        }
    }
}
