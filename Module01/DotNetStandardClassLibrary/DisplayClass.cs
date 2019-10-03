using System;

namespace DotNetStandardClassLibrary
{
    public class DisplayClass
    {
        public static string DisplayInfo(string name)
        {
            DateTime now = DateTime.Now;
            string asString = $"{now.ToString("dd MMMM yyyy hh:mm:ss tt")} Hello {name}";
            return asString;
        }
    }
}
