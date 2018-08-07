using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Raid
    {
        public string Name { get; internal set; }

        public int LFR { get; internal set; }

        public int Normal { get; internal set; }

        public int Heroic { get; internal set; }

        public int Mythic { get; internal set; }

        public int RaidID { get; internal set; }

        public List<RaidBoss> BossList { get; internal set; }

        public Raid(JToken RaidToken)
        {
            if (RaidToken["name"] != null)
                Name = RaidToken["name"].ToString();
            if (RaidToken["lfr"] != null)
                LFR = int.Parse(RaidToken["lfr"].ToString());
            if (RaidToken["normal"] != null)
                Normal = int.Parse(RaidToken["normal"].ToString());
            if (RaidToken["heroic"] != null)
                Heroic = int.Parse(RaidToken["heroic"].ToString());
            if (RaidToken["mythic"] != null)
                Mythic = int.Parse(RaidToken["mythic"].ToString());
            if (RaidToken["bosses"] != null && RaidToken["bosses"].HasValues)
            {
                BossList = new List<RaidBoss>();

                foreach (JObject BossToken in RaidToken["bosses"])
                {
                    RaidBoss raidBoss = new RaidBoss(BossToken);
                    BossList.Add(raidBoss);
                }
            }
        }
    }

    public class RaidBoss
    {
        public int ID { get; internal set; }

        public string Name { get; internal set; }

        public int LFRKills { get; internal set; }

        public int NormalKills { get; internal set; }

        public int HeroicKills { get; internal set; }

        public int MythicKills { get; internal set; }

        public RaidBoss(JToken BossToken)
        {
            if (BossToken["id"] != null)
                ID = int.Parse(BossToken["id"].ToString());
            if (BossToken["name"] != null)
                Name = BossToken["name"].ToString();
            if (BossToken["lfrKills"] != null)
                LFRKills = int.Parse(BossToken["lfrKills"].ToString());
            if (BossToken["normalKills"] != null)
                NormalKills = int.Parse(BossToken["normalKills"].ToString());
            if (BossToken["heroicKills"] != null)
                HeroicKills = int.Parse(BossToken["heroicKills"].ToString());
            if (BossToken["mythicKills"] != null)
                MythicKills = int.Parse(BossToken["mythicKills"].ToString());
        }
    }
}
