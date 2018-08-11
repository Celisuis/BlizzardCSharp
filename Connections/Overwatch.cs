using BlizzardCSharp.Games.Overwatch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Connections
{
    public class Overwatch
    {
        private readonly OverwatchClient Client;

        private readonly string API_Url;
        private readonly string Region;
        private readonly string Platform;

        private readonly string User_Agent;

        public Overwatch(OverwatchClient client, string api_url, string region, string platform, string user_agent)
        {
            Client = client;
            API_Url = api_url;
            Region = region;
            Platform = platform;
            User_Agent = user_agent;
        }
        #region API Functions
        #region Player API

        public Profile RetrieveProfile(string battleTag)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}{battleTag}");
            return new Profile(JObject.Parse(request.Response));
        }

        public OverallStats RetrieveStats(string battleTag, MatchType matchType)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}{battleTag}");
            JObject profileData = JObject.Parse(request.Response);
            switch(matchType)
            {
                case MatchType.QuickPlay:
                    return new OverallStats(JObject.Parse(profileData["quickPlayStats"].ToString()));
                case MatchType.Competitive:
                    return new OverallStats(JObject.Parse(profileData["competitiveStats"].ToString()));
            }

            return null;    
        }


        public HeroStats RetrieveSpecificHeroStats(string battleTag, MatchType matchType, string heroName)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}{battleTag}");
            JObject profileData = JObject.Parse(request.Response);
            string hero = heroName.ToLower();

            switch (matchType)
            {
                case MatchType.QuickPlay:
                    return new HeroStats(JObject.Parse(profileData["quickPlayStats"]["careerStats"][$@"{hero}"].ToString()));
                case MatchType.Competitive:
                    return new HeroStats(JObject.Parse(profileData["competitiveStats"]["careerStats"][$@"{hero}"].ToString()));
            }

            return null;

        }

        public List<TopHero> RetrieveTopPlayedHeroes(string battleTag, MatchType matchType)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}{battleTag}");
            JObject profileData = JObject.Parse(request.Response);

            List<TopHero> TopPlayedHeroes = new List<TopHero>();

            if (matchType == MatchType.QuickPlay)
            {
                foreach (JObject heroObj in profileData["quickPlayStats"]["topHeroes"])
                {
                    TopHero tHero = new TopHero(heroObj);
                    TopPlayedHeroes.Add(tHero);
                }
            }

            if (matchType == MatchType.Competitive)
            {
                foreach (JObject heroObj in profileData["competitiveStats"]["topHeroes"])
                {
                    TopHero tHero = new TopHero(heroObj);
                    TopPlayedHeroes.Add(tHero);
                }
            }

            return TopPlayedHeroes;
        }

        public TopHero RetrieveSpecificTopHeroStats(string battleTag, MatchType matchType, string heroName)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}{battleTag}");
            JObject profileData = JObject.Parse(request.Response);
            string hero = heroName.ToLower();

            switch(matchType)
            {
                case MatchType.QuickPlay:
                    return new TopHero(JObject.Parse(profileData["quickPlayStats"]["topHeroes"][$@"{hero}"].ToString()));
                case MatchType.Competitive:
                    return new TopHero(JObject.Parse(profileData["competitiveStats"]["topHeroes"][$@"{hero}"].ToString()));
            }

            return null;
        }


        #endregion

        #region Information API

        public List<Hero> RetrieveHeroList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}heroes");
            JArray rawData = JArray.Parse(request.Response);

            List<Hero> HeroList = new List<Hero>();
            foreach (JObject heroObj in rawData)
            {
                Hero hero = new Hero(heroObj);
                HeroList.Add(hero);
            }

            return HeroList;

        }

        public Hero RetrieveHero(string heroName)
        {
            Request request = new Request(User_Agent);
            request.Get($"{API_Url}hero/{heroName}");

            return new Hero(JObject.Parse(request.Response));
        }
        #endregion
        #endregion

    }

    public enum MatchType
    {
        QuickPlay,
        Competitive
    }


}
