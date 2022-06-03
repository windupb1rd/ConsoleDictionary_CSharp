using ConsoleDictionary.FreeDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleDictionary
{
    internal class Program
    {
        internal static void Main()
        {
            DI.DIContainer di = DiBuilder();

            var wordPrinter = new WordPrinter();

            do
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();
                if (word == "EXIT")
                {
                    break;
                }

                IWordCardProvider wordCardProvider = di.Release<IWordCardProvider>();
                var wordCard = wordCardProvider.GetWordCard(word);

                wordPrinter.Print(wordCard);

            } while (true);
        }

        private static DI.DIContainer DiBuilder()
        {
            var di = new DI.DIContainer();
            di.Register(typeof(IWordCardProvider), new WordCardFreeApi());
            return di;
        }
    }
}