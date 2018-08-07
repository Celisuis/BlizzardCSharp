using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class Story
    {
        public Biography Biography { get; internal set; }

        public string CatchPhrase { get; internal set; }

        public string Backstory { get; internal set; }

        public Story(JObject rawData)
        {
            if (rawData["biography"] != null)
                Biography = new Biography(JObject.Parse(rawData["biography"].ToString()));
            if (rawData["catchPhrase"] != null)
                CatchPhrase = rawData["catchPhrase"].ToString();
            if (rawData["backStory"] != null)
                Backstory = rawData["backStory"].ToString();
        }
    }
}
