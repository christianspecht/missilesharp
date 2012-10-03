using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using MissileSharp.Launcher.Properties;
using MissileSharp.Launcher.Services;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private CommandCenter model;
        private IConfigService configService;
        private IMessageService messageService;

        public ObservableCollection<string> CommandSets { get; set; }

        public ICommand FireCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IConfigService configService, IMessageService messageService)
        {
            this.configService = configService;
            this.messageService = messageService;

            var launcher = LauncherModelFactory.GetLauncher("MissileSharp.ThunderMissileLauncher");

            this.model = new CommandCenter(launcher);

            this.FireCommand = new RelayCommand(new Action<object>(this.FireMissile));

            try
            {
                model.LoadCommandSets(configService.GetConfig());
            }
            catch (Exception ex)
            {
                messageService.ShowMessage(string.Format(Resources.ConfigFileError, Environment.NewLine, ex.Message));
                Application.Current.Shutdown();
                return;
            }

            this.CommandSets = new ObservableCollection<string>(model.GetLoadedCommandSetNames());
        }

        private void FireMissile(Object obj)
        {
            this.model.RunCommandSet(obj.ToString());
        }
    }
}
