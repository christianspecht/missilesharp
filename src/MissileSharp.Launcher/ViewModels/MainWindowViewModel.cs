using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MissileSharp.Launcher.Properties;
using MissileSharp.Launcher.Services;
using MissileSharp.Launcher.Views;

namespace MissileSharp.Launcher.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ICommandCenter model;
        private bool disableGui;
        private readonly ICommandCenterService commandCenterService;
        private readonly IConfigService configService;
        private readonly IMessageService messageService;
        private readonly IShutdownService shutdownService;
        private readonly IWindowService windowService;

        public bool DisableGui
        {
            get
            {
                return this.disableGui;
            }
            set
            {
                this.disableGui = value;
                OnPropertyChanged("DisableGui");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ObservableCollection<string> CommandSets { get; set; }

        public ICommand FireCommand
        {
            get { return new RelayCommand(this.FireMissile, this.IsGuiEnabled); }
        }

        public ICommand AboutCommand
        {
            get { return new RelayCommand(this.AboutBox, this.IsGuiEnabled); }
        }

        public MainWindowViewModel(ICommandCenterService commandCenterService, IConfigService configService, IMessageService messageService, IShutdownService shutdownService, IWindowService windowService)
        {
            this.commandCenterService = commandCenterService;
            this.configService = configService;
            this.messageService = messageService;
            this.shutdownService = shutdownService;
            this.windowService = windowService;

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

            Exception workerException = null;

            var worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                try
                {
                    this.model.RunCommandSet(obj.ToString());
                }
                catch (Exception ex)
                {
                    workerException = ex;
                }
            };

            worker.RunWorkerCompleted += (o, ea) =>
            {
                this.DisableGui = false;

                if (workerException != null)
                {
                    Shutdown(workerException.Message);
                    return;
                }
            };

            this.DisableGui = true;
            worker.RunWorkerAsync();
        }

        private bool IsGuiEnabled(Object obj)
        {
            return !this.DisableGui;
        }

        private void Shutdown(string message)
        {
            this.messageService.ShowMessage(message);
            this.shutdownService.Shutdown();
        }

        private void AboutBox(Object obj)
        {
            var window = this.windowService.GetWindow<AboutWindow>();
            window.ShowDialog();
        }
    }
}
