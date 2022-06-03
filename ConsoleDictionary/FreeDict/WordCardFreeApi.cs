using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary.FreeDict
{
    class WordCardFreeApi : IWordCardProvider
    {
        public WordCard GetWordCard(string word)
        {
            WordCard wordCard = new WordCard().FormWordCard(word);

            return wordCard;
        }
    }
}
