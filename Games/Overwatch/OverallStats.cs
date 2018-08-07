using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class OverallStats
    {
        public List<TopHero> TopHeroes { get; internal set; }

        public List<HeroStats> CareerStats { get; internal set; }

        public OverallStats(JObject rawData)
        {
            if (rawData["topHeroes"] != null && rawData["topHeroes"].HasValues)
            {
                TopHeroes = new List<TopHero>();
                foreach (JObject heroObject in rawData["topHeroes"])
                {
                    TopHero hero = new TopHero(heroObject);
                    TopHeroes.Add(hero);
                }
            }
            if (rawData["careerStats"] != null && rawData["careerStats"].HasValues)
            {
                CareerStats = new List<HeroStats>();
                foreach(JObject statsObject in rawData["careerStats"])
                {
                    HeroStats stats = new HeroStats(statsObject);
                    CareerStats.Add(stats);
                }
            }


        }
    }
}
