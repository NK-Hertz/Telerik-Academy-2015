using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateXMLDocument
{
    class CreateXMLDocument
    {
        static void Main(string[] args)
        {
            var pathToSource = "../../Person.txt";
            var personInfo = new List<string>();
            using (StreamReader sr = new StreamReader(pathToSource))
            {
                while (!sr.EndOfStream)
                {
                    var currentLine = sr.ReadLine();
                    personInfo.Add(currentLine);
                }
            }

            XDocument doc = new XDocument(
                new XElement("person",
                    new XElement("name", personInfo[0]),
                    new XElement("address", personInfo[1]),
                    new XElement("phone", personInfo[2])
                )
            );

            doc.Save("../../person.xml");
            Console.WriteLine("File created!");
        }
    }
}
