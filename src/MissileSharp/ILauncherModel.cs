
namespace MissileSharp
{
    /// <summary>
    /// base interface for all missile launcher models
    /// </summary>
    public interface ILauncherModel
    {
        /// <summary>
        /// VendorId of the device
        /// </summary>
        int VendorId { get; }

        /// <summary>
        /// DeviceId of the device
        /// </summary>
        int DeviceId { get; }

        /// <summary>
        /// Command to move down
        /// </summary>
        byte Down { get; }

        /// <summary>
        /// Command to move up
        /// </summary>
        byte Up { get; }

        /// <summary>
        /// Command to turn left
        /// </summary>
        byte Left { get; }

        /// <summary>
        /// Command to turn right
        /// </summary>
        byte Right { get; }

        /// <summary>
        /// Command to stop moving
        /// </summary>
        byte Stop { get; }

        /// <summary>
        /// Command to fire a missile
        /// </summary>
        byte Fire { get; }

        /// <summary>
        /// Minimum number of shots possible (usually 1)
        /// </summary>
        int MinNumberOfShots { get; }

        /// <summary>
        /// Maximum number of shots possible
        /// </summary>
        int MaxNumberOfShots { get; }

        /// <summary>
        /// Reset position: move X milliseconds left
        /// </summary>
        int ResetTimeLeft { get; }

        /// <summary>
        /// Reset position: move X milliseconds down
        /// </summary>
        int ResetTimeDown { get; }

        /// <summary>
        /// Wait X milliseconds before first shot
        /// </summary>
        int WaitBeforeFire { get; }

        /// <summary>
        /// Wait X milliseconds after each shot
        /// </summary>
        int WaitAfterFire { get; }

        /// <summary>
        /// Create the final command to send to the launcher
        /// </summary>
        /// <param name="command">The command to send (move, fire etc.)</param>
        /// <returns>byte array to send to the launcher</returns>
        byte[] CreateCommand(byte command);
    }
}
