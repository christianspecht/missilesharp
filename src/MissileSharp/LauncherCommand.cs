using System;
using MissileSharp.Properties;

namespace MissileSharp
{
    /// <summary>
    /// One single command
    /// </summary>
    public class LauncherCommand
    {
        /// <summary>
        /// Creates a new instance of the LauncherCommand class
        /// </summary>
        /// <param name="command">the actual command as a string ("down", "fire" etc.)</param>
        /// <param name="value">numeric value (movement: milliseconds / firing: number of shots)</param>
        public LauncherCommand(string command, int value)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(Resources.CommandEmpty);
            }

            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.ValueMustBeEqualGreaterZero);
            }

            switch (command.ToLower())
            {
                case "up":
                    this.Command = Command.Up;
                    break;
                case "down":
                    this.Command = Command.Down;
                    break;
                case "left":
                    this.Command = Command.Left;
                    break;
                case "right":
                    this.Command = Command.Right;
                    break;
                case "reset":
                    this.Command = Command.Reset;
                    break;
                case "fire":
                    this.Command = Command.Fire;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(Resources.CommandMustBeOneOfFollowing);
            }

            this.Value = value;
        }

        /// <summary>
        /// Creates a new instance of the LauncherCommand class
        /// </summary>
        /// <param name="command">the actual command</param>
        /// <param name="value">numeric value (movement: milliseconds / firing: number of shots)</param>
        public LauncherCommand(Command command, int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(Resources.ValueMustBeEqualGreaterZero);
            }

            this.Command = command;
            this.Value = value;
        }

        /// <summary>
        /// the actual command
        /// </summary>
        public Command Command { get; set; }

        /// <summary>
        /// numeric value (movement: milliseconds / firing: number of shots)
        /// </summary>
        public int Value { get; set; }
    }
}
