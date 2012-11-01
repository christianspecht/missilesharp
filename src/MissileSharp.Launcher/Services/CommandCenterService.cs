
namespace MissileSharp.Launcher.Services
{
    public class CommandCenterService : ICommandCenterService
    {
        private IAppConfigService acs;

        public CommandCenterService(IAppConfigService acs)
        {
            this.acs = acs;
        }

        public ICommandCenter GetCommandCenter()
        {
            var launcher = LauncherModelFactory.GetLauncher(acs.LauncherName, acs.LauncherAssembly);
            return new CommandCenter(launcher);
        }
    }
}
