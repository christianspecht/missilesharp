using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CommandCenter model;

        public ObservableCollection<string> CommandSets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            model = new CommandCenter(new ThunderMissileLauncher());
            model.LoadCommandSets("settings.txt");

            this.CommandSets = new ObservableCollection<string>(model.GetLoadedCommandSetNames());
        }
    }
}
