using System;

namespace MissileSharp
{
    /// <summary>
    /// One single command
    /// </summary>
    public class LauncherCommand
    {
        private string command;

        /// <summary>
        /// Creates a new instance of the LauncherCommand class
        /// </summary>
        /// <param name="command"></param>
        /// <param name="value"></param>
        public LauncherCommand(string command, int value)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new InvalidOperationException("command is empty");
            }

            if (value < 0)
            {
                throw new InvalidOperationException("value must be equal or greater than zero");
            }

            this.Command = command;
            this.Value = value;
        }

        /// <summary>
        /// the actual command ("left", "fire" etc.)
        /// </summary>
        public string Command 
        {
            get { return this.command; }
            set { this.command = value.ToLower(); }
        }

        /// <summary>
        /// numeric value (movement: milliseconds / firing: number of shots)
        /// </summary>
        public int Value { get; set; }
    }
}
