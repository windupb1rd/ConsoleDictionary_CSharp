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
            //var wordPrinter = new WordToConsolePrinter();

            do
            {
                Console.Write("Enter a word: ");
                string searchQuery = Console.ReadLine();
                if (searchQuery == "EXIT")
                {
                    break;
                }

                WordCard wordCard = new WordCard();
                wordCard.FormWordCard(searchQuery);

                //var dict = wordCard.Definitions;
                //wordPrinter.Print(wordCard);

            } while (true);
        }
    }
}