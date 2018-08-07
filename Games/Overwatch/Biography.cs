using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class Biography
    {
        public string RealName { get; internal set; }

        public string Age { get; internal set; }

        public string Occupation { get; internal set; }

        public string BaseOfOperations { get; internal set; }

        public string Affiliation { get; internal set; }

        public Biography(JObject rawData)
        {
            if (rawData["realName"] != null)
                RealName = rawData["realName"].ToString();
            if (rawData["age"] != null)
                Age = rawData["age"].ToString();
            if (rawData["occupation"] != null)
                Occupation = rawData["occupation"].ToString();
            if (rawData["baseOfOperations"] != null)
                BaseOfOperations = rawData["baseOfOperations"].ToString();
            if (rawData["affiliation"] != null)
                Affiliation = rawData["affiliation"].ToString();
        }
    }
}
