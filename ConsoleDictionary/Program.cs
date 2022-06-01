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

            foreach (var item in wordCard.Definitions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(item.Key.ToUpper());
                Console.WriteLine("--------------------");
                Console.ForegroundColor = ConsoleColor.White;
                int maxDefinitions = 5;
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {item.Value[i]}");
                    if (i == maxDefinitions - 1)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------");
        }
        static void Main(string[] args)
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