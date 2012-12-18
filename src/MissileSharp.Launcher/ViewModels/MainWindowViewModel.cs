using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MissileSharp.Launcher.Properties;
using MissileSharp.Launcher.Services;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ICommandCenter model;
        private readonly ICommandCenterService commandCenterService;
        private readonly IConfigService configService;
        private readonly IMessageService messageService;
        private readonly IShutdownService shutdownService;

        public ObservableCollection<string> CommandSets { get; set; }

        public ICommand FireCommand
        {
            get { return new RelayCommand(this.FireMissile); }
        }

        public MainWindowViewModel(ICommandCenterService commandCenterService, IConfigService configService, IMessageService messageService, IShutdownService shutdownService)
        {
            this.commandCenterService = commandCenterService;
            this.configService = configService;
            this.messageService = messageService;
            this.shutdownService = shutdownService;

            Initialize();
        }

        public void Initialize()
        {
            try
            {
                this.model = this.commandCenterService.GetCommandCenter();
                this.model.LoadCommandSets(this.configService.GetConfig());
            }
            catch (Exception ex)
            {
                Shutdown(ex.Message);
                return;
            }

            if (!this.model.GetLoadedCommandSetNames().Any())
            {
                Shutdown(Resources.NoCommandSetsInConfig);
                return;
            }

            this.CommandSets = new ObservableCollection<string>(this.model.GetLoadedCommandSetNames());
        }

        private void FireMissile(Object obj)
        {
            if (!this.model.IsReady)
            {
                this.messageService.ShowMessage(Resources.DeviceIsNotReady);
                return;
            }

            try
            {
                this.model.RunCommandSet(obj.ToString());
            }
            catch (Exception ex)
            {
                Shutdown(ex.Message);
                return;
            }
        }

        private void Shutdown(string message)
        {
            this.messageService.ShowMessage(message);
            this.shutdownService.Shutdown();
        }
    }
}
