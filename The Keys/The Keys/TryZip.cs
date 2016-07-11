using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Encryption;
using System.Security.Cryptography;

namespace The_Keys
{
    public static class TryZip
    {
        internal static void Loopkey(string[] filelist)
        {
            int i = 0;
            while (filelist.Length > i)
            {
                try
                {
                    string path = filelist[i];
                    NewMethod();

                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        ZipInputStream zs = new ZipInputStream(fs);
                        var entry = zs.GetNextEntry();
                        while (!entry.IsFile)
                        {
                            entry = zs.GetNextEntry();
                            if (entry == null)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private static IList<ICryptoTransform> NewMethod(string[] keys)
        {
            List<ICryptoTransform> passwords = new List<ICryptoTransform>();
            foreach (var item in keys)
            {
                var managed = new PkzipClassicManaged();
                byte[] key = PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(item));

                ICryptoTransform key2 = managed.CreateDecryptor(key, null);
                passwords.Add(key2);
            }
            return passwords;
        }
    }
}
