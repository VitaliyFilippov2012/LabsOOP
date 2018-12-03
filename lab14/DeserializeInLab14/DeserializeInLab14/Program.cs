using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
 
            Window winXml;
            Window winJson;
            DataContractJsonSerializer json;
            using(Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objJson.json"))
            {
                json = new DataContractJsonSerializer(typeof(Window));
                winJson = (Window)json.ReadObject(st);
            }
            Console.WriteLine($"Десериализовали используя JSON формат\n {winJson.ToString()}");
            Console.ForegroundColor = ConsoleColor.Blue;

            XmlSerializer xml;
            using(Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objXml.xml"))
            {
                xml = new XmlSerializer(typeof(Window));
                winXml = (Window)xml.Deserialize(st);
            }
            Console.WriteLine($"Десериализовали используя XML формат\n {winXml.ToString()}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ReadKey();
        }
    }
}
