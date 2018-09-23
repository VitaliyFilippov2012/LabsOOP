using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб1
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            //--------------------------------------Типы данных-----------------------

            // 1 задание

            sbyte sByte = -32;
            Console.WriteLine("Переменная sByte- {0} относится к типу: {1}", sByte , sByte.GetType());

            short int16 = -23202;
            Console.WriteLine("Переменная int16- {0} относится к типу: {1}", int16 , int16.GetType());

            int int32 = -223223213;
            Console.WriteLine("Переменная int32- {0} относится к типу: {1}", int32 , int32.GetType());

            long int64 = -2323433333333333333;
            Console.WriteLine("Переменная int64- {0} относится к типу: {1}", int64, int64.GetType());

            byte bytte = 99;
            Console.WriteLine("Переменная bytte- {0} относится к типу: {1}", bytte, bytte.GetType());


            ushort uInt16 = 23423;
            Console.WriteLine("Переменная uInt16- {0} относится к типу: {1}", uInt16 , uInt16.GetType());

            uint uInt32 = 3242334344;
            Console.WriteLine("Переменная uInt32- {0} относится к типу: {1}", uInt32, uInt32.GetType());

            ulong uInt64 = 3543534534534534534;
            Console.WriteLine("Переменная uInt64- {0} относится к типу: {1}",uInt64, uInt64.GetType());

            char ch = 'd';
            Console.WriteLine("Переменная ch- {0} относится к типу: {1}",ch, ch.GetType());

            bool bolean = false;
            Console.WriteLine("Переменная bolean- {0} относится к типу: {1}", bolean, bolean.GetType());

            float single = 23.324F;
            Console.WriteLine("Переменная Single- {0} относится к типу: {1}", single, single.GetType());

            double doublee = 23.32;
            Console.WriteLine("Переменная doublee- {0} относится к типу: {1}", doublee, doublee.GetType());

            decimal dec = 300.5M;
            Console.WriteLine("Переменная dec- {0} относится к типу: {1}", dec,  dec.GetType());

            dynamic dyn = "FF";
            Console.WriteLine("Переменная dyn- {0} относится к типу: {1}", dyn, dyn.GetType());
            dyn = 407;
            Console.WriteLine("Переменная dyn- {0} относится к типу: {1}", dyn, dyn.GetType());

            string str = "Hello!";
            Console.WriteLine("Переменная str- {0} относится к типу: {1}", str , str.GetType());

            object obj = "This is object";
            Console.WriteLine("Переменная obj- {0} относится к типу: {1}", obj , obj.GetType());

            // 2 задание
            // Явное приведение

            uint ofFloat = (uint)single;
            Console.WriteLine($"Переменная ofFloat- {ofFloat} после явного приведения от переменной single- {single} относится к типу: {ofFloat.GetType()}");

            int ofLong = (int)uInt64;
            Console.WriteLine($"Переменная ofLong- {ofLong} после явного приведения от переменной uInt64- {uInt64} относится к типу: {ofLong.GetType()}");

            ushort ofShort = (ushort)int16;
            Console.WriteLine($"Переменная ofShort- {ofShort} после явного приведения от переменной int16- {int16} относится к типу: {ofShort.GetType()}");

            byte ofSbyte = (byte)sByte;
            Console.WriteLine($"Переменная ofSbyte- {ofSbyte} после явного приведения от переменной sByte- {sByte} относится к типу: {ofSbyte.GetType()}");

            long ofDecimal = (long)dec;
            Console.WriteLine($"Переменная ofDecimal- { ofDecimal} после явного приведения от переменной dec- {dec} относится к типу: {ofDecimal.GetType()}");

            // Неявное приведение

            long ofInt32 = int32;
            Console.WriteLine($"Переменная ofInt32- {ofInt32} после неявного приведения от переменной int32- {int32} относится к типу: {ofInt32.GetType()}");

            int ofByte = bytte;
            Console.WriteLine($"Переменная ofByte- {ofByte} после неявного приведения от переменной bytte- {bytte} относится к типу: {ofByte.GetType()}");

            double ofFlooat = single;
            Console.WriteLine($"Переменная ofFloat- {ofFlooat} после неявного приведения от переменной single- {single} относится к типу: {ofFlooat.GetType()}");

            uint ofUshort = uInt16;
            Console.WriteLine($"Переменная ofUshort- {ofUshort} после неявного приведения от переменной uInt16- {uInt16} относится к типу: {ofUshort.GetType()}");

            ulong ofUint = uInt32;
            Console.WriteLine($"Переменная ofUint- {ofUint} после неявного приведения от переменной single- {uInt32} относится к типу: {ofUint.GetType()}");

            // 3 задание
            // Упаковка\распаковка

            object box = str;
            Console.WriteLine($"Упаковал строку {str}, тип объекта: {box.GetType()} ");

            string ofBox = (string)box;
            Console.WriteLine($"Распоковал тип: {ofBox.GetType()} ");
            // 4 задание

            var vInt = 564;
            var vStr = "Hello";
            var vCh = 'a';
            Console.WriteLine("Переменная vInt- {0} относится к типу: {1}", vInt, vInt.GetType());
            Console.WriteLine("Переменная vStr- {0} относится к типу: {1}", vStr, vStr.GetType());
            Console.WriteLine("Переменная vCh- {0} относится к типу: {1}", vCh, vCh.GetType());

            var vIntCh = vInt+vCh;
            vStr = vStr + vCh;
            Console.WriteLine("Переменная vStr- {0} относится к типу: {1}", vStr, vStr.GetType());
            Console.WriteLine("Переменная vIntCh- {0} относится к типу: {1}", vIntCh, vIntCh.GetType());


            // 5 задание
             

            int? nullableP = null;
            Console.WriteLine("Переменная nullableP- {0} ", nullableP);
            if (nullableP.HasValue)
            {
                nullableP = null;
            }
            else
            {
                nullableP = 34;
            }
            Console.WriteLine("Переменная nullableP- {0} относится к типу: {1}", nullableP, nullableP.GetType());

            //----------------------------------------Строки-------------
            
            string s = "Hello!";
            string t = "Hi!";
            if(s.Equals(t))
            {
                Console.WriteLine("Строка {1} равна строке {0}", s,t);
            }
            else
            {
                Console.WriteLine("Строка {1} не совпадает со строкой {0}", s, t);
            }

            

            String first = "How are you?";
            String second = "What are you do?";
            String third = "Where are you born?";

            String concat = String.Concat(first,second,third);

            Console.WriteLine(concat);

            String cop = String.Copy(second);

            Console.WriteLine(cop);

            String substring = first.Substring(4, 3);

            Console.WriteLine(substring);

            char[] del = ".,;:?\n\xD\xA\" ".ToCharArray();
            String[] split = third.Split(del,StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in split)
            {
                Console.WriteLine(word);
            }

            String ins = first.Insert(4, substring);
            Console.WriteLine(ins);

            String remove = second.Remove(5, 3);
            Console.WriteLine(remove);

            String empty = "";
            String nul = null;

            empty = empty.Insert(0, substring);
            nul = String.Concat(nul, first);
            Console.WriteLine(empty);
            Console.WriteLine(nul);

            StringBuilder stringBuilder = new StringBuilder("ABC", 70);
            stringBuilder = stringBuilder.Append("SDFFsa");
            stringBuilder = stringBuilder.Insert(0, "dgdsgd");
            stringBuilder = stringBuilder.Remove(6, 3);
            Console.WriteLine(stringBuilder);


            //-------------------------------------Массивы---------------------

            short[][] array = new short[4][] { new short[5] , new short[5] , new short[5] , new short[5] };
    
                foreach (short[] x in array)
                {
                   foreach(var c in x)
                    {
                        Console.Write("\t" + c);
                    }
                    Console.Write("\n");

                }

            string[] arrayStr = { "Qwertyuiop", "Asdfghjkl", "Zxcvbnm" };
            Console.WriteLine(arrayStr.Length);
            foreach(string x in arrayStr)
            {
                Console.WriteLine(x);
            }
            
            Console.WriteLine("Какую строку решите поменять (1-3)?");
            int numberOfString = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine("C какой позиции?");
            int position = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine("Введите строку для замены");
            string strToPast= Console.ReadLine();
            arrayStr[numberOfString] = arrayStr[numberOfString].Remove(position,strToPast.Length);
            arrayStr[numberOfString] = arrayStr[numberOfString].Insert(position, strToPast);

            foreach (string x in arrayStr)
            {
                Console.WriteLine(x);
            }

            double[][] arrTeeth = new double[3][] {new double[2], new double[3],new double[4]};

            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0;j < arrTeeth[i].Length; ++j)
                {
                    arrTeeth[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            foreach (double[] x in arrTeeth)
            {
                foreach(double c in x)
                {
                    Console.Write("\t" + c );
                }
                Console.WriteLine();
            }

            var localP = new int[3] { 32, 32, 34 };
            Console.WriteLine("Переменная относится к типу: {0}", localP.GetType());
            var st = "Hsadfafdd";
            Console.WriteLine("Переменная относится к типу: {0}", st.GetType());
            
            //----------------------------------Кортежи------------------------
            (int kurs, string name , char group , string surname , ulong age) cortage = (2, "Vitaliy" , 'f' , "Filippov" , 2000);
            (int kurs, string name, char group, string surname, ulong age) cortage1 = (2, "Evgeniy", 'f', "Fando", 1999);
            Console.WriteLine($"{ cortage.age.ToString()} , {cortage.kurs.ToString()} , {cortage.name} , {cortage.surname } , { cortage.group}");
            Console.WriteLine(cortage);
            var (one, two,thre,four,five) = CreateCortage(cortage);
            Console.WriteLine($"{one} , {thre} , {five}");
            Console.WriteLine(cortage1.CompareTo(cortage));
            int[] arr1 = { 23, 42, 234, 23, 123, 21 };
            Console.WriteLine(LocalFunction("Goverment",arr1));
            Console.ReadKey(true);
            (int kurs, string name, char group, string surname, ulong age) CreateCortage((int kurs, string name, char group, string surname, ulong age) cor)
            {
                int kurs = cor.kurs;
                string name = cor.name;
                char group = cor.group;
                string surname = cor.surname;
                ulong age = cor.age;
                return (kurs,name,group, surname, age);
            }

            (int max, int min , int sum , char simv) LocalFunction(string arr, int[] a)
            {
                (int max, int min, int sum, char simv) cort = (a.Max(), a.Min(), a.Sum(), arr[0]);
                return (cort);
            }
        }
    }
}