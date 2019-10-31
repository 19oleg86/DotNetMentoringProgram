using System.Configuration;

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
