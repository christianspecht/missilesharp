using MahApps.Metro.Controls;
using MissileSharp.Launcher.ViewModels;

namespace MissileSharp.Launcher.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : MetroWindow
    {
        public MessageBoxWindow(MessageBoxWindowViewModel viewmodel)
        {
            this.DataContext = viewmodel;
            InitializeComponent();
        }
    }
}
