using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlReaderWriter
{
    public class ReaderFromXml
    {
        ArrayList finalList;
        Book book = new Book();
        string lastNodeName;
        public ArrayList ReadFromXml(string path, ArrayList listOfObjects)
        {
            if (File.Exists(path))
            {
                using (XmlReader xml = XmlReader.Create(path))
                {
                    while (xml.Read())
                    {
                        if (xml.NodeType == XmlNodeType.Element)
                        {
                            if (xml.Name == "books")
                            {
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "book");
                                if (xml.HasAttributes)
                                {
                                    while (xml.MoveToNextAttribute())
                                    {
                                        if (xml.Name == "name")
                                            book.Name = xml.Value;
                                    }
                                    do
                                    {
                                        xml.Read();
                                    } while (xml.Name != "author");
                                }
                                book.Author = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "publishCity");
                                book.PublishCity = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "publisherName");
                                book.PublisherName = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "yearOfPublish");
                                book.YearOfPublish = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "numberOfPages");
                                book.NumberOfPages = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "remark");
                                book.Remark = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "ISBN");
                                book.ISBN = xml.ReadInnerXml();
                            }
                        }
                    }
                }
            }
            return new ArrayList() { book };
        }
    }
}
