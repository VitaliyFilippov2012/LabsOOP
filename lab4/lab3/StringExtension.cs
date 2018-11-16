using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    static class StringExtension
    {
        //Методы расширения
        public static bool AvailabilityServiceCharacters(this String obj)
        {
            bool flag = false;
            string[] punctuation_marks = { ".", ",", "!=", "==", ";", ":", "..", "@", "'", "/", "#"};
            string str = obj.Str;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < punctuation_marks.Length; j++)
                {
                    if (str[i].ToString() == punctuation_marks[j])
                    {
                        flag = true;
                        break;
                    }
                }
                   if (flag)
                {
                    break;
                }
            }
            return flag;

        }

        public static void RemovePunctuationMarks(this String obj)
        {
            string[] punctuation_marks = { ".", ",", "!", "?", ";", ":", "-" };
            string str = obj.Str;
            for (int j = 0; j < punctuation_marks.Length; j++)
                str = str.Replace(punctuation_marks[j], "");
            Console.WriteLine($"{str}");
        }

    }
}
