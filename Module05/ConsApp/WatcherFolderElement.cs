using System.Configuration;

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
