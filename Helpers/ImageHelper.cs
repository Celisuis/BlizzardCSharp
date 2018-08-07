using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Helpers
{
    public class ImageHelper
    {
        public static Image RetrieveImage(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create($"{url}");
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();

            return Image.FromStream(stream);
        }
    }
}
