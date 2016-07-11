using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace The_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            var filelist = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.zip");
            TryZip.Loopkey(filelist);
        }
    }
}
