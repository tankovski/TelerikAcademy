using System;
using System.Xml;

namespace PricesOfAlbumsOlderThan5YearsWithXpPath
{
    class Program
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");
            string xPathQuery = "/catalog/album";

            XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumsList)
            {
                int year = int.Parse(node.SelectSingleNode("year").InnerText);
                if (DateTime.Now.Year - year >= 5)
                {
                    decimal price = decimal.Parse(node.SelectSingleNode("price").InnerText);
                    Console.WriteLine(price);
                }
            }
        }
    }
}
