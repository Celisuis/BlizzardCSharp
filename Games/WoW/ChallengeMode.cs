using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class ChallengeMode
    {
        public class ChallengeModeRealm
        {
            public string Name { get; internal set; }

            public string Slug { get; internal set; }

            public string Battlegroup { get; internal set; }

            public string Locale { get; internal set; }

            public string TimeZone { get; internal set; }

            public List<string> ConnectedRealms { get; internal set; }

            public ChallengeModeRealm(JObject RealmObject)
            {
                Name = RealmObject["name"].ToString();
                Slug = RealmObject["slug"].ToString();
                Battlegroup = RealmObject["battlegroup"].ToString();
                Locale = RealmObject["locale"].ToString();
                TimeZone = RealmObject["timezone"].ToString();
                ConnectedRealms = new List<string>();
                foreach (string ConnectedRealm in RealmObject["connected_realms"])
                {
                    ConnectedRealms.Add(ConnectedRealm);
                }
            }


        }

        public class ChallengeModeMap
        {
            public class ChallengeModeMapCriteria
            {
                public long Time { get; internal set; }

                public int Hours { get; internal set; }

                public int Minutes { get; internal set; }

                public int Seconds { get; internal set; }

                public int Milliseconds { get; internal set; }

                public bool Positive { get; internal set; }

                public ChallengeModeMapCriteria(JObject MapCriteriaObject)
                {
                    Time = long.Parse(MapCriteriaObject["time"].ToString());
                    Hours = int.Parse(MapCriteriaObject["hours"].ToString());
                    Minutes = int.Parse(MapCriteriaObject["minutes"].ToString());
                    Seconds = int.Parse(MapCriteriaObject["seconds"].ToString());
                    Milliseconds = int.Parse(MapCriteriaObject["milliseconds"].ToString());
                    Positive = bool.Parse(MapCriteriaObject["isPositive"].ToString());
                }
            }

            public int ID { get; internal set; }

            public string Name { get; internal set; }

            public string Slug { get; internal set; }

            public bool HasChallengeMode { get; internal set; }

            public ChallengeModeMapCriteria Bronze { get; internal set; }
            public ChallengeModeMapCriteria Silver { get; internal set; }
            public ChallengeModeMapCriteria Gold { get; internal set; }

            public ChallengeModeMap(JObject MapObject)
            {
                ID = int.Parse(MapObject["id"].ToString());
                if (MapObject["name"] != null && MapObject["name"].HasValues)
                    Name = MapObject["name"].ToString();
                Slug = MapObject["slug"].ToString();
                HasChallengeMode = bool.Parse(MapObject["hasChallengeMode"].ToString());
                Bronze = new ChallengeModeMapCriteria(JObject.Parse(MapObject["bronzeCriteria"].ToString()));
                Silver = new ChallengeModeMapCriteria(JObject.Parse(MapObject["silverCriteria"].ToString()));
                Gold = new ChallengeModeMapCriteria(JObject.Parse(MapObject["goldCriteria"].ToString()));
            }
        }

        public class ChallengeModeGroup
        {
            public class ChallengeModeGroupTime
            {
                public long Time { get; internal set; }
                public int Hours { get; internal set; }

                public int Minutes { get; internal set; }

                public int Seconds { get; internal set; }

                public int Milliseconds { get; internal set; }

                public bool Positive { get; internal set; }

                public ChallengeModeGroupTime(JObject GroupTimeObject)
                {
                    Time = long.Parse(GroupTimeObject["time"].ToString());
                    Hours = int.Parse(GroupTimeObject["hours"].ToString());
                    Minutes = int.Parse(GroupTimeObject["minutes"].ToString());
                    Seconds = int.Parse(GroupTimeObject["seconds"].ToString());
                    Milliseconds = int.Parse(GroupTimeObject["milliseconds"].ToString());
                    Positive = bool.Parse(GroupTimeObject["isPositive"].ToString());
                }

            }

            public class ChallengeModeGroupMember
            {
                public Character GroupMember { get; internal set; }

                public Specialization CharacterSpec { get; internal set; }

                public ChallengeModeGroupMember(JObject GroupMemberObject)
                {
                    if (GroupMemberObject["character"] != null && GroupMemberObject["character"].HasValues)
                        GroupMember = new Character(JObject.Parse(GroupMemberObject["character"].ToString()));
                    if (GroupMemberObject["spec"] != null && GroupMemberObject["spec"].HasValues)
                        CharacterSpec = new Specialization(JObject.Parse(GroupMemberObject["spec"].ToString()));
                }
            }

            public int Ranking { get; internal set; }

            public ChallengeModeGroupTime Time { get; internal set; }

            public string Date { get; internal set; }

            public string Medal { get; internal set; }

            public string Faction { get; internal set; }

            public bool Recurring { get; internal set; }

            public List<ChallengeModeGroupMember> GroupMembers { get; internal set; }

            public Guild GuildName { get; internal set; }

            public ChallengeModeGroup(JObject GroupObject)
            {
                GroupMembers = new List<ChallengeModeGroupMember>();
                Ranking = int.Parse(GroupObject["ranking"].ToString());
                Time = new ChallengeModeGroupTime(JObject.Parse(GroupObject["time"].ToString()));
                Date = GroupObject["date"].ToString();
                if (GroupObject["medal"] != null && GroupObject["medal"].HasValues)
                    Medal = GroupObject["medal"].ToString();
                Faction = GroupObject["faction"].ToString();
                Recurring = bool.Parse(GroupObject["isRecurring"].ToString());
                if (GroupObject["members"] != null && GroupObject["members"].HasValues)
                {
                    foreach (JObject GroupMemberObject in GroupObject["members"])
                        GroupMembers.Add(new ChallengeModeGroupMember(GroupMemberObject));
                }
                if (GroupObject["guild"] != null && GroupObject["guild"].HasValues)
                    GuildName = new Guild(JObject.Parse(GroupObject["guild"].ToString()));
            }
        }

        public ChallengeModeRealm Realm { get; internal set; }

        public ChallengeModeMap MapInstance { get; internal set; }

        public List<ChallengeModeGroup> ChallengeGroup { get; internal set; }

        public ChallengeMode(JObject rawData)
        {
            ChallengeGroup = new List<ChallengeModeGroup>();

            if (rawData["realm"] != null && rawData["realm"].HasValues)
                Realm = new ChallengeModeRealm(JObject.Parse(rawData["realm"].ToString()));
            if (rawData["map"] != null && rawData["map"].HasValues)
                MapInstance = new ChallengeModeMap(JObject.Parse(rawData["map"].ToString()));
            if (rawData["groups"] != null && rawData["groups"].HasValues)
            {
                foreach (JObject GroupObject in rawData["groups"])
                    ChallengeGroup.Add(new ChallengeModeGroup(GroupObject));
            }
        }
    }
}
