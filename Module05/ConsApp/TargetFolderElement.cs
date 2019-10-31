using System.Configuration;

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
