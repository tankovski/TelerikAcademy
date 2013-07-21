using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("../../../catalog.xml");
        var albums =
            from song in xmlDoc.Descendants("song")
            select new
            {
                Title = song.Element("title").Value,
                
            };
        foreach (var book in albums)
        {
            Console.WriteLine(book.Title);
        }
    }
}
