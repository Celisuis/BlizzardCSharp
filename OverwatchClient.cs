using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlizzardCSharp.Connections;
using BlizzardCSharp.Helpers;

namespace BlizzardCSharp
{
   public class OverwatchClient
    {
        #region Variables

        public bool IsConnected;

        private readonly Dictionary<string, List<string>> ConnectionTest = new Dictionary<string, List<string>>();

        private readonly string API_URL = String.Empty;

        private readonly OverwatchRegion Region = OverwatchRegion.None;
        private readonly Platform Platform = Platform.None;

        private readonly APIType APIType = APIType.None;

        const string User_Agent = "";

        public static string RawJSON;

        public static Dictionary<string, string> RawJSONDictionary;

        public Overwatch API { get; internal set; }

        #region Methods


        public OverwatchClient(APIType apiType = APIType.Stats, Platform platform = Platform.PC, OverwatchRegion region = OverwatchRegion.EU)
        {
            Region = region;
            Platform = platform;
            APIType = apiType;

            string platformID;

            switch(Platform)
            {
                case Platform.PC:
                    platformID = $@"pc";
                    break;
                case Platform.XBOX:
                    platformID = $@"xbl";
                    break;
                case Platform.PS4:
                    platformID = $@"psn";
                    break;
                default:
                    platformID = $@"pc";
                    break;
            }

            string regionID;

            switch(Region)
            {
                case OverwatchRegion.EU:
                    regionID = $@"eu";
                    break;
                case OverwatchRegion.KR:
                    regionID = $@"kr";
                    break;
                case OverwatchRegion.US:
                    regionID = $@"us";
                    break;
                default:
                    regionID = $@"eu";
                    break;
            }

            if (APIType == APIType.Stats)
            {
                if (Platform == Platform.PC)
                {
                    API_URL = $@"https://ovrstat.com/stats/pc/{regionID}/";
                }
                else
                {
                    API_URL = $@"https://ovrstat.com/stats/{platformID}/";
                }
            }
            else if(APIType == APIType.Information)
            {
                API_URL = $@"https://overwatch-api.tekrop.fr/";
            }

            API = new Overwatch(this, API_URL, regionID, platformID, User_Agent);
        }

        public void DownloadJSON(string filePath)
        {
            DownloadHelper.DownloadJSON(RawJSON, filePath);
        }

        public void SaveJSON(string fileName)
        {
            RawJSONDictionary.Add($"{fileName}.json", RawJSON);
        }

        public void DownloadAllJSON(string filePath)
        {
            foreach (KeyValuePair<string, string> kvp in RawJSONDictionary)
            {
                DownloadHelper.DownloadJSON(kvp.Value, filePath + kvp.Key);
            }
        }

        public OverwatchRegion RetrieveRegion()
        {
            return Region;
        }

        public Platform RetrievePlatform()
        {
            return Platform;
        }

        #endregion


        #endregion
    }
    
    public enum OverwatchRegion
    {
        None,
        EU,
        US,
        KR
    }

    public enum Platform
    {
        None,
        PC,
        XBOX,
        PS4
    }

    public enum APIType
    {
        None,
        Stats,
        Information
    }
}
