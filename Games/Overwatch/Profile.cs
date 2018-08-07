using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlizzardCSharp.Helpers;

namespace BlizzardCSharp.Games.Overwatch
{
    public class Profile
    {
        public string IconPath { get; internal set; }
        public Image Icon { get; internal set; }

        public string Name { get; internal set; }

        public int Level { get; internal set; }

        public string LevelIconPath { get; internal set; }
        public Image LevelIcon { get; internal set; }

        public int PrestigeLevel { get; internal set; }

        public string PrestigeIconPath { get; internal set; }
        public Image PrestigeIcon { get; internal set; }

        public int Rating { get; internal set; }

        public string RatingIconPath { get; internal set; }

        public Image RatingIcon { get; internal set; }

        public int GamesWon { get; internal set; }

        public OverallStats QuickPlayStats { get; internal set; }

        public OverallStats CompetitiveStats { get; internal set; }

        public Profile(JObject rawData)
        {
            if(rawData["icon"] != null)
            {
                IconPath = rawData["icon"].ToString();
                Icon = ImageHelper.RetrieveImage(IconPath);
            }
            if (rawData["name"] != null)
                Name = rawData["name"].ToString();
            if (rawData["level"] != null)
                Level = int.Parse(rawData["level"].ToString());
            if(rawData["levelIcon"] != null)
            {
                LevelIconPath = rawData["levelIcon"].ToString();
                LevelIcon = ImageHelper.RetrieveImage(LevelIconPath);
            }
            if (rawData["prestige"] != null)
                PrestigeLevel = int.Parse(rawData["prestige"].ToString());
            if(rawData["prestigeIcon"] != null)
            {
                PrestigeIconPath = rawData["prestigeIcon"].ToString();
                PrestigeIcon = ImageHelper.RetrieveImage(PrestigeIconPath);
            }
            if (rawData["rating"] != null)
                Rating = int.Parse(rawData["rating"].ToString());
            if(rawData["ratingIcon"] != null)
            {
                RatingIconPath = rawData["ratingIcon"].ToString();
                RatingIcon = ImageHelper.RetrieveImage(RatingIconPath);
            }
            if (rawData["gamesWon"] != null)
                GamesWon = int.Parse(rawData["gamesWon"].ToString());
            if (rawData["quickPlayStats"] != null)
                QuickPlayStats = new OverallStats(JObject.Parse(rawData["quickPlayStats"].ToString()));
            if (rawData["competitiveStats"] != null)
                CompetitiveStats = new OverallStats(JObject.Parse(rawData["competitiveStats"].ToString()));
        }

        
    }
}
