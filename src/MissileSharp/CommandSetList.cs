using System;
using System.Collections.Generic;
using System.Linq;

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
            dict = new Dictionary<string, List<LauncherCommand>>();
        }

        /// <summary>
        /// Add a new item to a command set (command set will be created if it doesn't exist)
        /// </summary>
        /// <param name="commandSetName">The name of the command set</param>
        /// <param name="command">The actual command set (a list of commands)</param>
        public void Add(string commandSetName, LauncherCommand command)
        {
            if (string.IsNullOrEmpty(commandSetName))
            {
                throw new InvalidOperationException("command set name is empty");
            }

            if (command == null)
            {
                throw new InvalidOperationException("command set is empty");
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
