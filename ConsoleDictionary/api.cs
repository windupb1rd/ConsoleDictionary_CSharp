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

        public static object GetWordsInJson(string query)
        {
            WebClient client = new();
            client.Encoding = Encoding.UTF8;
            string replyFromApi = client.DownloadString("https://api.dictionaryapi.dev/api/v2/entries/en/" + query);

            var final = JsonConvert.DeserializeObject<List<Definition>>(replyFromApi);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(final[0].phonetic);
            return final;
        }

    }
}