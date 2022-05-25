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
            dynamic searchResult = FreeDictionaryAPI.GetWordObject(Console.ReadLine());

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(searchResult[0].phonetic);
            Console.ReadLine();
        }
    }
}