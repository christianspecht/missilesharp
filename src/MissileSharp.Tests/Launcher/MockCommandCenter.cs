using System;
using System.Collections.Generic;

namespace MissileSharp.Tests.Launcher
{
    public class MockCommandCenter : ICommandCenter
    {
        public bool IsReady
        {
            get { throw new NotImplementedException(); }
        }

        public void RunCommand(LauncherCommand command)
        {
            throw new NotImplementedException();
        }

        public void RunCommandSet(IEnumerable<LauncherCommand> commands)
        {
            throw new NotImplementedException();
        }

        public bool RunCommandSetWithStringWasCalled { get; private set; }
        public string RunCommandSetCommandSetName { get; private set; }

        public void RunCommandSet(string commandSetName)
        {
            this.RunCommandSetWithStringWasCalled = true;
            this.RunCommandSetCommandSetName = commandSetName;
        }

        public bool LoadCommandSets(string pathToConfigFile)
        {
            throw new NotImplementedException();
        }

        public bool LoadCommandSets(string[] configFileLines)
        {
            throw new NotImplementedException();
        }

        public List<string> GetLoadedCommandSetNames()
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Up(int milliseconds)
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Down(int milliseconds)
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Left(int milliseconds)
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Right(int milliseconds)
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Reset()
        {
            throw new NotImplementedException();
        }

        public ICommandCenter Fire(int numberOfShots)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
