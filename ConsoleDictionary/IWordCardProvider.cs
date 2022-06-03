using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary
{
    interface IWordCardProvider
    {
        WordCard GetWordCard(string word);
    }
}
