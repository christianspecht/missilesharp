using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MissileSharp.Launcher.ViewModels
{
    /// <summary>
    /// base class for all view models, implements INotifyPropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand CloseCommand
        {
            get { return new RelayCommand(o => ((Window)o).Close()); }
        }
    }
}
