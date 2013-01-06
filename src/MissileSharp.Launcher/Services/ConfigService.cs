using System.IO;
using MissileSharp.Launcher.Properties;

namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service, reads the config file and returns its content in a string[]
    /// </summary>
    public class ConfigService : IConfigService
    {
        public string ConfigFileName
        {
            get { return "settings.txt"; }
        }

        public string[] GetConfig()
        {
            if (!File.Exists(this.ConfigFileName))
            {
                throw new FileNotFoundException(Resources.ConfigFileMissing + this.ConfigFileName);
            }

            var configFileLines = File.ReadAllLines(this.ConfigFileName);

            if (configFileLines.Length == 0)
            {
                throw new FileFormatException(Resources.ConfigFileEmpty + this.ConfigFileName);
            }

            return configFileLines;
        }
    }
}
