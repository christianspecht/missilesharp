using MahApps.Metro.Controls;
using MissileSharp.Launcher.ViewModels;

namespace MissileSharp.Launcher.Views
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : MetroWindow
    {
        public AboutWindow(AboutWindowViewModel viewmodel)
        {
            this.DataContext = viewmodel;
            InitializeComponent();
        }
    }
}
