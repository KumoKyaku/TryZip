using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Keys
{
    public class Lexicon
    {
        const string keys =
            "||||Test" +
            "||||Test1" +
            "||||Test2" +
            "||||11" +
            "||||云却不是雀";

        static string[] list;
        public static string[] KeyList
        {
            get
            {
                if (list == null)
                {
                    list = keys.Split(new string[] { "||||" }, StringSplitOptions.RemoveEmptyEntries);
                }
                return list;
            }
        }
    }
}
