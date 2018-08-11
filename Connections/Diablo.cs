using BlizzardCSharp.Games.Diablo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Connections
{
    public class Diablo
    {
        private readonly Client Client;

        private readonly string Api_Url;
        private readonly string Api_Key;
        private readonly string Locale;
        private readonly string User_Agent;

        public Diablo(Client client, string api_url, string locale, string api_key, string user_agent)
        {
            Client = client;
            Api_Url = api_url;
            Locale = locale;
            Api_Key = api_key;
            User_Agent = user_agent;
        }

        #region API_Functions
        #region Acts
        public List<Act> GetActMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/act?locale={Locale}&apikey={Api_Key}");
            JObject rawData = JObject.Parse(request.Response);

            List<Act> ActList = new List<Act>();
            foreach (JObject actObject in rawData["acts"])
            {
                Act act = new Act(actObject);
                ActList.Add(act);
            }

            return ActList;
        }

        public Act GetAct(int actID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/act/{actID}?locale={Locale}&apikey={Api_Key}");
            return new Act(JObject.Parse(request.Response));

        }
        #endregion

        #region Artisans
        public Artisan GetArtisan(ArtisanType artisan)
        {
            string artisanSlug = artisan.ToString().ToLower();
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/artisan/{artisanSlug}?locale={Locale}&apikey={Api_Key}");
            return new Artisan(JObject.Parse(request.Response));
        }

        #endregion

        #region Recipes

        public Recipe GetRecipe(string recipeSlug, ArtisanType artisan)
        {
            string artisanSlug = artisan.ToString().ToLower();
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}?locale={Locale}&apikey={Api_Key}");
            return new Recipe(JObject.Parse(request.Response));
        }

        #endregion

        #region Followers
        public Follower GetFollower(FollowerType follower)
        {
            string followerSlug = follower.ToString().ToLower();

            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/follower/{followerSlug}?locale={Locale}&apikey={Api_Key}");
            return new Follower(JObject.Parse(request.Response));
        }

        #endregion

        #region Classes
        public Class GetClass(string classSlug)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/hero/{classSlug}?locale={Locale}&apikey={Api_Key}");
            return new Class(JObject.Parse(request.Response));
        }

        #endregion

        #region Skills

        public Talent GetSkill(string classSlug, string skillSlug)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/hero/{classSlug}/skill/{skillSlug}?locale={Locale}&apikey={Api_Key}");
            return new Talent(JObject.Parse(request.Response));
        }

        #endregion

        #region Items

        public List<ItemType> GetItemTypeMasterList()
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/item-type?locale={Locale}&apikey={Api_Key}");
            JArray rawData = JArray.Parse(request.Response);

            List<ItemType> ItemTypes = new List<ItemType>();

            foreach(JObject it in rawData)
            {
                ItemType item = new ItemType(it);
                ItemTypes.Add(item);
            }

            return ItemTypes;
        }

        public List<Item> GetItemsByType(string typeSlug)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/item-type/{typeSlug}?locale={Locale}&apikey={Api_Key}");
            JArray itemArray = JArray.Parse(request.Response);

            List<Item> ItemList = new List<Item>();

            foreach(JObject itemObject in itemArray)
            {
                Item item = new Item(itemObject);
                ItemList.Add(item);
            }

            return ItemList;
        }

        public Item GetItem(string itemSlug)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/data/item/{itemSlug}?locale={Locale}&apikey={Api_Key}");

            return new Item(JObject.Parse(request.Response));
        }

        #endregion

        #region Account
        public Profile GetProfile(string battleTag)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/profile/{battleTag}/?locale={Locale}&apikey={Api_Key}");
            return new Profile(JObject.Parse(request.Response));
        }

        public Hero GetHero(string battleTag, long heroID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/profile/{battleTag}/hero/{heroID}?locale={Locale}&apikey={Api_Key}");

            return new Hero(JObject.Parse(request.Response));
        }

        public List<Item> GetHeroItems(string battleTag, long heroID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/profile/{battleTag}/hero/{heroID}/items?locale={Locale}&apikey={Api_Key}");
            JArray rawArray = JArray.Parse(request.Response);
            
            List<Item> Items = new List<Item>();
            
            foreach(JObject item in rawArray)
            {
                Item newItem = new Item(item);
                Items.Add(newItem);
            }

            return Items;

        }

        public List<Item> GetFollowerItems(string battleTag, long heroID)
        {
            Request request = new Request(User_Agent);
            request.Get($"{Api_Url}d3/profile/{battleTag}/hero/{heroID}/follower-items?locale={Locale}&apikey={Api_Key}");
            JArray rawArray = JArray.Parse(request.Response);

            List<Item> FollowerItems = new List<Item>();
            foreach(JObject item in rawArray)
            {
                Item newItem = new Item(item);
                FollowerItems.Add(newItem);
            }

            return FollowerItems;
        }
        #endregion
        #endregion
    }

    public enum ArtisanType
    {
        Blacksmith,
        Mystic,
        Jeweler

    }

    public enum FollowerType
    {
        Templar,
        Enchantress,
        Scoundrel
    }
}
