using System;
using System.Linq;
using System.Threading;
using HidLibrary;

namespace MissileSharp
{
    public class CommandCenter : IDisposable
    {
        HidDevice device;
        ILauncherModel launcher;

        public CommandCenter(ILauncherModel launcher)
        {
            this.launcher = launcher;

            var devices = HidDevices.Enumerate(launcher.VendorId, launcher.DeviceId);
            if (devices.Any())
            {
                device = devices.First();
                device.OpenDevice();

                while (!device.IsConnected || !device.IsOpen)
                {
                }
            }
        }

        public bool IsReady
        {
            get
            {
                return (device != null && device.IsOpen);
            }
        }

        public void Up(int milliseconds)
        {
            SendCommand(launcher.Up);
            Thread.Sleep(milliseconds);
            SendCommand(launcher.Stop);
        }

        public void Dispose()
        {
            if (IsReady)
            {
                device.CloseDevice();
            }
        }

        private void SendCommand(byte command)
        {
            var data = launcher.CreateCommand(command);
            device.Write(data);
        }
    }
}
