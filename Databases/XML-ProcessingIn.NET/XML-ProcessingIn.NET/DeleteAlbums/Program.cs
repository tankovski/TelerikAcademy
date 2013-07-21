using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class Program
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../../catalog.xml");
        XmlNode rootNode = doc.DocumentElement;
        List<XmlNode> albumsForDeleting = new List<XmlNode>();
        foreach (XmlNode node in rootNode.ChildNodes)
        {
            int price = int.Parse(node["price"].InnerText);
            if (price > 20)
            {
                albumsForDeleting.Add(node);

            }
        }

        foreach (var album in albumsForDeleting)
        {
            doc.DocumentElement.RemoveChild(album);
        }

        doc.Save("../../newCatalog.xml");

        //For save the changes to the same file
        //doc.Save("../../catalog.xml");

    }
}

