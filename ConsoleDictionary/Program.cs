using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FreeDictionaryAPI.WordObject> searchResult = FreeDictionaryAPI.GetWordObject(args[0]);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{searchResult[0].Word}   {searchResult[0].Phonetics[0].Text}\n");

            //Console.WriteLine($"1. {searchResult[0].Meanings[0].Definitions[0].Definition}"+
            //                  $"2. {searchResult[0].Meanings[0].Definitions[1].Definition}\n");

            Console.ReadLine();
        }
    }
}