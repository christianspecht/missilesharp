using System;
using System.Collections.Generic;

namespace MissileSharp
{
    /// <summary>
    /// Controls an USB missile launcher
    /// </summary>
    public interface ICommandCenter : IDisposable
    {
        /// <summary>
        /// The device is ready to receive commands
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// The name of the device
        /// </summary>
        string LauncherModelName { get; }

        /// <summary>
        /// Runs a LauncherCommand
        /// </summary>
        /// <param name="command">The command to run</param>
        void RunCommand(LauncherCommand command);

        /// <summary>
        /// Runs a list of LauncherCommands
        /// </summary>
        /// <param name="commands">The list of commands to run</param>
        void RunCommandSet(IEnumerable<LauncherCommand> commands);

        /// <summary>
        /// Runs a list of LauncherCommands by name (commands must have been loaded before using LoadCommandSets)
        /// </summary>
        /// <param name="commandSetName">The name of the command set to run</param>
        void RunCommandSet(string commandSetName);

        /// <summary>
        /// Loads a list of command sets from a config file (execute command sets with RunCommandSet)
        /// </summary>
        /// <param name="pathToConfigFile">Complete path to the config file</param>
        /// <returns>True if at least one command set was loaded</returns>
        bool LoadCommandSets(string pathToConfigFile);

        /// <summary>
        /// Loads a list of command sets from a config file (execute command sets with RunCommandSet)
        /// </summary>
        /// <param name="configFileLines">The lines of the config file (after loading the file with File.ReadAllLines)</param>
        /// <returns>True if at least one command set was loaded</returns>
        bool LoadCommandSets(string[] configFileLines);

        /// <summary>
        /// Gets a list with the names of all loaded command sets.
        /// </summary>
        /// <returns>A list of command set names</returns>
        List<string> GetLoadedCommandSetNames();

        /// <summary>
        /// Move up for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        ICommandCenter Up(int milliseconds);

        /// <summary>
        /// Move down for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        ICommandCenter Down(int milliseconds);

        /// <summary>
        /// Turn left for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        ICommandCenter Left(int milliseconds);

        /// <summary>
        /// Turn right for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        ICommandCenter Right(int milliseconds);

        /// <summary>
        /// Reset the launcher position (=move to bottom left)
        /// </summary>
        ICommandCenter Reset();

        /// <summary>
        /// Fire X missiles
        /// </summary>
        /// <param name="numberOfShots">Number of missiles to fire</param>
        ICommandCenter Fire(int numberOfShots);
    }
}
