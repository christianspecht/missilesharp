using System.Configuration;

namespace MissileSharp.Launcher.Services
{
    public class AppConfigService : IAppConfigService
    {
        public string LauncherName
        {
            get { return ConfigurationManager.AppSettings["LauncherName"]; }
        }

        public string LauncherAssembly
        {
            get { return ConfigurationManager.AppSettings["LauncherAssembly"]; }
        }
    }
}
