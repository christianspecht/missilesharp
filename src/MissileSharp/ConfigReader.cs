using System;
using System.Collections.Generic;
using System.IO;
using MissileSharp.Properties;

namespace MissileSharp
{
    /// <summary>
    /// Reads command sets from a config file
    /// </summary>
    public static class ConfigReader
    {
        /// <summary>
        /// Reads a config file into a Dictionary of command sets
        /// </summary>
        /// <param name="configFile">The config file to load</param>
        /// <returns>A Dictionary of command sets</returns>
        public static CommandSetList Read(string configFile)
        {
            var commands = new CommandSetList();

            if (File.Exists(configFile))
            {
                string[] lines = File.ReadAllLines(configFile);
                commands = Read(lines);
            }

            return commands;
        }

        /// <summary>
        /// Reads a config file into a Dictionary of command sets
        /// </summary>
        /// <param name="configFileLines">The config file lines</param>
        /// <returns>A Dictionary of command sets</returns>
        public static CommandSetList Read(string[] configFileLines)
        {
            var commands = new CommandSetList();

            string key = string.Empty;

            foreach (string line in configFileLines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    key = line.Substring(1, line.Length - 2);
                }
                else if (line.Length > 0) // ignore empty lines
                {
                    if (string.IsNullOrEmpty(key))
                    {
                        throw new InvalidOperationException(Resources.FirstLineMustBeCommandSetName);
                    }

                    var items = line.Split(',');

                    if (items.Length != 2)
                    {
                        throw new InvalidOperationException(Resources.LineDoesNotContainTwoItems + line);
                    }

                    int value;

                    if (!int.TryParse(items[1], out value))
                    {
                        throw new InvalidOperationException(Resources.SecondItemMustBeNumeric + line);
                    }

                    commands.Add(key, items[0], value);
                    
                }
            }
            return commands;
        }
    }
}
