using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleDictionary
{
    public class StringDownloader
    {
        internal string GetString(string url)
        {
            var webClient = DI.DIContainer.instance.Release<IWebClient>();
            return webClient.DownloadString(url);
        }
    }
}