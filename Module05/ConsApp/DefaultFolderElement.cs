using System.Configuration;

namespace ConsApp
{
    public class DefaultFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public string FolderToMove
        {
            get { return (string)this["value"]; }
        }
    }
}
