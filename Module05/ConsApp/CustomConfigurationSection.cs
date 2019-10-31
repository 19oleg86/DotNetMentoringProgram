using System.Configuration;

namespace ConsApp
{
    public class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("appName")]
        public string ApplicationName
        {
            get { return (string)base["appName"]; }
        }

        [ConfigurationProperty("watcherFolder")]
        public WatcherFolderElement WatcherFolder
        {
            get { return (WatcherFolderElement)this["watcherFolder"]; }
        }

        [ConfigurationProperty("watcherFolderTwo")]
        public WatcherFolderElementTwo WatcherFolderTwo
        {
            get { return (WatcherFolderElementTwo)this["watcherFolderTwo"]; }
        }

        [ConfigurationProperty("watcherFolderThree")]
        public WatcherFolderElementThree WatcherFolderThree
        {
            get { return (WatcherFolderElementThree)this["watcherFolderThree"]; }
        }

        [ConfigurationProperty("targetFolder")]
        public TargetFolderElement TargetFolder
        {
            get { return (TargetFolderElement)this["targetFolder"]; }
        }

        [ConfigurationProperty("defaultFolder")]
        public DefaultFolderElement DefaultFolder
        {
            get { return (DefaultFolderElement)this["defaultFolder"]; }
        }

        [ConfigurationProperty("files")]
        public FileElementCollection Files
        {
            get { return (FileElementCollection)this["files"]; }
        }
    }
}
