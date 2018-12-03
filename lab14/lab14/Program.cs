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
            Serializ();
            Deserializ();
            SerializJsonArr();
            DeserializJsonArr();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"E:\Универ\ООП\Лабы\objXml.xml");
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlNodeList xmlNode = xRoot.SelectNodes("*");

            foreach (XmlNode n in xmlNode)
            {
                Console.WriteLine(n.OuterXml);
            }
            xmlNode = xRoot.SelectNodes("nameDec");//XPath
            foreach (XmlNode n in xmlNode)
            {
                Console.WriteLine(n.Name);
                Console.WriteLine(n.OuterXml);
            }


            XDocument xdoc = new XDocument();
            XElement xEl = new XElement("Root");
            XElement el1 = new XElement("Layer1", ".com");
            XElement el2 = new XElement("Layer1", ".arpa");
            XElement el3 = new XElement("Layer1", ".ru");
            XElement el11 = new XElement("Layer2", ".microsoft");
            el1.Add(el11);
            xEl.Add(el1, el2, el3);
            xdoc.Add(xEl);
            xdoc.Save(@"E:\Универ\ООП\Лабы\XmlMyObj.xml");

            var v = from xe in xdoc.Element("Root").Elements("Layer1")
                    where xe.Value == ".arpa"
                    select xe;
                    
            Console.WriteLine(v.ElementAt(0).Name + " - " + v.ElementAt(0).Value);
            Console.ReadKey();
        }
        public static void SerializJsonArr()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Window[] arrayWins = new Window[] { new Window("Black", "Opera"), new Window("Time new Roman", "Microsoft Office"), new Window("BlackRed", "Nod32"), new Window("Blue", "Chromium"), new Window() };
            DataContractJsonSerializer json;
            using (Stream st = new FileStream(@"E:\Универ\ООП\Лабы\arrObjJson.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                json = new DataContractJsonSerializer(typeof(Window[]));
                json.WriteObject(st, arrayWins);
            }
            Console.WriteLine("Сериализовали массив используя JSON формат"); 
        }

        public static void DeserializJsonArr()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Window[] arrWin;
            DataContractJsonSerializer json;
            using (Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\arrObjJson.json"))
            {
                json = new DataContractJsonSerializer(typeof(Window[]));
                arrWin = json.ReadObject(st) as Window[];
            }
            Console.WriteLine($"Десериализовали используя JSON формат");
            foreach(var n in arrWin)
            {
                Console.WriteLine($"{n.ToString()}");
            }
        }
        public static void Serializ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Window win1 = new Window("Cayan", "Terminal");
            BinaryFormatter bin;
            using (Stream st = new FileStream(@"E:\Универ\ООП\Лабы\objBin.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                bin = new BinaryFormatter();
                bin.Serialize(st, win1);
            }
            Console.WriteLine("Сериализовали используя бинарный формат");

            Console.ForegroundColor = ConsoleColor.Blue;
            SoapFormatter soap;
            using (Stream st = new FileStream(@"E:\Универ\ООП\Лабы\objSoap.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soap = new SoapFormatter();
                soap.Serialize(st, win1);
            }
            Console.WriteLine("Сериализовали используя SOAP формат");

            Console.ForegroundColor = ConsoleColor.Cyan;
            XmlSerializer xml;
            using (Stream st = new FileStream(@"E:\Универ\ООП\Лабы\objXml.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xml = new XmlSerializer(typeof(Window));
                xml.Serialize(st, win1);
            }
            Console.WriteLine("Сериализовали используя XML формат");

            Console.ForegroundColor = ConsoleColor.Blue;
            DataContractJsonSerializer json;
            using (Stream st = new FileStream(@"E:\Универ\ООП\Лабы\objJson.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                json = new DataContractJsonSerializer(typeof(Window));
                json.WriteObject(st, win1);
            }
            Console.WriteLine("Сериализовали используя JSON формат");
        }

        public static void Deserializ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            BinaryFormatter bin;
            Window winBin;
            Window winSoap;
            Window winXml;
            Window winJson;
            using (Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objBin.txt"))
            {
                bin = new BinaryFormatter();
                winBin = (Window)bin.Deserialize(st);
            }
            Console.WriteLine($"Десериализовали используя бинарный формат\n {winBin.ToString()}");
            Console.ForegroundColor = ConsoleColor.Blue;

            SoapFormatter soap;
            using (Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objSoap.soap"))
            {
                soap = new SoapFormatter();
                winSoap = (Window)soap.Deserialize(st);

            }
            Console.WriteLine($"Десериализовали используя SOAP формат\n {winSoap.ToString()}");
            Console.ForegroundColor = ConsoleColor.Cyan;

            DataContractJsonSerializer json;
            using (Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objJson.json"))
            {
                json = new DataContractJsonSerializer(typeof(Window));
                winJson = (Window)json.ReadObject(st);
            }
            Console.WriteLine($"Десериализовали используя JSON формат\n {winJson.ToString()}");
            Console.ForegroundColor = ConsoleColor.Blue;

            XmlSerializer xml;
            using (Stream st = File.OpenRead(@"E:\Универ\ООП\Лабы\objXml.xml"))
            {
                xml = new XmlSerializer(typeof(Window));
                winXml = (Window)xml.Deserialize(st);
            }
            Console.WriteLine($"Десериализовали используя XML формат\n {winXml.ToString()}");
        }
    }
}
