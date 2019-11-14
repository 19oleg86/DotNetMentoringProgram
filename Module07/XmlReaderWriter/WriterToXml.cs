using Resources;
using System.Xml;

namespace XmlReaderWriter
{
    public class WriterToXml
    {
        public void WriteToXml(string path, Book book, Newspaper newspaper, Patent patent)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = false
            };
            using (XmlWriter xml = XmlWriter.Create(path, xmlWriterSettings))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("catalog");

                xml.WriteStartElement("books");
                xml.WriteStartElement("book");
                xml.WriteAttributeString("name", book.Name);
                xml.WriteElementString("author", book.Author);
                xml.WriteElementString("publishCity", book.PublishCity);
                xml.WriteElementString("publisherName", book.PublisherName);
                xml.WriteElementString("yearOfPublish", book.YearOfPublish.ToString());
                xml.WriteElementString("numberOfPages", book.NumberOfPages.ToString());
                xml.WriteElementString("remark", book.Remark);
                xml.WriteElementString("ISBN", book.ISBN);
                xml.WriteEndElement();
                xml.WriteEndElement();

                xml.WriteStartElement("newspapers");
                xml.WriteStartElement("newspaper");
                xml.WriteAttributeString("name", newspaper.Name);
                xml.WriteElementString("publishCity", newspaper.PublishCity);
                xml.WriteElementString("publisherName", newspaper.PublisherName);
                xml.WriteElementString("yearOfPublish", newspaper.YearOfPublish.ToString());
                xml.WriteElementString("numberOfPages", newspaper.NumberOfPages.ToString());
                xml.WriteElementString("remark", newspaper.Remark);
                xml.WriteElementString("number", newspaper.Number.ToString());
                xml.WriteElementString("date", newspaper.Date.ToString());
                xml.WriteElementString("ISSN", newspaper.ISSN);
                xml.WriteEndElement();
                xml.WriteEndElement();

                xml.WriteStartElement("patents");
                xml.WriteStartElement("patent");
                xml.WriteAttributeString("name", patent.Name);
                xml.WriteElementString("inventer", patent.Inventer);
                xml.WriteElementString("country", patent.Country);
                xml.WriteElementString("registerNumber", patent.RegisterNumber.ToString());
                xml.WriteElementString("applyDate", patent.ApplyDate.ToString());
                xml.WriteElementString("publishDate", patent.PublishDate.ToString());
                xml.WriteElementString("numberOfPages", patent.NumberOfPages.ToString());
                xml.WriteElementString("remark", patent.Remark);
                xml.WriteEndElement();
                xml.WriteEndElement();

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }
    }
}
