using System;
using System.Xml;

namespace SFMLRaycaster
{
    static class Config
    {
        public static int monitor;
        public static int screenWidth;
        public static int screenHeight;

        public static double mouseSensitivity;

        static Config()
        {
            string documentPath = $"{Environment.CurrentDirectory}\\Config.xml";
            
            XmlDocument configDocument = new XmlDocument();
            configDocument.Load(documentPath);

            monitor = int.Parse(configDocument.SelectSingleNode("/configuration/screenSettings/monitor/text()").Value);
            screenWidth = int.Parse(configDocument.SelectSingleNode("/configuration/screenSettings/screenWidth/text()").Value);
            screenHeight = int.Parse(configDocument.SelectSingleNode("/configuration/screenSettings/screenHeight/text()").Value);
            mouseSensitivity = double.Parse(configDocument.SelectSingleNode("/configuration/controlSettings/mouseSensitivity/text()").Value);
        }
    }
}
