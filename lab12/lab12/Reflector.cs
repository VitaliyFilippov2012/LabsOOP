using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Reflector : IReflector
    {
        public void WriteInfoAboutClassInFile(Type typeobj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string writePath = @"E:\Универ\ООП\Лабы\InfoAboutClassLab12.txt";
            PropertyInfo[] prI = typeobj.GetProperties();
            MethodInfo[] mI = typeobj.GetMethods();
            FieldInfo[] fI = typeobj.GetFields();
            ConstructorInfo[] cI = typeobj.GetConstructors();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
                {
                sw.WriteLine(new String('/', 50));
                sw.WriteLine("\nConstructor Info:");
                foreach (var n in cI)
                {
                    ParameterInfo[] parI = n.GetParameters();
                    sw.WriteLine(" " + n.Name + " " + typeobj + "(");
                    for (int i = 0; i < parI.Length; i++)
                    {
                        sw.Write(parI[i].ParameterType.Name + " " + parI[i].Name);
                        if (i + 1 < parI.Length)
                        {
                            sw.Write(", ");
                        }
                        sw.WriteLine(")");
                    }
                }
                sw.WriteLine("\nMethods Info");
                foreach(var n in mI)
                {
                    sw.WriteLine("Method Name = " + n.Name);
                    sw.WriteLine("Method Return Type = " + n.ReturnType);
                    foreach(var m in n.GetParameters())
                    {
                        sw.WriteLine("Parameter Name = " + m.Name);
                        sw.WriteLine("Type = " + m.ParameterType);
                    }
                }
                sw.WriteLine("\nFields Info:");
                foreach(var f in fI)
                {
                    sw.WriteLine("Field = " + f.Name);
                }
                sw.WriteLine("\nProperties info");
                foreach(var p in prI)
                {
                    sw.WriteLine("Property = " + p.Name);
                }
                sw.WriteLine(new String('/',50));
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("The recording in file is finished");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void GetPublicMethod(Type typeobj)
        {
            var fl =  BindingFlags.Public | BindingFlags.Instance;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
            MethodInfo[] mI = typeobj.GetMethods(fl);
            
            Console.WriteLine("Methods info");
            foreach (var m in mI)
            {
                Console.WriteLine(" - Method Name = " + m.Name);
                Console.WriteLine(" - Method Return Type = " + m.ReturnType);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void GetFieldAndProperty(Type typeobj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
            PropertyInfo[] pi = typeobj.GetProperties();
            FieldInfo[] fi = typeobj.GetFields();
            Console.WriteLine("Property info");
            foreach (var n in pi)
            {
                Console.WriteLine(" - " + n.PropertyType + " - " + n.Name);
            }
            Console.WriteLine("Field info");
            foreach (FieldInfo m in fi)
            {
                Console.WriteLine(" - " + m.FieldType + " " + m.Name);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void GetInterface(Type typeobj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
            var interf = typeobj.GetInterfaces();
            
            Console.WriteLine("Interface info");
            foreach (Type m in interf)
            {
                Console.WriteLine(m.DeclaringType + " - " + m.Name);
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public void GetPublicMethod(Type typeobj, string typeMet)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
            MethodInfo[] mI = typeobj.GetMethods();
            Console.WriteLine("Methods info");
            foreach (MethodInfo m in mI)
            {
                ParameterInfo[] pi = m.GetParameters();
                if (m.ReturnType.Name == typeMet)
                {
                    Console.WriteLine(" - " + m.Name +" : "+ m.ReturnType.Name);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Met(Type typeobj, string method, Object obj)
        {
            Console.WriteLine(new string('-', 50));
            MethodInfo mI = typeobj.GetMethod(method);
            Console.WriteLine($"Run method: {method}");
            Console.WriteLine(" - " + mI.Name + " - " + mI.ReturnParameter.ParameterType.Name);

            int param;
            string namePath = @"E:\Универ\ООП\Лабы\param.txt";
            try
            {
                using (StreamReader sw = new StreamReader(namePath, Encoding.Default))
                {
                    param = int.Parse(sw.ReadLine());
                }
               
                mI.Invoke(obj, new object[] {param});
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
                
    }
}
