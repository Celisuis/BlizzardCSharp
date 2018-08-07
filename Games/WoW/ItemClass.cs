using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class ItemClass
    {
        public class SubClass
        {
            public int SubClassID { get; internal set; }

            public string Name { get; internal set; }

            public SubClass(JObject SubToken)
            {
                if (SubToken["subclass"] != null)
                    SubClassID = int.Parse(SubToken["subclass"].ToString());
                if (SubToken["name"] != null)
                    Name = SubToken["name"].ToString();
            }
        }
        public int ClassID { get; internal set; }

        public string Name { get; internal set; }

        public List<SubClass> SubClasses { get; internal set; }

        public ItemClass(JToken rawData)
        {
            if (rawData["class"] != null)
                ClassID = int.Parse(rawData["class"].ToString());
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["subclasses"] != null && rawData["subclasses"].HasValues)
            {
                SubClasses = new List<SubClass>();

                foreach (JObject subclass in rawData["subclasses"])
                {
                    SubClasses.Add(new SubClass(subclass));
                }
            }
        }
    }
}
