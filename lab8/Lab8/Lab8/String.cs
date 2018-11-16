using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class String<T> : ICollection<T> 
    {
        private const int START_LENGTH = 20;
        string str;
        int lengthStr;

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


        public T[] _string;
        private int _currentLength;
        public Owner owner { get; set; }
        public Date PublishDate { get; }
        public string Str
        {
            get => str;
            set => str = value;
        }

        public int LengthStr
        {
            get => str.Length;
        }


        public int CurrentLength
        {
            get => _currentLength;
            set => _currentLength = value;
        }

        public int MaxLength
        {
            get => _string.Length;
        }

        public String(string str)
        {
            this.str = str;
            this.lengthStr = str.Length;
            _string = new T[START_LENGTH];
            _currentLength = 0;
            PublishDate = new Date();
            owner = new Owner();
        }

        public String(string str,params T[] list) : this(str)
        {
            foreach (T item in list)
            {
                Add(item);
            }
        }

        public String(String<T> obj)
        {
            this._string = obj._string;
            this._currentLength = obj._currentLength;
            this.owner = obj.owner;
            this.PublishDate = obj.PublishDate;
        }
        public void Read()
        {
            string path = @"E:\Laba8.txt";
            string text;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                text = sr.ReadToEnd();

            }
            Console.WriteLine(text);
        }

        

        public void Write(int i)
        {
            string path = @"E:\Laba8.txt";
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                sr.Write(_string.ElementAt(i).ToString());
            }

        }
        public bool Add(T str)
        {
            if (CheckLengthForAdd())
            {
                _string[_currentLength++] = str;
                return true;
            }
            return false;
        }

        public void Del()
        {
            _string[_currentLength] = _string[_currentLength+1];
            --_currentLength;
        }

        public void Show()
        {
            if (_currentLength == 0)
            {
                Console.WriteLine("List has not element");
            }
            else
            {
                for (int i = 0; i < _currentLength; i++)
                {
                    Console.WriteLine($"{_string.ElementAt(i).ToString()}");
                }
            }
        }

        private bool CheckLengthForAdd()
        {
            return _currentLength < _string.Length;
        }

        private bool CheckLengthForRemove()
        {
            return _currentLength != 0;
        }

        //Перегрузка операторов
        public static bool operator <(String<T> item1, String<T> item2)
            {
                bool flag = true;
                if (item1.lengthStr >= item2.lengthStr)
                {
                    flag = false;
                }
                return flag;
            }

            public static bool operator >(String<T> item1, String<T> item2)
            {
                bool flag = true;
                if (item1.lengthStr <= item2.lengthStr)
                {
                    flag = false;
                }
                return flag;
            }

            public static String<T> operator +(String<T> obj, int number)
            {
                string a = string.Concat(obj.Str, number.ToString());
                return new String<T>(a);
            }

            public static String<T> operator -(String<T> obj)
            {
                string a = obj.Str.Substring(0, obj.lengthStr - 1);
                return new String<T>(a);
            }

            public static String<T> operator *(String<T> obj, char replace)
            {
                string a = "";
                for (int i = 0; i < obj.lengthStr; i++)
                {
                    a = string.Concat(a, replace);
                }
                return new String<T>(a);
            }
    }
}
