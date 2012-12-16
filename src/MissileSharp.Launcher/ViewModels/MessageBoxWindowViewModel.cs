
namespace MissileSharp.Launcher.ViewModels
{
    public class MessageBoxWindowViewModel : BaseViewModel
    {
        private string messageText;

        public string MessageText
        {
            get
            {
                return this.messageText;
            }
            set
            {
                this.messageText = value;
                OnPropertyChanged("MessageText");
            }
        }
    }
}
