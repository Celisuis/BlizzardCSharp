using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace BlizzardCSharp
{
    public class Request
    {

        public int Status { get; internal set; }

        public string Response { get; internal set; }

        public WebHeaderCollection HeaderCollection { get; internal set; }

        public Stream ResponseStream { get; internal set; }

        public string URL { get; internal set; }

        private readonly string User_Agent;

        public Request(string useragent)
        {
            User_Agent = useragent;
        }

        private void WriteLog(string method, string file, string url, string response, WebHeaderCollection collection)
        {
            using (var writer = new StreamWriter(file, true))
            {
                writer.WriteLine($"URL: {method.ToUpper()} [{this.Status}] {url}");
                writer.WriteLine("Body: ");
                writer.WriteLine($"{this.Response}");
                writer.Flush();
                writer.Close();
            }
        }

        public async Task<int> GetStatusAsync(string url)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;

                var webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();

                return (int)webResponse.StatusCode;
            }
            catch (WebException e)
            {
                return (int)e.Status;
            }
            catch (Exception e)
            {
                return 503;
            }
        }

        public void Get(string url, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "GET";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";
                webRequest.AllowAutoRedirect = false;

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                    }
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                WebHeaderCollection HeaderCollection = webResponse.Headers;
                this.ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();

                    this.Status = (int)webResponse.StatusCode;
                    this.Response = response;
                    this.HeaderCollection = HeaderCollection;
                }
            }
            catch (WebException e)
            {
                this.Status = (int)e.Status;
                this.Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }

            //  WriteLog("get", "request_logs.txt", url, Response, HeaderCollection);
        }

        public void Post(string url, IDictionary<string, string> data, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                    }
                }

                string post = JsonConvert.SerializeObject(data);

                Console.WriteLine(post);

                using (var writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writer.Write(post);
                    writer.Flush();
                    writer.Close();
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                WebHeaderCollection header = webResponse.Headers;
                this.ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();

                    this.Status = (int)webResponse.StatusCode;
                    this.Response = response;
                    this.HeaderCollection = header;
                    this.URL = webResponse.ResponseUri.ToString();
                }
            }
            catch (WebException e)
            {
                this.Status = (int)e.Status;
                this.Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }

            //    WriteLog("post", "request_logs.txt", url, Response, HeaderCollection);
        }

        public void Patch(string url, IDictionary<string, string> data, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "PATCH";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                    }
                }

                string post = JsonConvert.SerializeObject(data);

                Console.WriteLine(post);

                using (var writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writer.Write(post);
                    writer.Flush();
                    writer.Close();
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                WebHeaderCollection header = webResponse.Headers;
                this.ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();

                    this.Status = (int)webResponse.StatusCode;
                    this.Response = response;
                    this.HeaderCollection = header;
                    this.URL = webResponse.ResponseUri.ToString();
                }
            }
            catch (WebException e)
            {
                this.Status = (int)e.Status;
                this.Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }

            //    WriteLog("patch", "request_logs.txt", url, Response, HeaderCollection);
        }

        public void Delete(string url, IDictionary<string, string> data, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "DELETE";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                    }
                }

                string post = JsonConvert.SerializeObject(data);

                Console.WriteLine(post);

                using (var writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writer.Write(post);
                    writer.Flush();
                    writer.Close();
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                WebHeaderCollection header = webResponse.Headers;
                this.ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();

                    this.Status = (int)webResponse.StatusCode;
                    this.Response = response;
                    this.HeaderCollection = header;
                    this.URL = webResponse.ResponseUri.ToString();
                }
            }
            catch (WebException e)
            {
                this.Status = (int)e.Status;
                this.Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }

            //  WriteLog("delete", "request_logs.txt", url, Response, HeaderCollection);
        }

        public void Put(string url, IDictionary<string, string> data, WebHeaderCollection collection = null)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "PUT";
                webRequest.UserAgent = User_Agent;
                webRequest.ContentType = "application/json";

                if (collection != null)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        webRequest.Headers.Add(collection.Keys[i], collection.Get(i));
                    }
                }

                string post = JsonConvert.SerializeObject(data);

                Console.WriteLine(post);

                using (var writer = new StreamWriter(webRequest.GetRequestStream()))
                {
                    writer.Write(post);
                    writer.Flush();
                    writer.Close();
                }

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                WebHeaderCollection header = webResponse.Headers;
                this.ResponseStream = webResponse.GetResponseStream();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();

                    this.Status = (int)webResponse.StatusCode;
                    this.Response = response;
                    this.HeaderCollection = header;
                    this.URL = webResponse.ResponseUri.ToString();
                }
            }
            catch (WebException e)
            {
                this.Status = (int)e.Status;
                this.Response = $"{new StreamReader(e.Response.GetResponseStream()).ReadToEnd()}";
            }

            //   WriteLog("put", "request_logs.txt", url, Response, HeaderCollection);
        }
    }
}
