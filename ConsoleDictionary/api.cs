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
    public class GetWord
    {
        public static string GetJson(string query)
        {
            WebClient client = new()
            {
                Encoding = Encoding.UTF8
            };
            
            return client.DownloadString(query);
        }
    }
    public class FreeDictionaryAPI
    {
        public class Definition
        {   
            public string word { get; set; }
            public string phonetic { get; set; }
            public List<Phonetics> phonetics { get; set; }
        }
        public class Phonetics
        {
            public string text { get; set; }
            public string audio { get; set; }
        }
        public static List<Definition> GetWordObject(string query)
        {
            string URL = "https://api.dictionaryapi.dev/api/v2/entries/en/" + query;
            string replyFromApi = GetWord.GetJson(URL);
            var wordObject = JsonConvert.DeserializeObject<List<Definition>>(replyFromApi);

            return wordObject;
        }

    }
}