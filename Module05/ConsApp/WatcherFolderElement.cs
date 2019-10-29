using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp
{
    public class WatcherFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderToWatch
        {
            get { return (string)this["value"]; }
        }
    }
}
