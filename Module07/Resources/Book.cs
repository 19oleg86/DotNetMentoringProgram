using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Resources
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string PublishCity { get; set; }
        public string PublisherName { get; set; }
        public int YearOfPublish { get; set; }
        public int NumberOfPages { get; set; }
        public string Remark { get; set; }
        public string ISBN { get; set; }

        public Book()
        {
        }
        public Book(XElement child)
        {
            var properties = child.Elements().Where(x => x.NodeType == XmlNodeType.Element).ToList();
            Name = child.FirstAttribute.Value;
            Author = properties.FirstOrDefault(x => x.Name == "author")?.Value;
            PublishCity = properties.FirstOrDefault(x => x.Name == "publishCity")?.Value;
            if (string.IsNullOrEmpty(PublishCity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: The element publishCity is required but it doesn't contain any Value, please check source Xml File");
                Console.ResetColor();
                PublishCity = "This is default value instead of empty value";
            }
            PublisherName = properties.FirstOrDefault(x => x.Name == "publisherName")?.Value;
            YearOfPublish = int.Parse(properties.FirstOrDefault(x => x.Name == "yearOfPublish")?.Value);
            NumberOfPages = int.Parse(properties.FirstOrDefault(x => x.Name == "numberOfPages")?.Value);
            Remark = properties.FirstOrDefault(x => x.Name == "remark")?.Value;
            ISBN = properties.FirstOrDefault(x => x.Name == "ISBN")?.Value;
        }
    }
}
