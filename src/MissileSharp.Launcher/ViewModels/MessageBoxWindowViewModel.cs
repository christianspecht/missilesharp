using System.Windows;
using System.Windows.Input;

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

        public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(o => ((Window)o).Close());
            }
        }
    }
}
