﻿using System.IO;

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
                throw new FileNotFoundException("Config file missing: " + configFile);
            }

            var configFileLines = File.ReadAllLines(configFile);

            if (configFileLines.Length == 0)
            {
                throw new FileFormatException("Config file empty: " + configFile);
            }

            return configFileLines;
        }
    }
}
