using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Resources
{
    public class Newspaper
    {
        public string Name { get; set; }
        public string PublishCity { get; set; }
        public string PublisherName { get; set; }
        public int YearOfPublish { get; set; }
        public int NumberOfPages { get; set; }
        public string Remark { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string ISSN { get; set; }

        public Newspaper()
        {
        }

        public Newspaper(XElement child)
        {
            var properties = child.Elements().Where(x => x.NodeType == XmlNodeType.Element).ToList();
            Name = child.FirstAttribute.Value;
            PublishCity = properties.FirstOrDefault(x => x.Name == "publishCity")?.Value;
            PublisherName = properties.FirstOrDefault(x => x.Name == "publisherName")?.Value;
            YearOfPublish = int.Parse(properties.FirstOrDefault(x => x.Name == "yearOfPublish")?.Value);
            NumberOfPages = int.Parse(properties.FirstOrDefault(x => x.Name == "numberOfPages")?.Value);
            Remark = properties.FirstOrDefault(x => x.Name == "remark")?.Value;
            Number = int.Parse(properties.FirstOrDefault(x => x.Name == "number")?.Value);
            Date = DateTime.Parse(properties.FirstOrDefault(x => x.Name == "date")?.Value);
            ISSN = properties.FirstOrDefault(x => x.Name == "ISSN")?.Value;
        }
    }
}
