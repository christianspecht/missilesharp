using System.Windows;

namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service to shut down the app
    /// </summary>
    public class ShutdownService : IShutdownService
    {
        public void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
