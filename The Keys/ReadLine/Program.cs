using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\迅雷下载\PW1.3.8密码大合集\Galgame常用密码(2013-10-10上午00-14更新).txt";
            string res = "";
            using (StreamReader read = new StreamReader(path, System.Text.Encoding.GetEncoding("gb2312")))
            {
                bool next = true;
                while (next)
                {
                    string temp = read.ReadLine();
                    if (temp == null)
                    {
                        next = false;
                    }
                    res += "||||" + temp;
                }
            }
            Console.Write(res);
        }
    }
}
