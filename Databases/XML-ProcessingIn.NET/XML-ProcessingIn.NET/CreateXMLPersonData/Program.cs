using System.Xml.Linq;
using System.IO;

public class Program
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\person.txt");
        string name=null;
        string address=null;
        string phone=null;
        using (reader)
        {
            string line = reader.ReadLine();
            int count = 1;

            while (line!=null)
            {
                switch (count)
                {
                    case 1:
                        {
                            name = line;
                        }
                        break;
                    case 2:
                        {
                            address = line;
                        }
                        break;
                    case 3:
                        {
                            phone = line;
                        }
                        break;
                    default:
                        break;
                }
                count++;
                line = reader.ReadLine();
            }
               
            
        }

        XElement personXml =
            new XElement("person",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phone", phone)
                );
        

        System.Console.WriteLine(personXml);

        personXml.Save("../../person.xml");
    }
}
