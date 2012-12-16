using Autofac;
using MahApps.Metro.Controls;

namespace MissileSharp.Launcher.Services
{
    public class WindowService : IWindowService
    {
        private IContainer container;

        public WindowService(IContainer container)
        {
            this.container = container;
        }

        public T GetWindow<T>() where T : MetroWindow
        {
            return (T)this.container.Resolve<T>();
        }
    }
}
