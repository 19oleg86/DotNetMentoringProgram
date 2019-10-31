using System.Configuration;

namespace ConsApp
{
    public class WatcherFolderElementThree : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderToWatchThree
        {
            get { return (string)this["value"]; }
        }
    }
}
