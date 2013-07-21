using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace FindOutorsWithDOM
{
    class Program
    {
        static void Main()
        {
            Hashtable hash = new Hashtable();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            List<string> autors = new List<string>();


            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string autorName = node["artist"].InnerText;
                if (!hash.ContainsKey(autorName))
                {
                    hash.Add(autorName, 1);
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
              Console.WriteLine("Autor: {0} have {1} albums in the catalog.", autor,hash[autor]);
            }
            
            
            
        }
    }
}
