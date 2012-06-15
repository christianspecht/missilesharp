using System;
using System.Linq;
using System.Threading;
using HidLibrary;

namespace MissileSharp
{
    /// <summary>
    /// Controls an USB missile launcher
    /// </summary>
    public class CommandCenter : IDisposable
    {
        HidDevice device;
        ILauncherModel launcher;

        /// <summary>
        /// Initializes a new instance of the CommandCenter class using the specified missile launcher model.
        /// </summary>
        /// <param name="launcher">missile launcher model you want to control</param>
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

        /// <summary>
        /// The device is ready to receive commands
        /// </summary>
        public bool IsReady
        {
            get
            {
                return (device != null && device.IsOpen);
            }
        }

        /// <summary>
        /// Move up for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public void Up(int milliseconds)
        {
            SendCommand(launcher.Up);
            Thread.Sleep(milliseconds);
            SendCommand(launcher.Stop);
        }

        /// <summary>
        /// dispose the device
        /// </summary>
        public void Dispose()
        {
            if (IsReady)
            {
                device.CloseDevice();
            }
        }

        /// <summary>
        /// Send a command to the device
        /// </summary>
        /// <param name="command">The command to send</param>
        private void SendCommand(byte command)
        {
            var data = launcher.CreateCommand(command);
            device.Write(data);
        }
    }
}
