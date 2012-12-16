using MahApps.Metro.Controls;

namespace MissileSharp.Launcher.Services
{
    public interface IWindowService
    {
        T GetWindow<T>() where T : MetroWindow;
    }
}
