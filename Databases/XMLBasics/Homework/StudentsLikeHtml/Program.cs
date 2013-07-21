using System.Xml.Xsl;

class Program
{
    static void Main(string[] args)
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("../../students.xsl");
        xslt.Transform("../../students.xml", "../../students.html");
    }
}

