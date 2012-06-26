
namespace MissileSharp.Tests
{
    /// <summary>
    /// Stub missile launcher for testing
    /// </summary>
    /// <remarks>
    /// We don't care about the actual command values, so we just use the real implementation for testing
    /// </remarks>
    class StubMissileLauncher : ThunderMissileLauncher, ILauncherModel
    {
        public new int WaitBeforeFire
        {
            get { return 0; }
        }

        public new int WaitAfterFire
        {
            get { return 0; }
        }

        public new byte[] CreateCommand(byte command)
        {
            // return ONLY the command, so checking afterwards is easier
            var data = new byte[1];
            data[0] = command;
            return data;
        }
    }
}
