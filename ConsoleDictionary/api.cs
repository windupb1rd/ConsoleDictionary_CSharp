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
    public class FreeDictionaryAPI
    {
        public class JSONModelCollection
        {
            public List<JSONModel> Jsonmodel { get; set; }
        }
        public class JSONModel
        {   
            public string word;
            public string phonetic;
        }
        public static object GetWordsInJson(string query)
        {
            WebClient client = new();
            string replyFromApi = client.DownloadString("https://api.dictionaryapi.dev/api/v2/entries/en/" + query);

            //var listOfDefinitions = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(replyFromApi);
            //string entry1 = JsonConvert.SerializeObject(listOfDefinitions[1]);

            var final = JsonConvert.DeserializeObject<JSONModelCollection>(replyFromApi);

            return final;
        }

    }
}