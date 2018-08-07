using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Connections
{
    public class OAuth
    {
        public event EventHandler<AuthCodeEventArgs> AuthCode;

        protected virtual void AuthCodeReceived(AuthCodeEventArgs e)
        {
            AuthCode?.Invoke(this, e);
        }

        private readonly Client parent;

        private readonly string api_url;
        private readonly string locale;
        private readonly string api_key;
        private readonly string api_secret;

        private readonly string user_agent;

        private readonly string auth_code;

        private readonly string access_token;

        public OAuth(Client parent, string api_url, string locale, string api_key, string api_secret, string user_agent)
        {
            this.api_url = api_url;
            this.parent = parent;
            this.locale = locale;
            this.api_key = api_key;
            this.api_secret = api_secret;
            this.user_agent = user_agent;
        }

        public string RetrieveOAuthCode()
        {
            return $"{api_url}oauth/authorize?client_id={api_key}&scope=wow.profile+sc2.profile&redirect_uri=https://localhost:15753/oauth2callback/&response_type=code&approval_prompt=auto";
        }

        public void RetrieveAccessToken(string token)
        {
            Request request = new Request(user_agent);
            WebHeaderCollection collection = new WebHeaderCollection
            {
                { "Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{api_key}:{api_secret}"))}" }
            };
            request.Post($"{api_url}oauth/token?redirect_uri=https://localhost:15753/oauth2callback/&scope=wow.profile+sc2.profile&grant_type=authorization_code&code={token}", null, collection);
            System.IO.File.WriteAllText("token.txt", $"{request.URL}{Environment.NewLine}{request.Response}");
        }


    }

    public class AuthCodeEventArgs : EventArgs
    {
        public string Authorization_Code { get; internal set; }
    }
}
