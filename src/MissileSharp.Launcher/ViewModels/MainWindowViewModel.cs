using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CommandCenter model;

        public ObservableCollection<string> CommandSets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(string[] configFileLines)
        {
            model = new CommandCenter(new ThunderMissileLauncher());
            model.LoadCommandSets(configFileLines);

            this.CommandSets = new ObservableCollection<string>(model.GetLoadedCommandSetNames());
        }
    }
}
