using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Validation
{
    class Program
    {
        static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../catalog.xsd");

            //Valid xml file
            XDocument doc = XDocument.Load("../../catalog.xml");

            //Invalid xml file
            //XDocument doc = XDocument.Load("../../InvalidCatalog.xml");
            string msg = "";
            doc.Validate(schemas, (o, e) =>
            {
                msg = e.Message;
            });
            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);
        }
    }
}
