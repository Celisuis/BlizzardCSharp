using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.Overwatch
{
    public class TopHero
    {
        public string TimePlayed { get; internal set; }

        public int TimePlayedInSeconds { get; internal set; }

        public int GamesWon { get; internal set; }

        public int WinPercentage { get; internal set; }

        public int WeaponAccuracy { get; internal set; }

        public int EliminationsPerLife { get; internal set; }

        public int BestMultiKill { get; internal set; }

        public int ObjectiveKills { get; internal set; }

        public TopHero(JObject rawData)
        {
            if (rawData["timePlayed"] != null)
                TimePlayed = rawData["timePlayed"].ToString();
            if (rawData["timePlayedInSeconds"] != null)
                TimePlayedInSeconds = int.Parse(rawData["timePlayedInSeconds"].ToString());
            if (rawData["gamesWon"] != null)
                GamesWon = int.Parse(rawData["gamesWon"].ToString());
            if (rawData["winPercentage"] != null)
                WinPercentage = int.Parse(rawData["winPercentage"].ToString());
            if (rawData["weaponAccuracy"] != null)
                WeaponAccuracy = int.Parse(rawData["weaponAccuracy"].ToString());
            if (rawData["eliminationsPerLife"] != null)
                EliminationsPerLife = int.Parse(rawData["eliminationsPerLife"].ToString());
            if (rawData["multiKillBest"] != null)
                BestMultiKill = int.Parse(rawData["multiKillBest"].ToString());
            if (rawData["objectiveKills"] != null)
                ObjectiveKills = int.Parse(rawData["objectiveKills"].ToString());
        }
    }
}
