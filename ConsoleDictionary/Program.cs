using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleDictionary
{
    internal class Program
    {
        internal static void SearchAndPrint(string searchQuery)
        {
            WordCard wordCard = WordCard.FormWordCard(searchQuery);

            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{wordCard.Word}   {wordCard.Pronunciation}\n--------------------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var partOfSpeech in wordCard.Definitions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write($"{partOfSpeech.Key.ToUpper()}\t");

                int maxSynonyms = 5;
                for (int i = 0; i < wordCard.Synonyms[partOfSpeech.Key].Count; i++)
                {
                    Console.Write($"| {wordCard.Synonyms[partOfSpeech.Key][i]} |");
                    if (i == maxSynonyms - 1)
                    {
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("--------------------");
                Console.ForegroundColor = ConsoleColor.White;
                int maxDefinitions = 5;
                for (int i = 0; i < partOfSpeech.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {partOfSpeech.Value[i]}");
                    if (i == maxDefinitions - 1)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------");
        }
        internal static void Main()
        {
            bool runProgram = true;
            do
            {
                Console.Write("Enter a word: ");
                string searchQuery = Console.ReadLine();
                if (searchQuery == "EXIT")
                {
                    runProgram = false;
                }

                SearchAndPrint(searchQuery);
                
            } while (runProgram);
            
        }
    }
}