using System.IO;
using System.Windows;
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

            string configFile = "settings.txt";
            string[] config = File.ReadAllLines(configFile);

            var window = new MainWindow();
            var viewmodel = new MainWindowViewModel(config);
            window.DataContext = viewmodel;
            window.Show();
        }
    }
}
