using System.Configuration;

namespace MissileSharp.Launcher.Services
{
    public class CommandCenterService : ICommandCenterService
    {
        public ICommandCenter GetCommandCenter()
        {
            string launcherName = ConfigurationManager.AppSettings["LauncherName"];
            string launcherAssembly = ConfigurationManager.AppSettings["LauncherAssembly"];

            var launcher = LauncherModelFactory.GetLauncher(launcherName, launcherAssembly);
            return new CommandCenter(launcher);
        }
    }
}
