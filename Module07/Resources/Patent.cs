using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Resources
{
    public class Patent
    {
        public string Name { get; set; }
        public string Inventer { get; set; }
        public string Country { get; set; }
        public int RegisterNumber { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime PublishDate { get; set; }
        public int NumberOfPages { get; set; }
        public string Remark { get; set; }

        public Patent()
        {
        }
        public Patent(XElement child)
        {
            var properties = child.Elements().Where(x => x.NodeType == XmlNodeType.Element).ToList();
            Name = child.FirstAttribute.Value;
            Inventer = properties.FirstOrDefault(x => x.Name == "inventer")?.Value;
            Country = properties.FirstOrDefault(x => x.Name == "country")?.Value;
            RegisterNumber = int.Parse(properties.FirstOrDefault(x => x.Name == "registerNumber")?.Value);
            ApplyDate = DateTime.Parse(properties.FirstOrDefault(x => x.Name == "applyDate")?.Value);
            PublishDate = DateTime.Parse(properties.FirstOrDefault(x => x.Name == "publishDate")?.Value);
            NumberOfPages = int.Parse(properties.FirstOrDefault(x => x.Name == "numberOfPages")?.Value);
            Remark = properties.FirstOrDefault(x => x.Name == "remark")?.Value;
        }
    }
}
