using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDictionary
{
    interface IWebClient
    {
        string DownloadString(string url);
    }
}
