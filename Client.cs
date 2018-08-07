 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlizzardCSharp.Connections;


namespace BlizzardCSharp
{
    public class Client
    {
        #region Variables
        public event EventHandler<ConnectedEventArgs> Connected;

        public bool IsConnected;

        private Dictionary<string, List<string>> ConnectionTest = new Dictionary<string, List<string>>();

        private readonly string OAuth_URL = $"https://{0}.battle.net";
        private readonly string API_URL = "https://{0}.api.battle.net";

        const string User_Agent = "";

        private string API_Key;
        private readonly string API_Secret;

        private Region API_Region;
        private Locale API_Locale;

        public WorldOfWarcraft WorldOfWarcraft { get; internal set; }
        public Diablo Diablo { get; internal set; }

        #endregion

        #region Methods
        protected virtual void OnConnected(ConnectedEventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        public Client(string key, string secret, Region region, Locale locale)
        {
            API_Key = key;
            API_Secret = secret;
            API_Region = region;
            API_Locale = locale;

            OAuth_URL = $@"https://{region.ToString().ToLower()}.battle.net/";
            API_URL = $@"https://{region.ToString().ToLower()}.api.battle.net/";

            WorldOfWarcraft = new WorldOfWarcraft(this, API_URL, API_Locale.ToString(), API_Key, User_Agent);
            Diablo = new Diablo(this, API_URL, API_Locale.ToString(), API_Key, User_Agent);
            List<string> connectionstesturls = new List<string>
            {
                $"{API_URL}wow/achievement/2144?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/boss/24723?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/item/18803?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/item/set/1060?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/ability/640?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/species/258?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/stats/258?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/quest/13146?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/recipe/33994?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/spell/8056?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/zone/4131?locale={API_Locale}&apikey={API_Key}"
            };

            ConnectionTest.Add("WoW-API", connectionstesturls);

            connectionstesturls = new List<string>();

        }

        public Region RetrieveRegion()
        {
            return API_Region;
        }

        public Locale RetrieveLocale()
        {
            return API_Locale;
        }

        public void VerifyConnection()
        {
            Task task = new Task(VerifyConnectionAsync);
            task.Start();
            task.Wait();
        }
        public async void VerifyConnectionAsync()
        {
            List<string> connectionstesturls = new List<string>
            {
                $"{API_URL}wow/achievement/2144?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/boss/24723?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/item/18803?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/item/set/1060?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/ability/640?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/species/258?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/pet/stats/258?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/quest/13146?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/recipe/33994?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/spell/8056?locale={API_Locale}&apikey={API_Key}",
                $"{API_URL}wow/zone/4131?locale={API_Locale}&apikey={API_Key}"
            };

            Random rnd = new Random();

            string URL = connectionstesturls[rnd.Next(connectionstesturls.Count())];

            Request request = new Request(User_Agent);

            Task<int> status = request.GetStatusAsync(URL);

            int x = await status;

            if (x.ToString().StartsWith("2"))
            {
                ConnectedEventArgs e = new ConnectedEventArgs
                {
                    Key = API_Key,
                    Locale = API_Locale,
                    Region = API_Region,
                    Status = x,
                    URL = URL
                };
                IsConnected = true;

                OnConnected(e);
            }
        }
        #endregion


    }

    public class ConnectedEventArgs : EventArgs
    {
        public string Key { get; internal set; }

        public Region Region { get; internal set; }

        public Locale Locale { get; internal set; }

        public int Status { get; internal set; }

        public string URL { get; internal set; }

    }

    public enum Region
    {
        None,
        EU,
        US,
        TW,
        KR
    }

    public enum Locale
    {
        None,
        en_GB,
        de_DE,
        es_ES,
        fr_FR,
        it_IT,
        pl_PL,
        pt_PT,
        ru_RU,
        ko_KR,
        zh_TW,
        en_US,
        pt_BR,
        es_MX
    }

    public enum API_Source
    {
        Blizzard,
        TradeSkillMaster
    }
}
