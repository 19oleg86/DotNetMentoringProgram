using System.Configuration;

namespace ConsApp
{
    public class WatcherFolderElementTwo : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderToWatchTwo
        {
            get { return (string)this["value"]; }
        }
    }
}
