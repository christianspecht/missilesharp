using System;
using System.Collections.Generic;
using System.Linq;
using MissileSharp.Properties;

namespace MissileSharp
{
    /// <summary>
    /// A dictionary of lists of LauncherCommands, searchable by command set name
    /// </summary>
    public class CommandSetList
    {
        private Dictionary<string, List<LauncherCommand>> dict = null;

        /// <summary>
        /// Creates a new instance of the LauncherCommandList class
        /// </summary>
        public CommandSetList()
        {
            dict = new Dictionary<string, List<LauncherCommand>>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Add a new item to a command set (command set will be created if it doesn't exist)
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <param name="command">The actual command</param>
        public void Add(string commandSetName, LauncherCommand command)
        {
            if (string.IsNullOrEmpty(commandSetName))
            {
                throw new ArgumentNullException(Resources.CommandSetNameEmpty);
            }

            if (command == null)
            {
                throw new ArgumentNullException(Resources.CommandEmpty);
            }

            if (!dict.ContainsKey(commandSetName))
            {
                dict.Add(commandSetName, new List<LauncherCommand>());
            }

            dict[commandSetName].Add(command);
        }

        /// <summary>
        /// Add a new item to a command set (command set will be created if it doesn't exist)
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <param name="command">The actual command ("left", "fire" etc.)</param>
        /// <param name="value">Numeric value for the command (duration/number of shots)</param>
        public void Add(string commandSetName, string command, int value)
        {
            Add(commandSetName, new LauncherCommand(command, value));
        }

        /// <summary>
        /// Add a new item to a command set (command set will be created if it doesn't exist)
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <param name="command">The actual command</param>
        /// <param name="value">Numeric value for the command (duration/number of shots)</param>
        public void Add(string commandSetName, Command command, int value)
        {
            Add(commandSetName, new LauncherCommand(command, value));
        }

        /// <summary>
        /// Get a command set (=list of LauncherCommands) by name
        /// </summary>
        /// <param name="commandSetName">The name to search for</param>
        /// <returns>A list of commands (empty if the name is not found)</returns>
        public List<LauncherCommand> GetCommandSet(string commandSetName)
        {
            var list = new List<LauncherCommand>();

            if (dict.ContainsKey(commandSetName))
            {
                list = dict[commandSetName];
            }

            return list;
        }

        /// <summary>
        /// Gets the names of all available command sets
        /// </summary>
        /// <returns>A list of command set names</returns>
        public List<string> GetCommandSetNames()
        {
            return new List<string>(dict.Keys.OrderBy(d => d));
        }

        /// <summary>
        /// Counts the number of command sets.
        /// </summary>
        public int CountSets()
        {
            return dict.Count;
        }

        /// <summary>
        /// Counts the number of commands in a specific command set.
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <returns></returns>
        public int CountCommands(string commandSetName)
        {
            return GetCommandSet(commandSetName).Count;
        }

        /// <summary>
        /// Checks whether a command set with the given name exists
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <returns>True if it exists, False if not</returns>
        public bool ContainsCommandSet(string commandSetName)
        {
            var set = GetCommandSet(commandSetName);
            return set.Any();
        }
    }
}
