using MissileSharp.Launcher.Services;

namespace MissileSharp.Tests.Launcher
{
    public class StubCommandCenterService : ICommandCenterService
    {
        /// <summary>
        /// set the command center that is returned
        /// </summary>
        public ICommandCenter CommandCenter { private get; set; }

        public ICommandCenter GetCommandCenter()
        {
            return this.CommandCenter;
        }
    }
}
