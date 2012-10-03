using MissileSharp.Launcher.Services;

namespace MissileSharp.Tests.Launcher
{
    /// <summary>
    /// stub config service for testing
    /// (the config data that is returned can be set before)
    /// </summary>
    public class StubConfigService : IConfigService
    {
        private string[] config;

        /// <summary>
        /// save the data that will be returned by GetConfig
        /// </summary>
        /// <param name="config">string[] with config data</param>
        public void SetConfig(string[] config)
        {
            this.config = config;
        }

        public string[] GetConfig()
        {
            return this.config;
        }

        public string LauncherName { get; set; }

        public string LauncherAssembly { get; set; }
    }
}
