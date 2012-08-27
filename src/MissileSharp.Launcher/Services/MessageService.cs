using System.Windows;

namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service to abstract MessageBox.Show() away
    /// </summary>
    public class MessageService : IMessageService
    {
        public void ShowMessage(string messageText)
        {
            MessageBox.Show(messageText);
        }
    }
}
