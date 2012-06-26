using System;
using System.Collections.Generic;
using System.Threading;

namespace MissileSharp
{
    /// <summary>
    /// Controls an USB missile launcher
    /// </summary>
    public class CommandCenter : IDisposable
    {
        IHidDevice device;
        ILauncherModel launcher;

        /// <summary>
        /// Initializes a new instance of the CommandCenter class using the specified missile launcher model.
        /// </summary>
        /// <param name="launcher">missile launcher model you want to control</param>
        public CommandCenter(ILauncherModel launcher) : this(launcher, new HidLibraryDevice())
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandCenter class using the specified missile launcher model and HID library implementation.
        /// </summary>
        /// <param name="launcher">missile launcher model you want to control</param>
        /// <param name="device">HID library that will be used</param>
        /// <remarks>This is only for testing - HidLibrary is the default library for production use</remarks>
        internal CommandCenter(ILauncherModel launcher, IHidDevice device)
        {
            this.launcher = launcher;
            this.device = device;

            device.Initialize(launcher.VendorId, launcher.DeviceId);
        }

        /// <summary>
        /// The device is ready to receive commands
        /// </summary>
        public bool IsReady
        {
            get
            {
                return device.IsReady;
            }
        }

        /// <summary>
        /// Runs a LauncherCommand
        /// </summary>
        /// <param name="command">The command to run</param>
        public void RunCommand(LauncherCommand command)
        {
            switch (command.Command)
            {
                case "up":
                    Up(command.Value);
                    break;
                case "down":
                    Down(command.Value);
                    break;
                case "left":
                    Left(command.Value);
                    break;
                case "right":
                    Right(command.Value);
                    break;
                case "reset":
                    Reset();
                    break;
                case "fire":
                    Fire(command.Value);
                    break;
            }
        }

        /// <summary>
        /// Runs a list of LauncherCommands
        /// </summary>
        /// <param name="commands">The list of commands to run</param>
        public void RunCommandSet(IEnumerable<LauncherCommand> commands)
        {
            foreach (var cmd in commands)
            {
                RunCommand(cmd);
            }
        }

        /// <summary>
        /// Move up for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public CommandCenter Up(int milliseconds)
        {
            SendMoveCommand(launcher.Up, milliseconds);
            return this;
        }

        /// <summary>
        /// Move down for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public CommandCenter Down(int milliseconds)
        {
            SendMoveCommand(launcher.Down, milliseconds);
            return this;
        }

        /// <summary>
        /// Turn left for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public CommandCenter Left(int milliseconds)
        {
            SendMoveCommand(launcher.Left, milliseconds);
            return this;
        }

        /// <summary>
        /// Turn right for X milliseconds
        /// </summary>
        /// <param name="milliseconds">Time to move</param>
        public CommandCenter Right(int milliseconds)
        {
            SendMoveCommand(launcher.Right, milliseconds);
            return this;
        }

        /// <summary>
        /// Reset the launcher position (=move to bottom left)
        /// </summary>
        public CommandCenter Reset()
        {
            Down(launcher.ResetTimeDown);
            Left(launcher.ResetTimeLeft);
            return this;
        }

        /// <summary>
        /// Fire X missiles
        /// </summary>
        /// <param name="numberOfShots">Number of missiles to fire</param>
        public CommandCenter Fire(int numberOfShots)
        {
            if (numberOfShots < launcher.MinNumberOfShots)
            {
                numberOfShots = launcher.MinNumberOfShots;
            }

            if (numberOfShots > launcher.MaxNumberOfShots)
            {
                numberOfShots = launcher.MaxNumberOfShots; 
            }

            Thread.Sleep(launcher.WaitBeforeFire);

            for (int i = 1; i <= numberOfShots; i++)
            {
                SendCommand(launcher.Fire);
                Thread.Sleep(launcher.WaitAfterFire);
            }

            return this;
        }

        /// <summary>
        /// dispose the device
        /// </summary>
        public void Dispose()
        {
            if (IsReady)
            {
                device.Dispose();
            }
        }

        /// <summary>
        /// Send a command to the device
        /// </summary>
        /// <param name="command">The command to send</param>
        internal void SendCommand(byte command)
        {
            var data = launcher.CreateCommand(command);
            device.SendData(data);
        }

        /// <summary>
        /// Send a move command to the device, wait X milliseconds, then stop
        /// </summary>
        /// <param name="command">The command to send</param>
        /// <param name="milliseconds">Time to wait</param>
        internal void SendMoveCommand(byte command, int milliseconds)
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
