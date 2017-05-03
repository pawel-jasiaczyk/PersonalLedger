using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace PersonalLedger
{
    public class Parser
    {
        public string XmlString { get; set; }
        public XDocument XDoc;
        


        public string OpenXmlFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                this.XmlString = sr.ReadToEnd();
            }
            this.XDoc = XDocument.Parse(this.XmlString);
            return this.XmlString;
        }

        public Ledger ParseXml()
        {
            if(this.XDoc == null)
            {
                throw new NullReferenceException("There is no defined and XML document - parameter XDoc is null");
            }
            TestLedger ledger = new TestLedger();

            XNamespace table = "urn:oasis:names:tc:opendocument:xmlns:table:1.0";
            XNamespace text = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";
            var Rows = XDoc.Descendants(table + "table-row");
            var firstRow = Rows.First();
            var strings = from cell
                          in firstRow.Descendants(table + "table-cell")
                          select cell.IsEmpty ? null : 
                            from str in cell.Descendants(text + "p") select (string)str.Value;
            foreach(var s in strings)
            {
                if (s == null)
                    Console.WriteLine();
                else
                    Console.WriteLine(s);
            }

            ledger.ElementsList = Rows.ToArray();

            return ledger;
        }

        public Ledger ParseXml(string path)
        {
            OpenXmlFile(path);
            return ParseXml();
        }
    }

    public class TestLedger : Ledger
    {
        public XElement[] ElementsList;

        public TestLedger() : base()
        {

        }
    }
}
