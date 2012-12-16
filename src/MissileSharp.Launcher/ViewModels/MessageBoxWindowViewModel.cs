using System.ComponentModel;

namespace MissileSharp.Launcher.ViewModels
{
    public class MessageBoxWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
