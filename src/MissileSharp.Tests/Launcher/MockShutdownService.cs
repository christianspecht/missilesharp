using MissileSharp.Launcher.Services;

namespace MissileSharp.Tests.Launcher
{
    public class MockShutdownService : IShutdownService
    {
        public bool ShutDownWasCalled { get; private set; }

        public void Shutdown()
        {
            this.ShutDownWasCalled = true;
        }
    }
}
