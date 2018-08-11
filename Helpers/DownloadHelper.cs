using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardCSharp.Helpers
{
    public class DownloadHelper
    {
        public static void DownloadJSON(string json, string filePath)
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            File.WriteAllText(filePath, json);
        }

        
    }
}
