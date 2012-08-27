
namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service to abstract MessageBox.Show() away
    /// </summary>
    public interface IMessageService
    {
        void ShowMessage(string messageText);
    }
}
