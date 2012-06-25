using System.Collections.Generic;

namespace MissileSharp.Tests
{
    /// <summary>
    /// Mock implementation of IHidDevice (records the received commands)
    /// </summary>
    class MockHidDevice : IHidDevice
    {
        public void Initialize(int vendorId, int deviceId)
        {
            ReceivedCommands = new List<byte>();
        }

        public void Dispose()
        {
        }

        public bool IsReady
        {
            get { return true; }
        }

        public void SendData(byte[] data)
        {
            // saving the first byte is enough, because the StubMissileLauncher makes sure that the first byte contains the actual command
            ReceivedCommands.Add(data[0]);
        }

        public List<byte> ReceivedCommands { get; private set; }
    }
}
