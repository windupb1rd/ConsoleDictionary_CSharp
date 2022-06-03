using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary
{
    class MyHttpClient : IWebClient
    {
        public string DownloadString(string url)
        {
            var httpclient = new HttpClient();
            var task = httpclient.GetStringAsync(url);
            task.Wait();

            return task.Result;
        }
    }
}
