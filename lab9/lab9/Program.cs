using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer("Скуби");
            ProgrammingLanguage p = new ProgrammingLanguage("JS",4.5f,"Add","Del","Rename");
            ProgrammingLanguage c = new ProgrammingLanguage("C#", 7.0f, "Add", "Del");
            Console.WriteLine(p.ToString());
            p.GetOperation();
            Console.WriteLine(c.ToString());
            c.GetOperation();
            c.NewOpt = p.NewOpt = "Concat";
            programmer.NewProperty += p.AddOperation;
            programmer.NewProperty += c.AddOperation;
            p.DelOpt = "Del";
            programmer.NewProperty += p.DeleteOptions;
            programmer.Rename += p.NewVersion;
            programmer.CommandAddOperation();
            programmer.CommandRenOperation();
            p.NewOpt = "Range";
            c.NewOpt = "District";
            programmer.NewProperty -= p.DeleteOptions;
            programmer.CommandAddOperation();
            Console.WriteLine(p.ToString());
            p.GetOperation();
            Console.WriteLine(c.ToString());
            c.GetOperation();

            //------------------------------
            string str = "dne/ir*f @y#m ,";

            string forExampleStr = "Abrarkadabra";
            Console.WriteLine(StringFunction.OperationString(forExampleStr, x => x.Replace("bra", String.Empty)));


            Console.WriteLine($"Строка до: {str}");
            str = StringFunction.AddStr(str, "?dlr_ow_)_(     ^o_l_l)eh");
            Console.WriteLine($"После: {str}\n");

            Console.WriteLine($"Строка до: {str}");
            StringFunction.StringFun delStrFun = StringFunction.RemoveSymbol;
            delStrFun += StringFunction.Reverse;
            delStrFun += StringFunction.ToUpperFirstLetters;
            delStrFun += StringFunction.RemoveSpace;
            delStrFun(ref str);
            Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.RemoveSymbol(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.Reverse(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.ToUpperFirstLetters(str);
            //Console.WriteLine($"После: {str}\n");

            //Console.WriteLine($"Строка до: {str}");
            //str = StringFunction.RemoveSpace(str);
            //Console.WriteLine($"После: {str}\n");

            Console.ReadKey();
        }

        


    }
}
