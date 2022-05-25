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
            object searchQuery = FreeDictionaryAPI.GetWordsInJson(Console.ReadLine());
            Console.WriteLine(searchQuery);

            Console.ReadLine();
        }
    }
}