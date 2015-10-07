using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProcessingXMLIn.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            var catalogFilePath = "../../../../catalog.xml";
            doc.Load(catalogFilePath);
            Console.WriteLine("Doc Loaded!");
            Console.WriteLine();

            // solution with DOM Parser
            XmlNode rootNode = doc.DocumentElement;
            // solution with XPath
            string xPathArtistQuery = "/catalog/album/artist";
            XmlNodeList artistsList = doc.SelectNodes(xPathArtistQuery);

            Hashtable artists = new Hashtable();

            //foreach (XmlNode artistNode in artistsList)
            //{
            //    var currentArtist = artistNode.InnerText;
            //    int albumsCount;
            //    if (!artists.Contains(currentArtist))
            //    {
            //        albumsCount = 1;
            //    }
            //    else
            //    {
            //        albumsCount = (int)artists[currentArtist];
            //        albumsCount++;
            //        artists.Remove(currentArtist);
            //    }

            //    artists.Add(artistNode.InnerText, albumsCount);
            //}

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentArtist = node["artist"].InnerText;
                var albumsCount = 1;
                if (artists.ContainsKey(currentArtist))
                {
                    albumsCount = (int)artists[currentArtist];
                    albumsCount++;
                    artists.Remove(currentArtist);
                }

                artists.Add(currentArtist, albumsCount);
            }

            Console.WriteLine("Artist : Number of Albums");
            foreach (DictionaryEntry pair in artists)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            string xPathExpensiveAlbumsQuery = "/catalog/album[price>20]";
            var allAlbumsCostingMoreThan20Dollars = doc.SelectNodes(xPathExpensiveAlbumsQuery);

            Console.WriteLine();
            foreach (XmlNode album in allAlbumsCostingMoreThan20Dollars)
            {
                
                rootNode.RemoveChild(album);
                doc.Save(catalogFilePath);
                Console.WriteLine("Deleted {0} by {1}, which costs {2}",
                        album["name"].InnerText,
                        album["artist"].InnerText,
                        album["price"].InnerText);
            }
        }
    }
}
