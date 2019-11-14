using Resources;
using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace XmlReaderWriter
{
    public class ReaderFromXml
    {
        Book book = new Book();
        Newspaper newspaper = new Newspaper();
        Patent patent = new Patent();
        public ArrayList ReadFromXml(string path)
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
                            if (xml.Name == "newspapers")
                            {
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "newspaper");
                                if (xml.HasAttributes)
                                {
                                    while (xml.MoveToNextAttribute())
                                    {
                                        if (xml.Name == "name")
                                            newspaper.Name = xml.Value;
                                    }
                                    do
                                    {
                                        xml.Read();
                                    } while (xml.Name != "publishCity");
                                }
                                newspaper.PublishCity = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "publisherName");
                                newspaper.PublisherName = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "yearOfPublish");
                                newspaper.YearOfPublish = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "numberOfPages");
                                newspaper.NumberOfPages = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "remark");
                                newspaper.Remark = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "number");
                                newspaper.Number = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "date");
                                newspaper.Date = DateTime.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "ISSN");
                                newspaper.ISSN = xml.ReadInnerXml();
                            }
                            if (xml.Name == "patents")
                            {
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "patent");
                                if (xml.HasAttributes)
                                {
                                    while (xml.MoveToNextAttribute())
                                    {
                                        if (xml.Name == "name")
                                            patent.Name = xml.Value;
                                    }
                                    do
                                    {
                                        xml.Read();
                                    } while (xml.Name != "inventer");
                                }
                                patent.Inventer = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "country");
                                patent.Country = xml.ReadInnerXml();
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "registerNumber");
                                patent.RegisterNumber = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "applyDate");
                                patent.ApplyDate = DateTime.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "publishDate");
                                patent.PublishDate = DateTime.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "numberOfPages");
                                patent.NumberOfPages = int.Parse(xml.ReadInnerXml());
                                do
                                {
                                    xml.Read();
                                } while (xml.Name != "remark");
                                patent.Remark = xml.ReadInnerXml();
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("This xml document isn't exist");
            }
            return new ArrayList() { book, newspaper, patent };
        }
    }
}
