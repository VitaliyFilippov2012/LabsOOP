using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class StringFunction
    {
        public delegate string StringFun(ref string str);
        static public string OperationString(string str, Func<string, string> func) => str != null ? func(str) : func("");

        static public string AddStr(string str1, string str2) => str1 += str2;


        static public string Reverse(ref string str) => str = new string(str.ToCharArray().Reverse().ToArray());


        static public string RemoveSpace(ref string str) => str = str.Replace(" ", String.Empty);



        static public string ToUpperFirstLetters(ref string str)
        {

            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;
                if (i == 0)
                {
                    str = str.Replace(str[i], Char.ToUpper(str[i]));
                }
                if (str[i] == ' ')
                {
                    flag = true;
                }
                if (flag == true)
                {
                    str = str.Replace(str[i + 1], Char.ToUpper(str[i + 1]));
                    flag = false;
                }
            }
            return str;
        }


        static public string RemoveSymbol(ref string str)
        {
            char[] sign = ".></?=+-|_)(*&^:%;$№#@".ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (sign.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                    --i;
                }
            }
            return str;
        }

    }
}
