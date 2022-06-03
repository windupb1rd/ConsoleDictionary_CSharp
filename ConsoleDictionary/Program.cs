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
            DiBuilder();

            var wordPrinter = new WordPrinter();

            do
            {
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();
                if (word == "EXIT")
                {
                    break;
                }

                IWordCardProvider wordCardProvider = DI.DIContainer.instance.Release<IWordCardProvider>();
                var wordCard = wordCardProvider.GetWordCard(word);

                wordPrinter.Print(wordCard);

            } while (true);
        }

        private static void DiBuilder()
        {
            DI.DIContainer.instance.Register(typeof(IWordCardProvider), new WordCardFreeApi());
            DI.DIContainer.instance.Register(typeof(IWebClient), new MyHttpClient());
        }
    }
}