using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    }
}
