using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreateAlbumFromCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var artists = new List<string>();
            var albums = new List<string>();

            var catalogFilePath = "../../../../catalog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(catalogFilePath);
            using (XmlNodeReader reader = new XmlNodeReader(doc))
            {
                reader.MoveToContent();
                reader.ReadToDescendant("album");

                while (reader.Read())
                {
                    var albumName = reader.ReadInnerXml();
                    albums.Add(albumName);

                    var artist = reader.ReadInnerXml();
                    artists.Add(artist);

                    reader.ReadToFollowing("album");
                }
            }

            string albumFilePath = "../../album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(albumFilePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                for (int i = 0, len = artists.Count; i < len; i++)
                {
                    WriteAlbum(writer, albums[i], artists[i]);
                }
                writer.WriteEndDocument();
            }

            Console.WriteLine("Document {0} created.", albumFilePath);
        }

        private static void WriteAlbum(XmlWriter writer, string albumTitle, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("title", albumTitle);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
