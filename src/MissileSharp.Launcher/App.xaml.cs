using System.Windows;
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

            var window = new MainWindow();
            var viewmodel = new MainWindowViewModel(new ConfigService());
            window.DataContext = viewmodel;
            window.Show();
        }
    }
}
