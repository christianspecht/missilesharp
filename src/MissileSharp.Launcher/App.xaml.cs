using System.Windows;
using Autofac;
using MissileSharp.Launcher.Services;
using MissileSharp.Launcher.ViewModels;

namespace MissileSharp.Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<MessageService>().As<IMessageService>();
            var container = builder.Build();

            var window = new MainWindow();
            var viewmodel = container.Resolve<MainWindowViewModel>();
            window.DataContext = viewmodel;
            window.Show();
        }
    }
}
