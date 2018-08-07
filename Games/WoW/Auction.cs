using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Games.WoW
{
    public class Auction
    {
        public class AuctionBonusID
        {
            public int BonusListID { get; internal set; }

            public AuctionBonusID(JObject bonusObject)
            {
                BonusListID = int.Parse(bonusObject["bonusListId"].ToString());
            }
        }

        public class AuctionModifier
        {
            public int Type { get; internal set; }

            public long Value { get; internal set; }

            public AuctionModifier(JObject modifierObject)
            {
                Type = int.Parse(modifierObject["type"].ToString());
                Value = long.Parse(modifierObject["value"].ToString());
            }
        }

        public long Auc { get; internal set; }

        public int Item { get; internal set; }

        public string Owner { get; internal set; }

        public string OwnerRealm { get; internal set; }

        public long Bid { get; internal set; }

        public long Buyout { get; internal set; }

        public int Quantity { get; internal set; }

        public string TimeLeft { get; internal set; }

        public int Random { get; internal set; }

        public long Seed { get; internal set; }

        public int Context { get; internal set; }
        public List<AuctionBonusID> BonusList { get; internal set; }

        public List<AuctionModifier> ModifierList { get; internal set; }

        public int PetSpeciesID { get; internal set; }

        public int PetBreedID { get; internal set; }

        public int PetLevel { get; internal set; }

        public int PetQualityID { get; internal set; }

        public Auction(JObject rawData)
        {
            if (rawData["auc"] != null)
                Auc = long.Parse(rawData["auc"].ToString());
            if (rawData["item"] != null)
                Item = int.Parse(rawData["item"].ToString());
            if (rawData["owner"] != null)
                Owner = rawData["owner"].ToString();
            if (rawData["ownerRealm"] != null)
                OwnerRealm = rawData["ownerRealm"].ToString();
            if (rawData["bid"] != null)
                Bid = long.Parse(rawData["bid"].ToString());
            if (rawData["buyout"] != null)
                Buyout = long.Parse(rawData["buyout"].ToString());
            if (rawData["quantity"] != null)
                Quantity = int.Parse(rawData["quantity"].ToString());
            if (rawData["timeLeft"] != null)
                TimeLeft = rawData["timeLeft"].ToString();
            if (rawData["rand"] != null)
                Random = int.Parse(rawData["rand"].ToString());
            if (rawData["seed"] != null)
                Seed = long.Parse(rawData["seed"].ToString());
            if (rawData["context"] != null)
                Context = int.Parse(rawData["context"].ToString());
            if (rawData["bonusLists"] != null && rawData["bonusLists"].HasValues)
            {
                BonusList = new List<AuctionBonusID>();
                foreach (JObject BonusObject in rawData["bonusLists"])
                    BonusList.Add(new AuctionBonusID(BonusObject));
            }
            if (rawData["modifiers"] != null && rawData["modifiers"].HasValues)
            {
                ModifierList = new List<AuctionModifier>();
                foreach (JObject ModifierObject in rawData["modifiers"])
                    ModifierList.Add(new AuctionModifier(ModifierObject));
            }
            if (rawData["petSpeciesId"] != null)
                PetSpeciesID = int.Parse(rawData["petSpeciesId"].ToString());
            if (rawData["petBreedId"] != null)
                PetBreedID = int.Parse(rawData["petBreedId"].ToString());
            if (rawData["petLevel"] != null)
                PetLevel = int.Parse(rawData["petLevel"].ToString());
            if (rawData["petQualityId"] != null)
                PetQualityID = int.Parse(rawData["petQualityId"].ToString());
        }
    }
}
