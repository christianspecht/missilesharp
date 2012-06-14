
namespace MissileSharp
{
    /// <summary>
    /// settings for Dream Cheeky Thunder Missile Launcher
    /// </summary>
    public class ThunderMissileLauncher : ILauncherDevice
    {
        public int VendorId
        {
            get { return 0x2123; }
        }

        public int DeviceId
        {
            get { return 0x1010; }
        }

        public byte Down
        {
            get { return 1; }
        }

        public byte Up
        {
            get { return 2; }
        }

        public byte Left
        {
            get { return 4; }
        }

        public byte Right
        {
            get { return 8; }
        }

        public byte Stop
        {
            get { return 32; }
        }

        public byte Fire
        {
            get { return 16; }
        }

        public byte[] CreateCommand(byte command)
        {
            var data = new byte[9];
            data[1] = 2;
            data[2] = command;
            return data;
        }
    }
}
