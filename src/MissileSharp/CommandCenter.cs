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
            SendMoveCommand(launcher.Up, milliseconds);
        }

        /// <summary>
        /// Move down for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public void Down(int milliseconds)
        {
            SendMoveCommand(launcher.Down, milliseconds);
        }

        /// <summary>
        /// Turn left for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public void Left(int milliseconds)
        {
            SendMoveCommand(launcher.Left, milliseconds);
        }

        /// <summary>
        /// Turn right for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public void Right(int milliseconds)
        {
            SendMoveCommand(launcher.Right, milliseconds);
        }

        /// <summary>
        /// Reset the launcher position (=move to bottom left)
        /// </summary>
        public void Reset()
        {
            Down(launcher.ResetTimeDown);
            Left(launcher.ResetTimeLeft);
        }

        /// <summary>
        /// Fire X missiles
        /// </summary>
        /// <param name="numberOfShots">Number of missiles to fire (1-4)</param>
        public void Fire(byte numberOfShots)
        {
            if (numberOfShots < 1)
            {
                numberOfShots = 1;
            }

            if (numberOfShots > 4)
            {
                numberOfShots = 4; 
            }

            Thread.Sleep(launcher.WaitBeforeFire);

            for (int i = 1; i <= numberOfShots; i++)
            {
                SendCommand(launcher.Fire);
                Thread.Sleep(launcher.WaitAfterFire);
            }
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

        /// <summary>
        /// Send a move command to the device, wait X milliseconds, then stop
        /// </summary>
        /// <param name="command">The command to send</param>
        /// <param name="milliseconds">Time to wait</param>
        private void SendMoveCommand(byte command, int milliseconds)
        {
            if (IsReady)
            {
                SendCommand(command);
                Thread.Sleep(milliseconds);
                SendCommand(launcher.Stop);
            }
        }
    }
}
