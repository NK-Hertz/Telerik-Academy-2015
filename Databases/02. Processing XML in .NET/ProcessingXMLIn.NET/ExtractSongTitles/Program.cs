using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractSongTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument doc = new XmlDocument();
            var catalogFileName = "../../../../catalog.xml";
            //doc.Load(catalogFileName);
            //Console.WriteLine("Doc Loaded!");
            //Console.WriteLine();

            //var songTitles = new List<string>();
            //using (XmlNodeReader reader = new XmlNodeReader(doc))
            //{
            //    reader.MoveToContent();
            //    reader.ReadToDescendant("album");

            //    while (reader.Read())
            //    {
            //        reader.ReadToDescendant("title");
            //        if (!String.IsNullOrEmpty(reader.Value))
            //        {
            //            songTitles.Add(reader.Value);
            //        }
            //    }

            //    Console.WriteLine("Songs added!");
            //    Console.WriteLine();
            //}

            //foreach (var song in songTitles)
            //{
            //    Console.WriteLine(song);
            //}

            XDocument xdoc = XDocument.Load(catalogFileName);
            Console.WriteLine("Doc Loaded!");
            Console.WriteLine();

            IEnumerable<string> songs = from value in xdoc.Descendants("title")
                                  select (string)value;

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
