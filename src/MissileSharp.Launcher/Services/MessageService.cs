using MissileSharp.Launcher.ViewModels;
using MissileSharp.Launcher.Views;

namespace MissileSharp.Launcher.Services
{
    /// <summary>
    /// helper service to show message box
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IWindowService windowService;

        public MessageService(IWindowService windowService)
        {
            this.windowService = windowService;
        }

        public void ShowMessage(string messageText)
        {
            var window = windowService.GetWindow<MessageBoxWindow>();
            ((MessageBoxWindowViewModel)window.DataContext).MessageText = messageText;
            window.ShowDialog();
        }
    }
}
