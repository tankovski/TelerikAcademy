using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SqlSupermarketModel;
using System.Threading;
using System.Globalization;

public class XmlController
{

    public static void WriteXmlReport(IEnumerable<XmlReport> reports)
    {

        string fileName = "../../../Sales-by-Vendors-report.xml";
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("sales");

            string vendorName = "";
            bool isFirst = true;
            foreach (var report in reports)
            {
                if (report.VendorName !=vendorName && isFirst == true)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", report.VendorName);

                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();

                    vendorName = report.VendorName;
                    isFirst = false;
                }
                else if (report.VendorName !=vendorName && isFirst == false)
                {
                    writer.WriteEndElement();
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", report.VendorName);

                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();

                    vendorName = report.VendorName;
                }
                else
                {
                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();

            writer.WriteEndDocument();
        }
    }

    public static ICollection<Expenses> ReadExpensesFromXml()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        using (supermarketEntities sqlDb = new supermarketEntities())
        {
            Dictionary<string, int> vendorIds = new Dictionary<string, int>();
            var vendors = sqlDb.Vendors;

            foreach (var item in vendors)
            {
                vendorIds.Add(item.VendorName, item.ID);
            }

            List<Expenses> expenses = new List<Expenses>();
            using (XmlReader reader = XmlReader.Create("../../../Vendor-Expences.xml"))
            {
                string name = "";
                string date = null;
                decimal expense = 0;
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "sale"))
                    {
                        name = reader.GetAttribute(0);

                    }
                    else if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "expenses"))
                    {
                        date = reader.GetAttribute("month");
                        expense = decimal.Parse(reader.ReadElementContentAsString());
                        Expenses newExpense = new Expenses()
                        {
                            ID = expenses.Count+1,
                            VendorID = vendorIds[name],
                            Expenses1 = expense,
                            Mounth = date
                        };

                        expenses.Add(newExpense);
                    }
                }
            }
         
            return expenses;
        }
    }
}

