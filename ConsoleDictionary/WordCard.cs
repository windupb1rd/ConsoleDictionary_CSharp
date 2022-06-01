using System.Collections.Generic;

namespace ConsoleDictionary
{
    public class WordCard
    {
        public string Word { get; set; }
        public string Pronunciation { get; set; }

        public Dictionary<string, List<string>> Definitions = new Dictionary<string, List<string>>();
        public string[] Translations { get; set; }  // доделать
        public string[] ReversoExamples { get; set; }  // доделать

        /// <summary>
        /// Метод формирует единую объект слова на основе данных из разных API
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static WordCard FormWordCard(string searchQuery)
        {
            var freeDictApiWordObj = FreeDictionaryAPI.GetWordObject(searchQuery);

            WordCard wordCard = new WordCard();

            wordCard.Word = freeDictApiWordObj[0].Word;

            if (freeDictApiWordObj[0].Phonetic != null)
                {
                wordCard.Pronunciation = freeDictApiWordObj[0].Phonetic;
            }
            else
            {
                wordCard.Pronunciation = "No phonetic";  // заглушка
            }

            for (int i = 0; i < freeDictApiWordObj[0].Meanings.Count; i++)
            {
                string partOfSpeech = freeDictApiWordObj[0].Meanings[i].PartOfSpeech;
                wordCard.Definitions.Add(partOfSpeech, new List<string>());
                for (int j = 0; j < freeDictApiWordObj[0].Meanings[i].Definitions.Count; j++)
                    wordCard.Definitions[partOfSpeech].Add($"{freeDictApiWordObj[0].Meanings[i].Definitions[j].Definition}\n     /{freeDictApiWordObj[0].Meanings[i].Definitions[j].Example?? "No example"}/ ");
            }

            return wordCard;
        }
    }

}
