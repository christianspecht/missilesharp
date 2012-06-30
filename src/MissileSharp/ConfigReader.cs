﻿using System;
using System.Collections.Generic;
using System.IO;

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

            string key = "";

            foreach (string line in configFileLines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    key = line.Substring(1, line.Length - 2).ToLower();
                }
                else if (line.Length > 0)
                {
                    var items = line.Split(',');

                    if (items.Length == 2)
                    {
                        int value;

                        if (int.TryParse(items[1], out value))
                        {
                            commands.Add(key, items[0], value);
                        }
                    }
                }
            }
            return commands;
        }
    }
}
