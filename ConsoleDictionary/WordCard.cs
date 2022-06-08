using ConsoleDictionary.FreeDict;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDictionary
{
    internal class WordCard
    {
        private readonly FreeDictionaryApi freeDictionaryApi = new FreeDictionaryApi();

        internal string Word { get; private set; }

        internal string Pronunciation { get; private set; }

        private readonly Dictionary<string, List<string>> _definition = new Dictionary<string, List<string>>();

        internal Dictionary<string, List<string>> Definitions
        {
            get
            {
                return _definition;
            }
        }

        internal Dictionary<string, List<string>> Synonyms { get; }

        //internal string[] Translations { get; set; }  // доделать
        //internal string[] ReversoExamples { get; set; }  // доделать

        internal WordCard()
        {
            Synonyms  = new Dictionary<string, List<string>>();
        }

        public delegate void PrintDelegate(WordCard wordCardObj);

        public event PrintDelegate OnGetWord;
        

        /// <summary>
        /// Метод формирует единую объект слова на основе данных из разных API
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public WordCard FormWordCard(string searchQuery)
        {
            var freeDictApiWordObj = (new FreeDictionaryApi()).GetWordObject(searchQuery);

            Word = freeDictApiWordObj[0].Word;

            if (freeDictApiWordObj[0].Phonetic != null)
            {
                Pronunciation = freeDictApiWordObj[0].Phonetic;
            }
            else
            {
                Pronunciation = "No phonetic";  // заглушка
            }

            for (int i = 0; i < freeDictApiWordObj[0].Meanings.Count; i++)
            {
                string partOfSpeech = freeDictApiWordObj[0].Meanings[i].PartOfSpeech;

                // Add synonym per part of speech
                if (!_definition.ContainsKey(partOfSpeech))
                {
                    Synonyms.Add(partOfSpeech, freeDictApiWordObj[0].Meanings[i].Synonyms);
                }
                else
                {
                    Synonyms[partOfSpeech].AddRange(freeDictApiWordObj[0].Meanings[i].Synonyms);
                }

                // Add defenitions per part of speech
                if (!_definition.ContainsKey(partOfSpeech))
                {
                    _definition.Add(partOfSpeech, new List<string>());
                }
                for (int j = 0; j < freeDictApiWordObj[0].Meanings[i].Definitions.Count; j++)
                {
                    _definition[partOfSpeech]
                            .Add($@"{freeDictApiWordObj[0]
                                .Meanings[i].Definitions[j].Definition}\n\t/{freeDictApiWordObj[0]
                                .Meanings[i].Definitions[j].Example ?? "No example"}/ ");
                }
            }

            OnGetWord(this);  // запуск события
            return this;
        }
    }

}
