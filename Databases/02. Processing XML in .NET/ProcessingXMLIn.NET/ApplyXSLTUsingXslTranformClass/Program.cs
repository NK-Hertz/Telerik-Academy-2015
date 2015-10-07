using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace ApplyXSLTUsingXslTranformClass
{
    class Program
    {
        static void Main(string[] args)
        {
            XslCompiledTransform transformer = new XslCompiledTransform();
            transformer.Load("../../../../catalog-xml2html.xslt");
            transformer.Transform("../../../../catalog.xml", "../../resultCatalog.html");
            Console.WriteLine("Job Done!");
        }
    }
}
