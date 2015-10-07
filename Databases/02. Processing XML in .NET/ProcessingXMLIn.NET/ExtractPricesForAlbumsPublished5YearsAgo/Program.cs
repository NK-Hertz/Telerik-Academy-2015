using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractPricesForAlbumsPublished5YearsAgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalogPath = "../../../../catalog.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(catalogPath);
            Console.WriteLine("Doc Loaded!");
            Console.WriteLine();

            string xPathQuery = "/catalog/album[year<2010]/price";
            XmlNodeList pricesOfAlbumsReleasedUntil2010 = doc.SelectNodes(xPathQuery);

            foreach (XmlNode price in pricesOfAlbumsReleasedUntil2010)
            {
                Console.WriteLine(price.InnerText);
            }
                
            XDocument xdoc = XDocument.Load(catalogPath);
            var pricesOfAlbumsReleasedUntil2010LINQ = from item in xdoc.Descendants("album")
                                                      where int.Parse(item.Element("year").Value) < 2010
                                                      select item.Element("price");

            foreach (var price in pricesOfAlbumsReleasedUntil2010LINQ)
            {
                Console.WriteLine(price.Value);
            }
        }
    }
}
