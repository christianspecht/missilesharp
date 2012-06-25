
namespace MissileSharp
{
    /// <summary>
    /// base interface for HID device library
    /// </summary>
    internal interface IHidDevice
    {
        /// <summary>
        /// Initializes the device.
        /// </summary>
        /// <param name="vendorId">VendorId of the device</param>
        /// <param name="deviceId">DeviceId of the device</param>
        void Initialize(int vendorId, int deviceId);

        /// <summary>
        /// Disposes the device.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Indicates if the device is ready to receive commands.
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Sends data to the device.
        /// </summary>
        /// <param name="data">Data to send</param>
        void SendData(byte[] data);
    }
}
