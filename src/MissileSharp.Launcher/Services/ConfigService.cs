using System.Configuration;
using System.IO;
using MissileSharp.Launcher.Properties;

namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service, reads the config file and returns its content in a string[]
    /// </summary>
    public class ConfigService : IConfigService
    {
        public string[] GetConfig()
        {
            string configFile = "settings.txt";

            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException(Resources.ConfigFileMissing + configFile);
            }

            var configFileLines = File.ReadAllLines(configFile);

            if (configFileLines.Length == 0)
            {
                throw new FileFormatException(Resources.ConfigFileEmpty + configFile);
            }

            return configFileLines;
        }

        public string LauncherName
        {
            get { return ConfigurationManager.AppSettings["LauncherName"]; }
        }

        public string LauncherAssembly
        {
            get { return ConfigurationManager.AppSettings["LauncherAssembly"]; }
        }
    }
}
