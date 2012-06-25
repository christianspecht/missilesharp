using System.Linq;
using HidLibrary;

namespace MissileSharp
{
    /// <summary>
    /// IHidDevice implementation for HidLibrary
    /// </summary> 
    internal class HidLibraryDevice : IHidDevice
    {
        HidDevice device;

        public void Initialize(int vendorId, int deviceId)
        {
            var devices = HidDevices.Enumerate(vendorId, deviceId);
            if (devices.Any())
            {
                device = devices.First();
                device.OpenDevice();

                while (!device.IsConnected || !device.IsOpen)
                {
                }
            }
        }

        public void Dispose()
        {
            device.CloseDevice();
        }

        public void SendData(byte[] data)
        {
            device.Write(data);
        }

        public bool IsReady
        {
            get
            {
                return (device != null && device.IsOpen);
            }
        }
    }
}
