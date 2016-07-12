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
            string txtpath = Directory.GetCurrentDirectory() + "\\老司机的车钥匙.txt";

            using (StreamWriter txtfs = File.CreateText(txtpath))
            {
                int i = 0;
                while (filelist.Length > i)
                {
                    try
                    {


                        string path = filelist[i];

                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {

                            ZipInputStream zs = new ZipInputStream(fs);
                            var pw = zs.TryPassword(GetPassword());
                            if (pw !=null)
                            {
                                string filename = path.Split('\\').Last();
                                txtfs.WriteLine(filename + "-----------" + pw.key);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
        }

        private static IList<Password> GetPassword()
        {
            return GetPassword(Lexicon.KeyList);
        }

        private static IList<Password> GetPassword(string[] keys)
        {
            List<Password> passwords = new List<Password>();
            foreach (var item in keys)
            {
                var managed = new PkzipClassicManaged();
                byte[] key = PkzipClassic.GenerateKeys(ZipConstants.ConvertToArray(item));

                ICryptoTransform key2 = managed.CreateDecryptor(key, null);
                passwords.Add(new Password() { key = item,GenerateKeys = key2 });
            }
            return passwords;
        }
    }
}


