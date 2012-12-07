using MahApps.Metro.Controls;
using MissileSharp.Launcher.ViewModels;

namespace MissileSharp.Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(MainWindowViewModel viewmodel)
        {
            this.DataContext = viewmodel;
            InitializeComponent();
        }
    }
}
