using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MissileSharp.Launcher.Services;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CommandCenter model;
        private IConfigService configService;

        public ObservableCollection<string> CommandSets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IConfigService configService)
        {
            this.model = new CommandCenter(new ThunderMissileLauncher());

            this.configService = configService;

            try
            {
                model.LoadCommandSets(configService.GetConfig());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Couldn't load config file. Error:{0}{1}", Environment.NewLine, ex.Message));
                Application.Current.Shutdown();
                return;
            }

            this.CommandSets = new ObservableCollection<string>(model.GetLoadedCommandSetNames());
        }
    }
}
