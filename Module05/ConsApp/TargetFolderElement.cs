using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp
{
    public class TargetFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderToMove
        {
            get { return (string)this["value"]; }
        }
    }
}
