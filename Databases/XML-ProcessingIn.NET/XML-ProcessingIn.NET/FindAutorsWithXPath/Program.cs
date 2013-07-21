using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../../catalog.xml");
        string xPathQuery = "/catalog/album";

        XmlNodeList albumsList = xmlDoc.SelectNodes(xPathQuery);
        Hashtable hash = new Hashtable();
        List<string> autors = new List<string>();


        foreach (XmlNode node in albumsList)
        {
            string autorName = node.SelectSingleNode("artist").InnerText;
            if (!hash.ContainsKey(autorName))
            {               
                hash.Add(autorName,1);
                autors.Add(autorName);
            }
            else
            {
                int count = (int)hash[autorName];
                hash[autorName] = count + 1;
            }
        }


        foreach (var autor in autors)
        {
            Console.WriteLine("Autor: {0} have {1} albums in the catalog.", autor, hash[autor]);
        }

    }
}
