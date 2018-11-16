using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class String
    {
        string str;
        int currentLength;
        int countWords;

        //Конструкторы
        public String(string _str = " ")
        {
            publishDate = new Date();
            owner = new Owner();
            this.str = _str;
            this.currentLength = str.Length;
            this.countWords = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
        }


        //Аксессоры
        public string Str
        {
            get => str;
            set => str = value;
        }

        public int CurrentLength
        {
            get => currentLength;
            set
            {
                if (value == str.Length)
                {
                    currentLength = value;
                }
            }
        }

        public int CountWords
        {
            get => countWords;
            set
            {
                if (value == str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length)
                {
                    countWords = value;
                }
            }
        }
        public Date publishDate { get; }

        public Owner owner { get; set; }

        //Методы
        public string[] SplitString()
        {
            string[] words = this.str.Split(new char[] { ' ' });

            return words;
        }

        public string DisplayWord(string[] words, int numberInOrder)
        {
            if (countWords == 0)
            {
                return " ";
            }
            if (numberInOrder > countWords)
            {
                numberInOrder = countWords-1;
            }
            return words[numberInOrder];

        }

        



        //Перегрузка операторов
        public static bool operator < (String item1,String item2)
        {
            bool flag = true;
            if (item1.currentLength >= item2.currentLength)
            {
                flag = false;
            }
            return flag;
        }

        public static bool operator > (String item1, String item2)
        {
            bool flag = true;
            if(item1.currentLength <= item2.currentLength)
            {
                flag = false;
            }
            return flag;
        }

        public static String operator + (String obj, int number)
        {
            string  a = string.Concat(obj.Str,number.ToString());
            return new String(a);
        }

        public static String operator -(String obj)
        {
            string a = obj.Str.Substring(0, obj.currentLength - 1);
            return new String(a);
        }

        public static String operator *(String obj,char replace)
        {
            string a="";
            for(int i = 0; i < obj.currentLength; i++)
            {
                a = string.Concat(a,replace);
            }
            return new String(a);
        }


        //Вложенные объекты
        public class Owner
        {
            static int count;
            readonly int id;
            string name;
            string organization;

            public int Id
            {
                get => id;
            }

            public string Name
            {
                get => name;
                set => name = value;
            }

            public string Organization
            {
                get => organization;
                set => organization = value;
            }

            static Owner()
            {
                count = 0;
            }

            public Owner()
            {
                this.id = count;
                this.name = "Uncknown";
                this.organization = "Uncknown";
            }

            public Owner(string name, string organization) : this()
            {
                this.name = name;
                this.organization = organization;
            }
        }
        public class Date
        {
            private DateTime date;

            public DateTime PublishDate
            {
                get => date;
            }

            public Date()
            {
                date = DateTime.Now;
            }
        }
    }
}
