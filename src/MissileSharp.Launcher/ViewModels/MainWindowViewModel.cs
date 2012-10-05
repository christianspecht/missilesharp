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
        private IShutdownService shutdownService;

        public ObservableCollection<string> CommandSets { get; set; }

        public ICommand FireCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel(IConfigService configService, IMessageService messageService, IShutdownService shutdownService)
        {
            this.configService = configService;
            this.messageService = messageService;
            this.shutdownService = shutdownService;

            var launcher = LauncherModelFactory.GetLauncher(this.configService.LauncherName, this.configService.LauncherAssembly);

            this.model = new CommandCenter(launcher);

            this.FireCommand = new RelayCommand(new Action<object>(this.FireMissile));

            try
            {
                this.model.LoadCommandSets(this.configService.GetConfig());
            }
            catch (Exception ex)
            {
                this.messageService.ShowMessage(string.Format(Resources.ConfigFileError, Environment.NewLine, ex.Message));
                this.shutdownService.Shutdown();
                return;
            }

            this.CommandSets = new ObservableCollection<string>(this.model.GetLoadedCommandSetNames());
        }

        private void FireMissile(Object obj)
        {
            this.model.RunCommandSet(obj.ToString());
        }
    }
}
