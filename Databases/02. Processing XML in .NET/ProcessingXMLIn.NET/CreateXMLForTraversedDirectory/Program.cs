using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CreateXMLForTraversedDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePathXml = "../../traversedDirectoryXml.xml";
            var filePathXDoc = "../../traversedDirectoryXDoc.xml";
            var traversePath = "../../../../ProcessingXMLIn.NET";

            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter(filePathXml, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                DirectoryInfo pathToTraverse = new DirectoryInfo(traversePath);
                TraverseDirectoryXML(writer, pathToTraverse);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            XDocument doc = new XDocument();
            XElement root = new XElement("directories");
            doc.Add(root);
            DirectoryInfo di = new DirectoryInfo(traversePath);

            TraverseDirectoryXDoc(di, root);
            
            doc.Save(filePathXDoc);
        }

        private static void TraverseDirectoryXML(XmlWriter writer, DirectoryInfo dir)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", dir.Name);

            try
            {
                var files = dir.GetFiles("*.*");
                foreach (var file in files)
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", file.Name);
                    writer.WriteString(file.ToString());
                    writer.WriteEndElement();
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            var subdirs = dir.GetDirectories();

            foreach (var subdir in subdirs)
            {
                TraverseDirectoryXML(writer, subdir);
            }

            writer.WriteEndElement();
        }

        private static void TraverseDirectoryXDoc(DirectoryInfo dirInfo, XElement root)
        {
            XElement dir = new XElement("dir");
            dir.SetAttributeValue("name", dirInfo.Name);
            root.Add(dir);

            var files = dirInfo.GetFiles();

            foreach (var file in files)
            {
                root.Add(new XElement("file", new XAttribute("name", file.Name),
                        new XAttribute("description", file.Name)));
            }

            var subdirs = dirInfo.GetDirectories();

            foreach (var subdir in subdirs)
            {
                TraverseDirectoryXDoc(subdir, dir);
            }
        }
    }
}
