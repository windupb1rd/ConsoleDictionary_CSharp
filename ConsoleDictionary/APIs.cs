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

            try
            {
                string response = client.DownloadString(query);
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
    public class FreeDictionaryAPI
    {
        public class WordObject
        {   
            public string Word { get; set; }
            public string Phonetic { get; set; }
            public List<Phonetics> Phonetics { get; set; }
            public List<Meanings> Meanings { get; set; }

        }
        public class Phonetics
        {
            public string Text { get; set; }
            public string Audio { get; set; }
        }
        public class Meanings
        {
            public string PartOfSpeech { get; set; }
            public List<string> Synonyms { get; set; }
            public List<Definitions> Definitions { get; set; }
        }
        public class Definitions
        {
            public string Definition { get; set; }
            public string Example { get; set; }
        }
        public static List<FreeDictionaryAPI.WordObject> GetWordObject(string query)
        {
            string URL = "https://api.dictionaryapi.dev/api/v2/entries/en/" + query;
            string replyFromApi = GetWord.GetJson(URL);
            var wordObject = JsonConvert.DeserializeObject<List<WordObject>>(replyFromApi);

            return wordObject;
        }

    }
}