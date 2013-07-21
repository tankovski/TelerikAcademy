using System.Xml.Xsl;

class Program
{
    static void Main(string[] args)
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("../../catalog.xsl");
        xslt.Transform("../../catalog.xml", "../../catalog.html");
    }
}

