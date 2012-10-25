using System;
using System.Collections.Generic;

namespace MissileSharp
{
    public interface ICommandCenter : IDisposable
    {
        bool IsReady { get; }

        void RunCommand(LauncherCommand command);

        void RunCommandSet(IEnumerable<LauncherCommand> commands);

        void RunCommandSet(string commandSetName);

        bool LoadCommandSets(string pathToConfigFile);

        bool LoadCommandSets(string[] configFileLines);

        List<string> GetLoadedCommandSetNames();

        ICommandCenter Up(int milliseconds);

        ICommandCenter Down(int milliseconds);

        ICommandCenter Left(int milliseconds);

        ICommandCenter Right(int milliseconds);

        ICommandCenter Reset();

        ICommandCenter Fire(int numberOfShots);
    }
}
