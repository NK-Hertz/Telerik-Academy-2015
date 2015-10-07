using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ValidateXMLByUsingXSD
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReaderSettings catalogSettings = new XmlReaderSettings();
            catalogSettings.Schemas.Add("", XmlReader.Create("../../../../catalog-schema.xsd"));
            catalogSettings.ValidationType = ValidationType.Schema;
            catalogSettings.ValidationEventHandler += 
                new ValidationEventHandler(CatalogSettingsValidationEventHandler);

            // switch between "catalog - Invalid.xml" and "catalog.xml" 
            XmlReader catalog = XmlReader.Create("../../../../catalog - Invalid.xml", catalogSettings);

            while (catalog.Read())
            { }
        }

        private static void CatalogSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("Warning!");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
