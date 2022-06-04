using ConsoleDictionary.FeeDict.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary.FreeDict
{
    public class FreeDictionaryApi
    {
        public List<WordObject> GetWordObject(string query)
        {
            string url = "https://api.dictionaryapi.dev/api/v2/entries/en/" + query;

            var sd = new StringDownloader();
            string stringValue = sd.GetString(url);

            var wordObject = JsonConvert.DeserializeObject<List<WordObject>>(stringValue);
            return wordObject;
        }
    }
}
