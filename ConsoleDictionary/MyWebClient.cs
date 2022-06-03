using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary
{
    class MyWebClient : IWebClient
    {
        public string DownloadString(string url)
        {
            WebClient client = new()
            {
                Encoding = Encoding.UTF8
            };

            try
            {
                string response = client.DownloadString(url);
                return response;
            }
            catch (WebException)
            {
                Console.WriteLine("I couldn't find the word. Check you query for typos or try looking for another word.");
                Program.Main();

                return null;
            }
        }
    }
}
