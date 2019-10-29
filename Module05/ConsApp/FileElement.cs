using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp
{
    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true)]
        public string FileType
        {
            get { return (string)base["name"]; }
        }
    }
}
